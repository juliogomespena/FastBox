using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Configuration;
using System.Drawing.Printing;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormCadastrarOrdem : Form
{
    private readonly IOrdemDeServicoService _ordemService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private bool _isUpdatingText = false;
    private long? _clienteId = null;
    private long? _veiculoId = null;
    private ICollection<OrcamentoViewModel> _orcamentos = [];

    public FormCadastrarOrdem(IOrdemDeServicoService ordemService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _ordemService = ordemService;
        _serviceProvider = serviceProvider;
    }

    private async void BtnGerarOrdem_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            BtnGerarOrdemCadastrar.Enabled = false;

            var ordemConverted = new OrdemDeServicoViewModel
            {
                ClienteId = _clienteId,
                VeiculoId = _veiculoId,
                Descricao = RTxtDescricaoOrdemCadastrar.Text.Trim(),
                EstimativaConclusao = DateTimePickerEstimativaConclusao.Value,
                ValorTotal = _orcamentos.Where(orcamentos => orcamentos.StatusOrcamento == 2).SelectMany(orcamento => orcamento.ItensOrcamento).Sum(itens => (itens.PrecoUnitario + (itens.PrecoUnitario * itens.Margem)) * itens.Quantidade),
                Orcamentos = _orcamentos.Select(orcamento => new Orcamento
                {
                    StatusOrcamento = orcamento.StatusOrcamento,
                    DataCriacao = orcamento.DataCriacao,
                    Descricao = orcamento.Descricao,
                    ItensOrcamento = orcamento.ItensOrcamento.Select(itens => new ItemOrcamento
                    {
                        Descricao = itens.Descricao,
                        Quantidade = itens.Quantidade,
                        PrecoUnitario = itens.PrecoUnitario,
                        Margem = itens.Margem
                    }).ToList()
                }).ToList(),
                DataAbertura = DateTime.Now,
            };

            await _ordemService.AddOrdemAsync(ordemConverted);

            MessageBox.Show("Ordem de serviço cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao cadastrar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao cadastrar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao cadastrar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnGerarOrdemCadastrar.Enabled = true;
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(TxtVeiculoOrdemCadastrar.Text) || _veiculoId == null)
        {
            MessageBox.Show("Selecione um veículo para abrir a ordem de serviço.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        if (String.IsNullOrWhiteSpace(RTxtDescricaoOrdemCadastrar.Text))
        {
            MessageBox.Show("Digite uma breve descrição para a ordem de serviço.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var dataAtual = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
        var dataSelecionada = DateTimePickerEstimativaConclusao.Value.Date.AddHours(DateTimePickerEstimativaConclusao.Value.Hour);

        if (dataSelecionada < dataAtual)
        {
            MessageBox.Show("Selecione uma data e hora válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (String.IsNullOrWhiteSpace(TxtClienteOrdemCadastrar.Text))
        {
            var dialog = MessageBox.Show("Deseja continuar sem selecionar um cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;

        }

        if (!_orcamentos.Any())
        {
            var dialog = MessageBox.Show("Deseja continuar sem cadastrar um orçamento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;
        }

        return true;
    }

    private void TxtClienteOrdem_TextChanged(object sender, EventArgs e)
    {
        if (_isUpdatingText) return;

        _clienteId = null;

        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = GlobalConfiguration.debounceTimeMiliseconds };
        _debounceTimer.Tick += async (s, ev) =>
        {
            _debounceTimer.Stop();

            try
            {
                string searchText = TxtClienteOrdemCadastrar.Text.Trim();

                if (searchText.Length >= 2)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var clienteService = scope.ServiceProvider.GetRequiredService<IClienteService>();
                        var clientes = await clienteService.GetClientsByNameAsync(searchText);

                        LstSugestoesClientes.DataSource = clientes.ToList();
                        LstSugestoesClientes.DisplayMember = "NomeSobrenome";
                        LstSugestoesClientes.ValueMember = "ClienteId";
                        AdjustListBoxSize(LstSugestoesClientes);
                        LstSugestoesClientes.Visible = clientes.Any();
                        LstSugestoesClientes.Focus();
                        _clienteId = (long?)LstSugestoesClientes.SelectedValue;
                    }
                }
                else
                {
                    _clienteId = null;
                    _veiculoId = null;
                    TxtVeiculoOrdemCadastrar.Text = string.Empty;
                    LstSugestoesClientes.DataSource = null;
                    LstSugestoesClientes.Visible = false;
                    LstSugestoesVeiculos.DataSource = null;
                    LstSugestoesVeiculos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        _debounceTimer.Start();
    }

    private async void LstSugestoesClientes_Click(object sender, EventArgs e)
    {
        if (LstSugestoesClientes.SelectedItem is ClienteViewModel clienteSelecionado)
        {
            _isUpdatingText = true;
            TxtClienteOrdemCadastrar.Text = clienteSelecionado.NomeSobrenome;
            _isUpdatingText = false;
            LstSugestoesClientes.Visible = false;
            _clienteId = clienteSelecionado.ClienteId;

            if (clienteSelecionado.Veiculos != null && clienteSelecionado.Veiculos.Any())
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var veiculoService = scope.ServiceProvider.GetRequiredService<IVeiculoService>();
                    var veiculos = await veiculoService.GetVeiculosAsync(v => v.ClienteId == _clienteId);

                    LstSugestoesVeiculos.DataSource = veiculos.ToList();
                    LstSugestoesVeiculos.DisplayMember = "ModeloMatricula";
                    LstSugestoesVeiculos.ValueMember = "VeiculoId";
                    AdjustListBoxSize(LstSugestoesVeiculos);
                    LstSugestoesVeiculos.Visible = veiculos.Any();
                    LstSugestoesVeiculos.Focus();
                }
            }
            else
            {
                _veiculoId = null;
                TxtVeiculoOrdemCadastrar.Text = string.Empty;
                LstSugestoesVeiculos.DataSource = null;
                LstSugestoesVeiculos.Visible = false;
            }
        }
    }

    private async void LstSugestoesClientes_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (LstSugestoesClientes.SelectedItem is ClienteViewModel clienteSelecionado)
            {
                _isUpdatingText = true;
                TxtClienteOrdemCadastrar.Text = clienteSelecionado.NomeSobrenome;
                _isUpdatingText = false;
                LstSugestoesClientes.Visible = false;
                _clienteId = clienteSelecionado.ClienteId;

                if (clienteSelecionado.Veiculos != null && clienteSelecionado.Veiculos.Any())
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var veiculoService = scope.ServiceProvider.GetRequiredService<IVeiculoService>();
                        var veiculos = await veiculoService.GetVeiculosAsync(v => v.ClienteId == _clienteId);

                        LstSugestoesVeiculos.DataSource = veiculos.ToList();
                        LstSugestoesVeiculos.DisplayMember = "ModeloMatricula";
                        LstSugestoesVeiculos.ValueMember = "VeiculoId";
                        AdjustListBoxSize(LstSugestoesVeiculos);
                        LstSugestoesVeiculos.Visible = veiculos.Any();
                        LstSugestoesVeiculos.Focus();
                    }
                }
                else
                {
                    TxtVeiculoOrdemCadastrar.Text = string.Empty;
                    LstSugestoesVeiculos.DataSource = null;
                    LstSugestoesVeiculos.Visible = false;
                    _veiculoId = null;
                }
            }

            e.Handled = true;
        }
    }

    private void AdjustListBoxSize(ListBox listBox)
    {
        if (listBox.Items.Count == 0)
        {
            listBox.Visible = false;
            return;
        }

        int maxVisibleItems = 5;
        int itemHeight = listBox.ItemHeight;
        int borderHeight = 2;
        int padding = 4;

        int visibleItems = Math.Min(listBox.Items.Count, maxVisibleItems);
        listBox.Height = (itemHeight * visibleItems) + borderHeight + padding;

        listBox.Visible = true;
    }

    private void FormCadastrarOrdem_Load(object sender, EventArgs e)
    {
        LstSugestoesClientes.Visible = false;
        LstSugestoesVeiculos.Visible = false;
        LstSugestoesClientes.Width = 208;
        LstSugestoesVeiculos.Width = 156;
        LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
        DateTimePickerEstimativaConclusao.MinDate = DateTime.Now;
    }

    private void BtnNovoClienteOrdemCadastrar_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        var result = frmCadastrarCliente.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarCliente.NomeSobrenomeClienteCadastrado))
        {
            TxtClienteOrdemCadastrar.Text = frmCadastrarCliente.NomeSobrenomeClienteCadastrado;
        }
    }

    private void BtnNovoVeiculoOrdemCadastrar_Click(object sender, EventArgs e)
    {
        var frmCadastrarVeiculo = _serviceProvider.GetRequiredService<FormCadastrarVeiculo>();
        frmCadastrarVeiculo.NomeCliente = TxtClienteOrdemCadastrar.Text;
        frmCadastrarVeiculo.MatriculaParaCadastro = TxtVeiculoOrdemCadastrar.Text;
        var result = frmCadastrarVeiculo.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarVeiculo.MatriculaVeiculoCadastrado))
        {
            TxtVeiculoOrdemCadastrar.Text = string.Empty;
            TxtVeiculoOrdemCadastrar.Text = frmCadastrarVeiculo.MatriculaVeiculoCadastrado;
        }
    }

    private void BtnNovoOrcamentoOrdemCadastrar_Click(object sender, EventArgs e)
    {
        var frmCadastrarOrcamento = _serviceProvider.GetRequiredService<FormCadastrarOrcamento>();
        var result = frmCadastrarOrcamento.ShowDialog();

        if (result == DialogResult.OK && frmCadastrarOrcamento.OrcamentoAtual != null)
        {
            var orcamentoAtual = frmCadastrarOrcamento.OrcamentoAtual;
            orcamentoAtual.Numero = _orcamentos.Count() + 1;

            _orcamentos.Add(orcamentoAtual);

            MessageBox.Show("Orçamento cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
        }
        else
            MessageBox.Show("Orçamento não cadastrado, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem()
    {
        DgvOrcamentosCadastrarOrdem.DataSource = null;
        DgvOrcamentosCadastrarOrdem.DataSource = _orcamentos.ToList();
        DgvOrcamentosCadastrarOrdem.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosCadastrarOrdem.Columns["OrdemDeServicoId"].Visible = false;
        DgvOrcamentosCadastrarOrdem.Columns["StatusOrcamento"].Visible = true; // converter para texto futuramente
        DgvOrcamentosCadastrarOrdem.Columns["OrdemDeServico"].Visible = false;
        DgvOrcamentosCadastrarOrdem.Columns["ItensOrcamento"].Visible = false;
        DgvOrcamentosCadastrarOrdem.Columns["StatusOrcamento"].Visible = false;
        DgvOrcamentosCadastrarOrdem.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastrarOrdem.Columns["CustoTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastrarOrdem.Columns["LucroTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastrarOrdem.Columns["Numero"].HeaderText = "Número";
        DgvOrcamentosCadastrarOrdem.Columns["DataCriacao"].HeaderText = "Data de criação";
        DgvOrcamentosCadastrarOrdem.Columns["Descricao"].HeaderText = "Descrição";
        DgvOrcamentosCadastrarOrdem.Columns["NumeroDeItens"].HeaderText = "Itens";
        DgvOrcamentosCadastrarOrdem.Columns["CustoTotal"].HeaderText = "Custo";
        DgvOrcamentosCadastrarOrdem.Columns["ValorTotal"].HeaderText = "Valor";
        DgvOrcamentosCadastrarOrdem.Columns["LucroTotal"].HeaderText = "Lucro";
        DgvOrcamentosCadastrarOrdem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosCadastrarOrdem.MultiSelect = false;
    }

    private void DateTimePickerEstimativaConclusao_ValueChanged(object sender, EventArgs e)
    {
        var dataAtual = DateTime.Now;

        if (DateTimePickerEstimativaConclusao.Value < dataAtual)
        {
            MessageBox.Show("A data e hora selecionadas não podem ser anteriores à data e hora atuais.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

            DateTimePickerEstimativaConclusao.Value = dataAtual;
        }
    }

    private void TxtVeiculoOrdemCadastrar_TextChanged(object sender, EventArgs e)
    {
        _veiculoId = null;
        if (_isUpdatingText) return;

        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = GlobalConfiguration.debounceTimeMiliseconds };
        _debounceTimer.Tick += async (s, ev) =>
        {
            _debounceTimer.Stop();

            try
            {
                string searchText = TxtVeiculoOrdemCadastrar.Text.Trim();

                if (searchText.Length >= 2)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var veiculoService = scope.ServiceProvider.GetRequiredService<IVeiculoService>();
                        var veiculos = await veiculoService.GetVeiculosAsync(v => v.Matricula.Contains(searchText) || v.Modelo.Contains(searchText) || v.Marca.Contains(searchText));

                        LstSugestoesVeiculos.DataSource = veiculos.ToList();
                        LstSugestoesVeiculos.DisplayMember = "ModeloMatricula";
                        LstSugestoesVeiculos.ValueMember = "VeiculoId";
                        AdjustListBoxSize(LstSugestoesVeiculos);
                        LstSugestoesVeiculos.Visible = veiculos.Any();
                        LstSugestoesVeiculos.Focus();
                        _veiculoId = (long?)LstSugestoesVeiculos.SelectedValue;
                    }
                }
                else
                {

                    LstSugestoesVeiculos.DataSource = null;
                    LstSugestoesVeiculos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        _debounceTimer.Start();
    }

    private void LstSugestoesVeiculos_Click(object sender, EventArgs e)
    {
        if (LstSugestoesVeiculos.SelectedItem is VeiculoViewModel veiculoSelecionado)
        {
            if (_clienteId != null && veiculoSelecionado.ClienteId != _clienteId)
            {
                var dialog = MessageBox.Show("O veículo selecionado não pertence ao cliente escolhido. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.No)
                {
                    TxtVeiculoOrdemCadastrar.Text = string.Empty;
                    _veiculoId = null;
                    return;
                }
            }

            if (_clienteId == null && veiculoSelecionado.Cliente != null)
            {
                _clienteId = veiculoSelecionado.ClienteId;
                _isUpdatingText = true;
                TxtClienteOrdemCadastrar.Text = $"{veiculoSelecionado.Cliente.Nome} {veiculoSelecionado.Cliente.Sobrenome}";
                _isUpdatingText = false;

            }

            _isUpdatingText = true;
            TxtVeiculoOrdemCadastrar.Text = veiculoSelecionado.ModeloMatricula;
            _isUpdatingText = false;
            LstSugestoesVeiculos.Visible = false;
            _veiculoId = veiculoSelecionado.VeiculoId;
        }
    }

    private void LstSugestoesVeiculos_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (LstSugestoesVeiculos.SelectedItem is VeiculoViewModel veiculoSelecionado)
            {
                if (_clienteId != null && veiculoSelecionado.ClienteId != _clienteId)
                {
                    var dialog = MessageBox.Show("O veículo selecionado não pertence ao cliente escolhido. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.No)
                    {
                        TxtVeiculoOrdemCadastrar.Text = string.Empty;
                        _veiculoId = null;
                        return;
                    }
                }

                if (_clienteId == null && veiculoSelecionado.Cliente != null)
                {
                    _clienteId = veiculoSelecionado.ClienteId;
                    _isUpdatingText = true;
                    TxtClienteOrdemCadastrar.Text = $"{veiculoSelecionado.Cliente.Nome} {veiculoSelecionado.Cliente.Sobrenome}";
                    _isUpdatingText = false;

                }

                _isUpdatingText = true;
                TxtVeiculoOrdemCadastrar.Text = veiculoSelecionado.ModeloMatricula;
                _isUpdatingText = false;
                LstSugestoesVeiculos.Visible = false;
                _veiculoId = veiculoSelecionado.VeiculoId;
            }
        }
    }

    private void TxtVeiculoOrdemCadastrar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }

    private void BtnEditarOrcamentoOrdemCadastrar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosCadastrarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosCadastrarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                var frmCadastrarOrcamento = _serviceProvider.GetRequiredService<FormAtualizarOrcamento>();
                frmCadastrarOrcamento.OrcamentoAtual = orcamentoSelecionado;

                var result = frmCadastrarOrcamento.ShowDialog();

                if (result == DialogResult.OK && frmCadastrarOrcamento.OrcamentoAtual != null)
                {
                    orcamentoSelecionado.StatusOrcamento = frmCadastrarOrcamento.OrcamentoAtual.StatusOrcamento;
                    orcamentoSelecionado.Descricao = frmCadastrarOrcamento.OrcamentoAtual.Descricao;
                    orcamentoSelecionado.ItensOrcamento = frmCadastrarOrcamento._items.ToList();

                    MessageBox.Show("Orçamento alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("As alterações no orçamento não foram salvas!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnExcluirOrcamentoOrdemCadastrar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosCadastrarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosCadastrarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                _orcamentos.Remove(orcamentoSelecionado);

                int novoNumero = 1;
                foreach (var orcamento in _orcamentos.OrderBy(o => o.Numero))
                {
                    orcamento.Numero = novoNumero++;
                }

                MessageBox.Show("Orçamento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
            }
            else
                MessageBox.Show("Erro ao excluir orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnAprovarOrcamentoOrdemCadastrar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosCadastrarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosCadastrarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                orcamentoSelecionado.StatusOrcamento = 2;

                MessageBox.Show("Orçamento aprovado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
            }
            else
                MessageBox.Show("Erro ao aprovar orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para aprovar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnReprovarOrcamentoOrdemCadastrar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosCadastrarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosCadastrarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                orcamentoSelecionado.StatusOrcamento = 3;

                MessageBox.Show("Orçamento reprovado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
            }
            else
                MessageBox.Show("Erro ao reprovar orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para reprovar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

