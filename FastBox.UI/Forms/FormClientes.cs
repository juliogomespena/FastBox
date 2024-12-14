using FastBox.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormClientes : Form
{
    private readonly IClienteService _clienteService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;
    private readonly int pageSize = 30;
    public FormClientes(IClienteService clienteService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _clienteService = clienteService;
        _serviceProvider = serviceProvider;
    }

    public required Button buttonClientes;
    public required Button buttonVeiculos;
    public required Button buttonOrdensDeServico;
    public required Button buttonRelatorios;

    private async void FormClientes_Load(object sender, EventArgs e)
    {
        await LoadClientsIntoDgvAsync(1, pageSize);
    }

    private async Task LoadClientsIntoDgvAsync(int page, int size)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var clientes = await _clienteService.GetClientsInPagesAsync(page, size);
            DgvClientes.DataSource = clientes;
            DgvClientes.Columns["EnderecoCompleto"].Visible = false;
            DgvClientes.Columns["EnderecoId"].Visible = false;
            DgvClientes.Columns["Endereco"].Visible = false;
            DgvClientes.Columns["Usuarios"].Visible = false;
            DgvClientes.Columns["OrdemDeServicos"].Visible = false;
            DgvClientes.Columns["Veiculos"].Visible = false;
            DgvClientes.Columns["Nome"].Visible = false;
            DgvClientes.Columns["Sobrenome"].Visible = false;
            DgvClientes.Columns["ClienteId"].HeaderText = "Id";
            DgvClientes.Columns["EnderecoResumido"].HeaderText = "Endereço";
            DgvClientes.Columns["DataCadastro"].HeaderText = "Data de cadastro";
            DgvClientes.Columns["OrdensDeServicoCount"].HeaderText = "Ordens de serviço";
            DgvClientes.Columns["VeiculosCount"].HeaderText = "Veículos";
            DgvClientes.Columns["NomeSobrenome"].HeaderText = "Nome";
            DgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvClientes.MultiSelect = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar os clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ControlButtonsForDatabaseOperations(true);
        }
    }

    private async void BtnNextPage_Click(object sender, EventArgs e)
    {
        currentPage++;
        try
        {
            ControlButtonsForDatabaseOperations();
            await LoadClientsIntoDgvAsync(currentPage, pageSize);
        }
        catch (Exception ex)
        {
            currentPage--;
            MessageBox.Show($"Erro ao carregar página: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ControlButtonsForDatabaseOperations(true);
        }

    }

    private async void BtnPreviousPage_Click(object sender, EventArgs e)
    {
        if (currentPage > 1)
        {
            currentPage--;
            try
            {
                ControlButtonsForDatabaseOperations();
                await LoadClientsIntoDgvAsync(currentPage, pageSize);
            }
            catch (Exception ex)
            {
                currentPage++;
                MessageBox.Show($"Erro ao carregar página: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ControlButtonsForDatabaseOperations(true);
            }

        }
    }

    private async void BtnCadastrarCliente_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        frmCadastrarCliente.ShowDialog();

        await LoadClientsIntoDgvAsync(1, pageSize);
    }

    private void DgvClientes_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            var coluna = DgvClientes.Columns[e.ColumnIndex];

            if (coluna.Name == "EnderecoResumido")
            {
                e.ToolTipText = DgvClientes.Rows[e.RowIndex].Cells["EnderecoCompleto"].Value?.ToString();
            }
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        await LoadClientsIntoDgvAsync(1, pageSize);
    }

    private async void BtnAtualizarCliente_Click(object sender, EventArgs e)
    {
        if (DgvClientes.SelectedRows.Count > 0)
        {
            var clienteId = (long)DgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
            var frmAtualizarCliente = _serviceProvider.GetRequiredService<FormAtualizarCliente>();
            frmAtualizarCliente.ClienteId = clienteId;
            frmAtualizarCliente.ShowDialog();

            await LoadClientsIntoDgvAsync(1, pageSize);
        }
        else
            MessageBox.Show("Selecione um cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private async void BtnExcluirCliente_Click(object sender, EventArgs e)
    {
        if (DgvClientes.SelectedRows.Count > 0)
        {
            try
            {
                ControlButtonsForDatabaseOperations();
                var clienteId = (long)DgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
                var cliente = await _clienteService.GetClientByIdAsync(clienteId);

                if (cliente == null)
                    throw new Exception("Não foi possível selecionar cliente, tente novamente.");

                var dialog = MessageBox.Show($"Tem certeza que deseja excluir o cliente {cliente.Nome} {cliente.Sobrenome}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    await _clienteService.DeleteClientAsync(cliente);
                    MessageBox.Show("Cliente deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao deletar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao deletar cliente: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao deletar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            await LoadClientsIntoDgvAsync(1, pageSize);
        }
        else
            MessageBox.Show("Selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ControlButtonsForDatabaseOperations(bool buttonState = false)
    {
        buttonClientes.Enabled = buttonState;
        buttonVeiculos.Enabled = buttonState;
        buttonOrdensDeServico.Enabled = buttonState;
        buttonRelatorios.Enabled = buttonState;
        BtnRefresh.Enabled = buttonState;
        BtnNextPage.Enabled = buttonState;
        BtnPreviousPage.Enabled = buttonState;
        BtnAtualizarCliente.Enabled = buttonState;
        BtnCadastrarCliente.Enabled = buttonState;
        BtnExcluirCliente.Enabled = buttonState;
    }
}