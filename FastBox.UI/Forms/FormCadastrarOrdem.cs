using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.ComponentModel;
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

    public FormCadastrarOrdem(IOrdemDeServicoService ordemService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _ordemService = ordemService;
        _serviceProvider = serviceProvider;
    }

    private async void BtnGerarOrdem_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"ClienteId: {_clienteId}\nVeiculoId : {_veiculoId}");
        //if (!CheckFields())
        //    return;

        //bool clienteFlag = true;

        //if (DgvOrdensClientes.SelectedRows.Count < 1)
        //{
        //    var dialog = MessageBox.Show("Tem certeza que deseja continuar sem selecionar um cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

        //    if (dialog == DialogResult.No)
        //        return;

        //    clienteFlag = false;
        //}
        //try
        //{
        //    BtnCadastrarOrdem.Enabled = false;
        //    long? clienteId = clienteFlag ? (long)DgvOrdensClientes.SelectedRows[0].Cells["ClienteId"].Value : null;

        //    var ordem = new OrdemDeServicoViewModel
        //    {
        //        ClienteId = clienteId,
        //        Marca = TxtMarca.Text.Trim(),
        //        Modelo = TxtModelo.Text.Trim(),
        //        Ano = int.TryParse(TxtMskAno.Text.Trim(), out int anoCarro) ? anoCarro : 0,
        //        Matricula = TxtMskMatricula.Text.Trim(),
        //        Observacoes = RTxtObservacoes.Text.Trim(),
        //    };

        //    await _ordemService.AddOrdemAsync(ordem);

        //    MessageBox.Show("Veículo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    this.Close();
        //}
        //catch (DbUpdateException ex)
        //{
        //    if (ex.InnerException == null)
        //        MessageBox.Show($"Erro ao cadastrar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    else
        //        MessageBox.Show($"Erro ao cadastrar veículo: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //catch (Exception ex)
        //{

        //    MessageBox.Show($"Erro ao cadastrar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //finally
        //{
        //    BtnCadastrarOrdem.Enabled = true;
        //}
    }

    private bool CheckFields()
    {
        //if (String.IsNullOrWhiteSpace(TxtMarca.Text))
        //{
        //    MessageBox.Show("Digite uma marca para o ordem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    return false;
        //}
        //if (String.IsNullOrWhiteSpace(TxtModelo.Text))
        //{
        //    MessageBox.Show("Digite um modelo para o ordem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    return false;
        //}
        //if (TxtMskAno.Text.Length != 4 || (int.TryParse(TxtMskAno.Text, out int anoCarro) && (anoCarro < 1950 || anoCarro > 2050)))
        //{
        //    MessageBox.Show("Digite um ano válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    return false;
        //}
        //if (TxtMskMatricula.Text.Length != 8 || LblInfoMatricula.Text == "Inválido!")
        //{
        //    MessageBox.Show("Digite uma matrícula válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    return false;
        //}
        return true;
    }

    private void TxtClienteOrdem_TextChanged(object sender, EventArgs e)
    {
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
                        AdjustListBoxSize();
                        LstSugestoesClientes.Visible = clientes.Any();
                        LstSugestoesClientes.Focus();
                    }
                }
                else
                {

                    LstSugestoesClientes.DataSource = null;
                    LstSugestoesClientes.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        _debounceTimer.Start();
    }

    private void LstSugestoesClientes_Click(object sender, EventArgs e)
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
                CmbVeiculosOrdemCadastro.DataSource = clienteSelecionado.Veiculos.ToList();
                CmbVeiculosOrdemCadastro.DisplayMember = "Matricula";
                CmbVeiculosOrdemCadastro.ValueMember = "VeiculoId";
                CmbVeiculosOrdemCadastro.SelectedIndex = 0;
                _veiculoId = (long?)CmbVeiculosOrdemCadastro.SelectedValue;
            }
            else
            {
                CmbVeiculosOrdemCadastro.DataSource = null;
                CmbVeiculosOrdemCadastro.Items.Clear();
                CmbVeiculosOrdemCadastro.Items.Add("Não cadastrado");
                CmbVeiculosOrdemCadastro.SelectedIndex = 0;
                _veiculoId = null;
            }
        }
    }

    private void LstSugestoesClientes_KeyDown(object sender, KeyEventArgs e)
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
                    CmbVeiculosOrdemCadastro.DataSource = clienteSelecionado.Veiculos.ToList();
                    CmbVeiculosOrdemCadastro.DisplayMember = "Matricula";
                    CmbVeiculosOrdemCadastro.ValueMember = "VeiculoId";
                    CmbVeiculosOrdemCadastro.SelectedIndex = 0;
                    _veiculoId = (long?)CmbVeiculosOrdemCadastro.SelectedValue;
                }
                else
                {
                    CmbVeiculosOrdemCadastro.DataSource = null;
                    CmbVeiculosOrdemCadastro.Items.Clear();
                    CmbVeiculosOrdemCadastro.Items.Add("Não cadastrado");
                    CmbVeiculosOrdemCadastro.SelectedIndex = 0;
                    _veiculoId = null;
                }
            }

            e.Handled = true;
        }
    }

    private void AdjustListBoxSize()
    {
        if (LstSugestoesClientes.Items.Count == 0)
        {
            LstSugestoesClientes.Visible = false;
            return;
        }

        int maxVisibleItems = 5;
        int itemHeight = LstSugestoesClientes.ItemHeight;
        int borderHeight = 2;
        int padding = 4;

        int visibleItems = Math.Min(LstSugestoesClientes.Items.Count, maxVisibleItems);
        LstSugestoesClientes.Height = (itemHeight * visibleItems) + borderHeight + padding;

        LstSugestoesClientes.Visible = true;
    }

    private void CmbVeiculos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CmbVeiculosOrdemCadastro.SelectedValue != null && long.TryParse(CmbVeiculosOrdemCadastro.SelectedValue.ToString(), out long veiculoId))
            _veiculoId = veiculoId;
        else
            _veiculoId = null;

    }

    private void FormCadastrarOrdem_Load(object sender, EventArgs e)
    {
        LstSugestoesClientes.Width = 208;
    }

    private void BtnNovoClienteOrdemCadastro_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        frmCadastrarCliente.ShowDialog();
        TxtClienteOrdemCadastro.Text = "";
    }

    private void BtnNovoVeiculoOrdemCadastro_Click(object sender, EventArgs e)
    {
        var frmCadastrarVeiculo = _serviceProvider.GetRequiredService<FormCadastrarVeiculo>();
        frmCadastrarVeiculo.ShowDialog();
    }

    private void BtnNovoOrcamentoOrdemCadastro_Click(object sender, EventArgs e)
    {
        var frmCadastrarOrcamento = _serviceProvider.GetRequiredService<FormCadastrarOrcamento>();
        frmCadastrarOrcamento.ShowDialog();
    }
}
