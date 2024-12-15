using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastBox.UI.Forms;

public partial class FormCadastrarVeiculo : Form
{
    private readonly IVeiculoService _veiculoService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private bool _isUpdatingText = false;

    public FormCadastrarVeiculo(IVeiculoService veiculoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _veiculoService = veiculoService;
        _serviceProvider = serviceProvider;
    }

    public string MatriculaVeiculoCadastrado { get; private set; }
    public string NomeCliente { get; set; }

    public string MatriculaParaCadastro { get; set; }

    private async void BtnCadastrarVeiculo_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        bool clienteFlag = true;

        if (DgvVeiculosClientes.SelectedRows.Count < 1)
        {
            var dialog = MessageBox.Show("Tem certeza que deseja continuar sem selecionar um cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return;

            clienteFlag = false;
        }
        try
        {
            BtnCadastrarVeiculo.Enabled = false;
            long? clienteId = clienteFlag ? (long)DgvVeiculosClientes.SelectedRows[0].Cells["ClienteId"].Value : null;

            var veiculo = new VeiculoViewModel
            {
                ClienteId = clienteId,
                Marca = TxtMarca.Text.Trim(),
                Modelo = TxtModelo.Text.Trim(),
                Ano = int.TryParse(TxtMskAno.Text.Trim(), out int anoCarro) ? anoCarro : 0,
                Matricula = TxtMskMatricula.Text.Trim(),
                Observacoes = RTxtObservacoes.Text.Trim(),
            };

            await _veiculoService.AddVeiculoAsync(veiculo);

            MessageBox.Show("Veículo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MatriculaVeiculoCadastrado = veiculo.Matricula;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao cadastrar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao cadastrar veículo: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao cadastrar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnCadastrarVeiculo.Enabled = true;
        }
    }

    private async void TxtCliente_TextChanged(object sender, EventArgs e)
    {
        if (_isUpdatingText)
            return;

        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = GlobalConfiguration.debounceTimeMiliseconds };
        _debounceTimer.Tick += async (s, ev) =>
        {
            _debounceTimer.Stop();

            try
            {
                string searchText = TxtCliente.Text.Trim();

                if (searchText.Length >= 2)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var clienteService = scope.ServiceProvider.GetRequiredService<IClienteService>();
                        var clientes = await clienteService.GetClientsByNameAsync(searchText);
                        DgvVeiculosClientes.DataSource = clientes.ToList();
                        DgvVeiculosClientes.Columns["EnderecoResumido"].Visible = false;
                        DgvVeiculosClientes.Columns["EnderecoCompleto"].Visible = false;
                        DgvVeiculosClientes.Columns["DataCadastro"].Visible = false;
                        DgvVeiculosClientes.Columns["OrdemDeServicos"].Visible = false;
                        DgvVeiculosClientes.Columns["Veiculos"].Visible = false;
                        DgvVeiculosClientes.Columns["EnderecoId"].Visible = false;
                        DgvVeiculosClientes.Columns["Endereco"].Visible = false;
                        DgvVeiculosClientes.Columns["Usuarios"].Visible = false;
                        DgvVeiculosClientes.Columns["VeiculosCount"].Visible = false;
                        DgvVeiculosClientes.Columns["OrdensDeServicoCount"].Visible = false;
                        DgvVeiculosClientes.Columns["Nome"].Visible = false;
                        DgvVeiculosClientes.Columns["Sobrenome"].Visible = false;
                        DgvVeiculosClientes.Columns["NomeSobrenome"].HeaderText = "Nome";
                        DgvVeiculosClientes.Columns["ClienteId"].HeaderText = "Id";
                        DgvVeiculosClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        DgvVeiculosClientes.MultiSelect = false;
                        DgvVeiculosClientes.Rows[0].Selected = true;
                        DgvVeiculosClientes.Focus();
                    }
                }
                else
                {
                    DgvVeiculosClientes.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        _debounceTimer.Start();
    }

    private void TxtMskMatricula_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(TxtMarca.Text))
        {
            MessageBox.Show("Digite uma marca para o veiculo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtModelo.Text))
        {
            MessageBox.Show("Digite um modelo para o veiculo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (TxtMskAno.Text.Length != 4 || (int.TryParse(TxtMskAno.Text, out int anoCarro) && (anoCarro < 1950 || anoCarro > 2050)))
        {
            MessageBox.Show("Digite um ano válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtMskMatricula.Text))
        {
            MessageBox.Show("Digite uma matrícula para o veículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void BtnNovoCliente_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        frmCadastrarCliente.ShowDialog();
        TxtCliente.Text = "";
    }

    private void DgvVeiculosClientes_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            var row = DgvVeiculosClientes.Rows[e.RowIndex];

            if (row.Cells["NomeSobrenome"] != null && row.Cells["NomeSobrenome"].Value != null)
            {
                _isUpdatingText = true;
                TxtCliente.Text = row.Cells["NomeSobrenome"].Value.ToString();
                _isUpdatingText = false;
            }
        }
    }

    private void FormCadastrarVeiculo_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(NomeCliente))
            TxtCliente.Text = NomeCliente;
        if (!String.IsNullOrEmpty(MatriculaParaCadastro))
            TxtMskMatricula.Text = MatriculaParaCadastro;
    }
}
