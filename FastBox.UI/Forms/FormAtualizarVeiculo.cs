using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastBox.UI.Forms;

public partial class FormAtualizarVeiculo : Form
{
    private readonly IVeiculoService _veiculoService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private bool _isUpdatingText = false;

    public FormAtualizarVeiculo(IVeiculoService veiculoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _veiculoService = veiculoService;
        _serviceProvider = serviceProvider;
    }

    public long VeiculoId { get; set; }

    private async void BtnAtualizarVeiculo_Click(object sender, EventArgs e)
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
        else
        {
            if (DgvVeiculosClientes.SelectedCells[0].ColumnIndex == 0 && DgvVeiculosClientes.SelectedCells[0].Value == null)
            {
                var dialog = MessageBox.Show("Tem certeza que deseja continuar sem selecionar um cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialog == DialogResult.No)
                    return;

                clienteFlag = false;
            }
        }
        try
        {
            BtnAtualizarVeiculo.Enabled = false;
            long? clienteId = clienteFlag ? (long?)DgvVeiculosClientes.SelectedRows[0].Cells["ClienteId"].Value : null;

            var veiculoExistente = await _veiculoService.GetVeiculoByIdAsync(VeiculoId);

            veiculoExistente.ClienteId = clienteId;
            veiculoExistente.Marca = TxtMarca.Text.Trim();
            veiculoExistente.Modelo = TxtModelo.Text.Trim();
            veiculoExistente.Ano = int.TryParse(TxtMskAno.Text.Trim(), out int anoCarro) ? anoCarro : 0;
            veiculoExistente.Matricula = TxtMskMatricula.Text.Trim();
            veiculoExistente.Observacoes = RTxtObservacoes.Text.Trim();


            await _veiculoService.UpdateVeiculoAsync(veiculoExistente);

            MessageBox.Show("Veículo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao atualizar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao atualizar veículo: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao atualizar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnAtualizarVeiculo.Enabled = true;
        }
    }

    private async void TxtCliente_TextChanged(object sender, EventArgs e)
    {
        if (_isUpdatingText)
            return;

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
                        DgvVeiculosClientes.ClearSelection();
                        DgvVeiculosClientes.Rows[0].Selected = true;
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
        if(String.IsNullOrWhiteSpace(TxtMskMatricula.Text))
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

    private async void FormAtualizarVeiculo_Load(object sender, EventArgs e)
    {
        try
        {
            var veiculo = await _veiculoService.GetVeiculoByIdAsync(VeiculoId);

            if (veiculo == null)
            {
                MessageBox.Show("Veículo não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            TxtMarca.Text = veiculo.Marca;
            TxtModelo.Text = veiculo.Modelo;
            TxtMskAno.Text = veiculo.Ano.ToString();
            TxtMskMatricula.Text = veiculo.Matricula;
            RTxtObservacoes.Text = veiculo.Observacoes;

            if (veiculo.Cliente != null)
            {
                TxtCliente.Text = veiculo.Cliente.Nome + " " + veiculo.Cliente.Sobrenome;
            }

            PanelInfoVeiculo.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar informações do cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
}
