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

public partial class FormAtualizarOrdem : Form
{
    private readonly IOrdemDeServicoService _ordemService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private bool _isUpdatingText = false;
    private long? _clienteId = null;
    private long? _veiculoId = null;
    private ICollection<OrcamentoViewModel> _orcamentos = [];

    public FormAtualizarOrdem(IOrdemDeServicoService ordemService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _ordemService = ordemService;
        _serviceProvider = serviceProvider;
    }

    public OrdemDeServicoViewModel OrdemDeServicoAtual {  get; set; }

    private async void BtnGerarOrdem_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            BtnGerarOrdemAtualizar.Enabled = false;

            var ordemConverted = new OrdemDeServicoViewModel
            {
                StatusOrdemDeServicoId = !_orcamentos.Any() ? 1 : _orcamentos.Any(o => o.StatusOrcamento == 1 || o.StatusOrcamento == 3) ? 2 : _orcamentos.All(o => o.StatusOrcamento == 2) ? 3 : 1,
                ClienteId = _clienteId,
                VeiculoId = _veiculoId,
                Descricao = RTxtDescricaoOrdemAtualizar.Text.Trim(),
                EstimativaConclusao = DateTimePickerEstimativaConclusao.Value,
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

            MessageBox.Show("Ordem de serviço alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao alterar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao alterar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao alterar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnGerarOrdemAtualizar.Enabled = true;
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(TxtVeiculoOrdemAtualizar.Text) || _veiculoId == null)
        {
            MessageBox.Show("Selecione um veículo para abrir a ordem de serviço.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        if (String.IsNullOrWhiteSpace(RTxtDescricaoOrdemAtualizar.Text))
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

        if (String.IsNullOrWhiteSpace(TxtClienteOrdemAtualizar.Text))
        {
            var dialog = MessageBox.Show("Tem certeza que deseja continuar sem selecionar um cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;

        }

        if (!_orcamentos.Any())
        {
            var dialog = MessageBox.Show("Tem certeza que deseja continuar sem alterar um orçamento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
                string searchText = TxtClienteOrdemAtualizar.Text.Trim();

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
                    TxtVeiculoOrdemAtualizar.Text = string.Empty;
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
            TxtClienteOrdemAtualizar.Text = clienteSelecionado.NomeSobrenome;
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
                TxtVeiculoOrdemAtualizar.Text = string.Empty;
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
                TxtClienteOrdemAtualizar.Text = clienteSelecionado.NomeSobrenome;
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
                    TxtVeiculoOrdemAtualizar.Text = string.Empty;
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

    private void FormAtualizarOrdem_Load(object sender, EventArgs e)
    {
        LstSugestoesClientes.Visible = false;
        LstSugestoesVeiculos.Visible = false;
        LstSugestoesClientes.Width = 208;
        LstSugestoesVeiculos.Width = 156;
        LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
        DateTimePickerEstimativaConclusao.MinDate = DateTime.Now;
    }

    private void BtnNovoClienteOrdemAtualizar_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        var result = frmCadastrarCliente.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarCliente.NomeSobrenomeClienteCadastrado))
        {
            TxtClienteOrdemAtualizar.Text = frmCadastrarCliente.NomeSobrenomeClienteCadastrado;
        }
    }

    private void BtnNovoVeiculoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        var frmAtualizarVeiculo = _serviceProvider.GetRequiredService<FormCadastrarVeiculo>();
        frmAtualizarVeiculo.NomeCliente = TxtClienteOrdemAtualizar.Text;
        frmAtualizarVeiculo.MatriculaParaCadastro = TxtVeiculoOrdemAtualizar.Text;
        var result = frmAtualizarVeiculo.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmAtualizarVeiculo.MatriculaVeiculoCadastrado))
        {
            TxtVeiculoOrdemAtualizar.Text = string.Empty;
            TxtVeiculoOrdemAtualizar.Text = frmAtualizarVeiculo.MatriculaVeiculoCadastrado;
        }
    }

    private void BtnNovoOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        var frmAtualizarOrcamento = _serviceProvider.GetRequiredService<FormAtualizarOrcamento>();
        var result = frmAtualizarOrcamento.ShowDialog();

        if (result == DialogResult.OK && frmAtualizarOrcamento.OrcamentoAtual != null)
        {
            var orcamentoAtual = frmAtualizarOrcamento.OrcamentoAtual;
            orcamentoAtual.Numero = _orcamentos.Count() + 1;

            _orcamentos.Add(orcamentoAtual);

            MessageBox.Show("Orçamento alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
        }
        else
            MessageBox.Show("Orçamento não alterado, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem()
    {
        DgvOrcamentosAtualizarOrdem.DataSource = null;
        DgvOrcamentosAtualizarOrdem.DataSource = _orcamentos.ToList();
        DgvOrcamentosAtualizarOrdem.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["OrdemDeServicoId"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["StatusOrcamento"].Visible = true; // converter para texto futuramente
        DgvOrcamentosAtualizarOrdem.Columns["OrdemDeServico"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["ItensOrcamento"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["StatusOrcamento"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["ValorTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizarOrdem.Columns["CustoTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizarOrdem.Columns["LucroTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizarOrdem.Columns["Numero"].HeaderText = "Número";
        DgvOrcamentosAtualizarOrdem.Columns["DataCriacao"].HeaderText = "Data de criação";
        DgvOrcamentosAtualizarOrdem.Columns["Descricao"].HeaderText = "Descrição";
        DgvOrcamentosAtualizarOrdem.Columns["NumeroDeItens"].HeaderText = "Itens";
        DgvOrcamentosAtualizarOrdem.Columns["CustoTotal"].HeaderText = "Custo";
        DgvOrcamentosAtualizarOrdem.Columns["ValorTotal"].HeaderText = "Valor";
        DgvOrcamentosAtualizarOrdem.Columns["LucroTotal"].HeaderText = "Lucro";
        DgvOrcamentosAtualizarOrdem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosAtualizarOrdem.MultiSelect = false;
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

    private void TxtVeiculoOrdemAtualizar_TextChanged(object sender, EventArgs e)
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
                string searchText = TxtVeiculoOrdemAtualizar.Text.Trim();

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
                    TxtVeiculoOrdemAtualizar.Text = string.Empty;
                    _veiculoId = null;
                    return;
                }
            }

            if (_clienteId == null && veiculoSelecionado.Cliente != null)
            {
                _clienteId = veiculoSelecionado.ClienteId;
                _isUpdatingText = true;
                TxtClienteOrdemAtualizar.Text = $"{veiculoSelecionado.Cliente.Nome} {veiculoSelecionado.Cliente.Sobrenome}";
                _isUpdatingText = false;

            }

            _isUpdatingText = true;
            TxtVeiculoOrdemAtualizar.Text = veiculoSelecionado.ModeloMatricula;
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
                        TxtVeiculoOrdemAtualizar.Text = string.Empty;
                        _veiculoId = null;
                        return;
                    }
                }

                if (_clienteId == null && veiculoSelecionado.Cliente != null)
                {
                    _clienteId = veiculoSelecionado.ClienteId;
                    _isUpdatingText = true;
                    TxtClienteOrdemAtualizar.Text = $"{veiculoSelecionado.Cliente.Nome} {veiculoSelecionado.Cliente.Sobrenome}";
                    _isUpdatingText = false;

                }

                _isUpdatingText = true;
                TxtVeiculoOrdemAtualizar.Text = veiculoSelecionado.ModeloMatricula;
                _isUpdatingText = false;
                LstSugestoesVeiculos.Visible = false;
                _veiculoId = veiculoSelecionado.VeiculoId;
            }
        }
    }

    private void TxtVeiculoOrdemAtualizar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }

    private void BtnEditarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                var frmAtualizarOrcamento = _serviceProvider.GetRequiredService<FormAtualizarOrcamento>();
                frmAtualizarOrcamento.OrcamentoAtual = orcamentoSelecionado;

                var result = frmAtualizarOrcamento.ShowDialog();

                if (result == DialogResult.OK && frmAtualizarOrcamento.OrcamentoAtual != null)
                {
                    orcamentoSelecionado.StatusOrcamento = frmAtualizarOrcamento.OrcamentoAtual.StatusOrcamento;
                    orcamentoSelecionado.Descricao = frmAtualizarOrcamento.OrcamentoAtual.Descricao;
                    orcamentoSelecionado.ItensOrcamento = frmAtualizarOrcamento._items.ToList();

                    MessageBox.Show("Orçamento alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
                }
                else
                    MessageBox.Show("As alterações no orçamento não foram salvas, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnExcluirOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                _orcamentos.Remove(orcamentoSelecionado);

                MessageBox.Show("Orçamento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
            }
            else
                MessageBox.Show("Erro ao excluir orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnAprovarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                orcamentoSelecionado.StatusOrcamento = 2;

                MessageBox.Show("Orçamento aprovado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
            }
            else
                MessageBox.Show("Erro ao aprovar orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para aprovar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnReprovarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                orcamentoSelecionado.StatusOrcamento = 3;

                MessageBox.Show("Orçamento reprovado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
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

