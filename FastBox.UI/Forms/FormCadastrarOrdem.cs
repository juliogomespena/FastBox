using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.ComponentModel;
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
            BtnGerarOrdemCadastro.Enabled = false;

            var ordemConverted = new OrdemDeServicoViewModel
            {
                StatusOrdemDeServicoId = !_orcamentos.Any() ? 1 : _orcamentos.Any(o => o.StatusOrcamento == 1) ? 2 : _orcamentos.All(o => o.StatusOrcamento == 2 || o.StatusOrcamento == 3) ? 3 : 1,
                ClienteId = _clienteId,
                VeiculoId = _veiculoId,
                Descricao = RTxtDescricaoOrdemCadastro.Text.Trim(),
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
            BtnGerarOrdemCadastro.Enabled = true;
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(TxtVeiculoOrdemCadastro.Text) || _veiculoId == null)
        {
            MessageBox.Show("Selecione um veículo para abrir a ordem de serviço.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return false;
        }

        if (String.IsNullOrWhiteSpace(RTxtDescricaoOrdemCadastro.Text))
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

        if (String.IsNullOrWhiteSpace(TxtClienteOrdemCadastro.Text))
        {
            var dialog = MessageBox.Show("Tem certeza que deseja continuar sem selecionar um cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;

        }

        if (!_orcamentos.Any())
        {
            var dialog = MessageBox.Show("Tem certeza que deseja continuar sem cadastrar um orçamento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;
        }

        return true;
    }

    private void TxtClienteOrdem_TextChanged(object sender, EventArgs e)
    {
        _clienteId = null;
        if (_isUpdatingText) return;

        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = 650 };
        _debounceTimer.Tick += async (s, ev) =>
        {
            _debounceTimer.Stop();

            try
            {
                string searchText = TxtClienteOrdemCadastro.Text.Trim();

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
                    TxtVeiculoOrdemCadastro.Text = string.Empty;
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
            TxtClienteOrdemCadastro.Text = clienteSelecionado.NomeSobrenome;
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
                TxtVeiculoOrdemCadastro.Text = string.Empty;
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
                TxtClienteOrdemCadastro.Text = clienteSelecionado.NomeSobrenome;
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
                    TxtVeiculoOrdemCadastro.Text = string.Empty;
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

    private void BtnNovoClienteOrdemCadastro_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        var result = frmCadastrarCliente.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarCliente.NomeSobrenomeClienteCadastrado))
        {
            TxtClienteOrdemCadastro.Text = frmCadastrarCliente.NomeSobrenomeClienteCadastrado;
        }
    }

    private void BtnNovoVeiculoOrdemCadastro_Click(object sender, EventArgs e)
    {
        var frmCadastrarVeiculo = _serviceProvider.GetRequiredService<FormCadastrarVeiculo>();
        frmCadastrarVeiculo.NomeCliente = TxtClienteOrdemCadastro.Text;
        frmCadastrarVeiculo.MatriculaParaCadastro = TxtVeiculoOrdemCadastro.Text;
        var result = frmCadastrarVeiculo.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarVeiculo.MatriculaVeiculoCadastrado))
        {
            TxtVeiculoOrdemCadastro.Text = string.Empty;
            TxtVeiculoOrdemCadastro.Text = frmCadastrarVeiculo.MatriculaVeiculoCadastrado;
        }
    }

    private void BtnNovoOrcamentoOrdemCadastro_Click(object sender, EventArgs e)
    {
        var frmCadastrarOrcamento = _serviceProvider.GetRequiredService<FormCadastrarOrcamento>();
        var result = frmCadastrarOrcamento.ShowDialog();

        if (result == DialogResult.OK && frmCadastrarOrcamento.OrcamentoAtual != null)
        {
            var orcamentoAtual = frmCadastrarOrcamento.OrcamentoAtual;
            orcamentoAtual.Numero = _orcamentos.Count() + 1;

            _orcamentos.Add(orcamentoAtual);

            MessageBox.Show("Orçamento adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadOrcamentosIntoDgvOrcamentosCadastrarOrdem();
        }
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
        DgvOrcamentosCadastrarOrdem.Columns["ValorTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosCadastrarOrdem.Columns["CustoTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosCadastrarOrdem.Columns["LucroTotal"].DefaultCellStyle.Format = "F2";
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

    private void TxtVeiculoOrdemCadastro_TextChanged(object sender, EventArgs e)
    {
        _veiculoId = null;
        if (_isUpdatingText) return;

        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = 650 };
        _debounceTimer.Tick += async (s, ev) =>
        {
            _debounceTimer.Stop();

            try
            {
                string searchText = TxtVeiculoOrdemCadastro.Text.Trim();

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
                    TxtVeiculoOrdemCadastro.Text = string.Empty;
                    _veiculoId = null;
                    return;
                }
            }

            _isUpdatingText = true;
            TxtVeiculoOrdemCadastro.Text = $"{veiculoSelecionado.ModeloMatricula}";
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
                        TxtVeiculoOrdemCadastro.Text = string.Empty;
                        _veiculoId = null;
                        return;
                    }
                }

                _isUpdatingText = true;
                TxtVeiculoOrdemCadastro.Text = $"{veiculoSelecionado.ModeloMatricula}";
                _isUpdatingText = false;
                LstSugestoesVeiculos.Visible = false;
                _veiculoId = veiculoSelecionado.VeiculoId;
            }
        }
    }

    private void TxtVeiculoOrdemCadastro_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}

