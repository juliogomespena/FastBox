using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormCadastrarVeiculo : Form
{
    private readonly IVeiculoService _veiculoService;
    private readonly IClienteService _clienteService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;

    public FormCadastrarVeiculo(IVeiculoService veiculoService, IClienteService clienteService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _veiculoService = veiculoService;
        _clienteService = clienteService;
        _serviceProvider = serviceProvider;
    }

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

            var veiculo = new Veiculo
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

    private void TxtMskMatricula_TextChanged(object sender, EventArgs e)
    {
        var regex = new Regex(@"^([A-Z]{2}-\d{2}-\d{2}|\d{2}-\d{2}-[A-Z]{2}|\d{2}-[A-Z]{2}-\d{2}|[A-Z]{2}-\d{2}-[A-Z]{2}|\d{2}-[A-Z]{2}-[A-Z]{2})$");
        if (regex.IsMatch(TxtMskMatricula.Text))
            LblInfoMatricula.Text = "OK!";
        else
            LblInfoMatricula.Text = "Inválido!";
    }

    private async void TxtCliente_TextChanged(object sender, EventArgs e)
    {
        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = 650 };
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
                        DgvVeiculosClientes.Columns["OrdensDeServico"].Visible = false;
                        DgvVeiculosClientes.Columns["Veiculos"].Visible = false;
                        DgvVeiculosClientes.Columns["DataCadastro"].Visible = false;
                        DgvVeiculosClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        DgvVeiculosClientes.MultiSelect = false;
                    }
                }
                else
                {
                    DgvVeiculosClientes.DataSource = null;
                }
            }
            catch (OperationCanceledException)
            {
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
        if (TxtMskMatricula.Text.Length != 8 || LblInfoMatricula.Text == "Inválido!")
        {
            MessageBox.Show("Digite uma matrícula válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private void BtnNovoCliente_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        frmCadastrarCliente.ShowDialog();
    }

    private void DgvVeiculosClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 5)
        {
            string emailValue = e.Value?.ToString();

            if (string.IsNullOrEmpty(emailValue))
            {
                e.Value = "Não cadastrado";
                e.FormattingApplied = true;
            }
        }
    }
}
