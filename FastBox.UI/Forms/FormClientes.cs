using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormClientes : Form
{
    private readonly IClienteService _clienteService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;
    private bool isClicking = false;
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
        await LoadClientsIntoDgvAsync(1, GlobalConfiguration.PageSize);
    }

    private async Task LoadClientsIntoDgvAsync(int page, int size, ClienteFilter? filter = null)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var clientes = await _clienteService.GetClientsInPagesAsync(page, size, filter);
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
            DgvClientes.Columns["VeiculosMatricula"].HeaderText = "Veículos";
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
            await LoadClientsIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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
                await LoadClientsIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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

        await LoadClientsIntoDgvAsync(1, GlobalConfiguration.PageSize);
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
        await LoadClientsIntoDgvAsync(1, GlobalConfiguration.PageSize);
        ResetFilterFields();
    }

    private async void BtnAtualizarCliente_Click(object sender, EventArgs e)
    {
        if (DgvClientes.SelectedRows.Count > 0)
        {
            var clienteId = (long)DgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
            var frmAtualizarCliente = _serviceProvider.GetRequiredService<FormAtualizarCliente>();
            frmAtualizarCliente.ClienteId = clienteId;
            frmAtualizarCliente.ShowDialog();

            await LoadClientsIntoDgvAsync(1, GlobalConfiguration.PageSize);
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

                var dialog = MessageBox.Show($"Deseja excluir o cliente {cliente.Nome} {cliente.Sobrenome}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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


            await LoadClientsIntoDgvAsync(1, GlobalConfiguration.PageSize);
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

    private async void TspBtnAplicar_Click(object sender, EventArgs e)
    {
        var filter = new ClienteFilter
        {
            NomeSobrenome = TspTxtNome.Text == "Nome completo" ? null : TspTxtNome.Text,
            Nif = TspTxtNif.Text == "NIF" ? null : TspTxtNif.Text,
            Telemovel = TspTxtTelemovel.Text == "Telemóvel" ? null : TspTxtTelemovel.Text,
            Email = TspTxtEmail.Text == "Email" ? null : TspTxtEmail.Text,
            DataCadastroInicio = DateTime.TryParse(TspTxtDataInicial.Text, out DateTime inicioData)? new DateTime(inicioData.Year, inicioData.Month, inicioData.Day, inicioData.Hour, inicioData.Minute, 0) : null,
            DataCadastroFim = DateTime.TryParse(TspTxtDataFinal.Text, out DateTime fimData) ? new DateTime(fimData.Year, fimData.Month, fimData.Day, 23, 59, 59) : null,
            MatriculaVeiculo = TspTxtMatricula.Text == "Matrícula" ? null : TspTxtMatricula.Text,
            EnderecoCompleto = TspTxtEndereco.Text == "Endereço" ? null : TspTxtEndereco.Text,
        };

        await LoadClientsIntoDgvAsync(1, GlobalConfiguration.PageSize, filter);
        ResetFilterFields();
    }

    private void TspTxtNome_Enter(object sender, EventArgs e)
    {
        if (TspTxtNome.Text == "Nome completo")
        {
            TspTxtNome.Text = null;
            TspTxtNome.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtNome_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtNome.Text))
        {
            TspTxtNome.Text = "Nome completo";
            TspTxtNome.ForeColor = Color.Gray;
        }
    }

    private void TspTxtNif_Enter(object sender, EventArgs e)
    {
        if (TspTxtNif.Text == "NIF")
        {
            TspTxtNif.Text = null;
            TspTxtNif.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtNif_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtNif.Text))
        {
            TspTxtNif.Text = "NIF";
            TspTxtNif.ForeColor = Color.Gray;
        }
    }

    private void TspTxtTelemovel_Enter(object sender, EventArgs e)
    {
        if (TspTxtTelemovel.Text == "Telemóvel")
        {
            TspTxtTelemovel.Text = null;
            TspTxtTelemovel.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtTelemovel_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtTelemovel.Text))
        {
            TspTxtTelemovel.Text = "Telemóvel";
            TspTxtTelemovel.ForeColor = Color.Gray;
        }
    }

    private void TspTxtEmail_Enter(object sender, EventArgs e)
    {
        if (TspTxtEmail.Text == "Email")
        {
            TspTxtEmail.Text = null;
            TspTxtEmail.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtEmail_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtEmail.Text))
        {
            TspTxtEmail.Text = "Email";
            TspTxtEmail.ForeColor = Color.Gray;
        }
    }

    private void TspTxtDataInicial_Enter(object sender, EventArgs e)
    {
        if (TspTxtDataInicial.Text == "Data inicial")
        {
            TspTxtDataInicial.Text = null;
            TspTxtDataInicial.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtDataInicial_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtDataInicial.Text))
        {
            TspTxtDataInicial.Text = "Data inicial";
            TspTxtDataInicial.ForeColor = Color.Gray;
        }
    }

    private void TspTxtDataFinal_Enter(object sender, EventArgs e)
    {
        if (TspTxtDataFinal.Text == "Data final")
        {
            TspTxtDataFinal.Text = null;
            TspTxtDataFinal.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtDataFinal_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtDataFinal.Text))
        {
            TspTxtDataFinal.Text = "Data final";
            TspTxtDataFinal.ForeColor = Color.Gray;
        }
    }

    private void TspTxtMatricula_Enter(object sender, EventArgs e)
    {
        if (TspTxtMatricula.Text == "Matrícula")
        {
            TspTxtMatricula.Text = null;
            TspTxtMatricula.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtMatricula_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtMatricula.Text))
        {
            TspTxtMatricula.Text = "Matrícula";
            TspTxtMatricula.ForeColor = Color.Gray;
        }
    }

    private void TspTxtEndereco_Enter(object sender, EventArgs e)
    {
        if (TspTxtEndereco.Text == "Endereço")
        {
            TspTxtEndereco.Text = null;
            TspTxtEndereco.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtEndereco_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtEndereco.Text))
        {
            TspTxtEndereco.Text = "Endereço";
            TspTxtEndereco.ForeColor = Color.Gray;
        }
    }

    private void ResetFilterFields()
    {
        TspTxtNome.Text = "Nome completo";
        TspTxtNome.ForeColor = Color.Gray;

        TspTxtNif.Text = "NIF";
        TspTxtNif.ForeColor = Color.Gray;

        TspTxtTelemovel.Text = "Telemóvel";
        TspTxtTelemovel.ForeColor = Color.Gray;

        TspTxtEmail.Text = "Email";
        TspTxtEmail.ForeColor = Color.Gray;

        TspTxtDataInicial.Text = "Data inicial";
        TspTxtDataInicial.ForeColor = Color.Gray;

        TspTxtDataFinal.Text = "Data final";
        TspTxtDataFinal.ForeColor = Color.Gray;

        TspTxtMatricula.Text = "Matrícula";
        TspTxtMatricula.ForeColor = Color.Gray;

        TspTxtEndereco.Text = "Endereço";
        TspTxtEndereco.ForeColor = Color.Gray;
    }

}