using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormFornecedores : Form
{
    private readonly IFornecedorService _fornecedorService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;
    private bool isClicking = false;

    public FormFornecedores(IFornecedorService fornecedorService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _fornecedorService = fornecedorService;
        _serviceProvider = serviceProvider;
    }

    public required Button buttonClientes;
    public required Button buttonVeiculos;
    public required Button buttonOrdensDeServico;
    public required Button buttonFornecedores;
    public required Button buttonRelatorios;

    private async void FormFornecedores_Load(object sender, EventArgs e)
    {
        await LoadFornecedoresIntoDgvAsync(1, GlobalConfiguration.PageSize);
    }

    private async Task LoadFornecedoresIntoDgvAsync(int page, int size, FornecedorFilter? filter = null)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var fornecedores = await _fornecedorService.GetFornecedoresInPagesAsync(page, size, filter);
            DgvFornecedores.DataSource = fornecedores;
            DgvFornecedores.Columns["EnderecoId"].Visible = false;
            DgvFornecedores.Columns["Endereco"].Visible = false;
            DgvFornecedores.Columns["EnderecoCompleto"].Visible = false;
            DgvFornecedores.Columns["EstoquePecas"].Visible = false;
            DgvFornecedores.Columns["ItensOrcamento"].Visible = false;
                DgvFornecedores.Columns["InfoFornecedor"].Visible = false;          
            DgvFornecedores.Columns["Telemovel"].HeaderText = "Telemóvel";
            DgvFornecedores.Columns["EnderecoResumido"].HeaderText = "Endereço";
            DgvFornecedores.Columns["FornecedorId"].HeaderText = "Id";
            DgvFornecedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvFornecedores.MultiSelect = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar os fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            await LoadFornecedoresIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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
                await LoadFornecedoresIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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

    private async void BtnCadastrarFornecedor_Click(object sender, EventArgs e)
    {
        var frmCadastrarFornecedor = _serviceProvider.GetRequiredService<FormCadastrarFornecedor>();
        frmCadastrarFornecedor.ShowDialog();

        await LoadFornecedoresIntoDgvAsync(1, GlobalConfiguration.PageSize);
    }

    private void DgvFornecedores_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            var coluna = DgvFornecedores.Columns[e.ColumnIndex];

            if (coluna.Name == "EnderecoResumido")
            {
                e.ToolTipText = DgvFornecedores.Rows[e.RowIndex].Cells["EnderecoCompleto"].Value?.ToString();
            }
        }
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        await LoadFornecedoresIntoDgvAsync(1, GlobalConfiguration.PageSize);
        ResetFilterFields();
    }

    private async void BtnAtualizarFornecedor_Click(object sender, EventArgs e)
    {
        if (DgvFornecedores.SelectedRows.Count > 0)
        {
            var fornecedorId = (long)DgvFornecedores.SelectedRows[0].Cells["FornecedorId"].Value;
            var frmAtualizarFornecedor = _serviceProvider.GetRequiredService<FormAtualizarFornecedor>();
            frmAtualizarFornecedor.FornecedorId = fornecedorId;
            frmAtualizarFornecedor.ShowDialog();

            await LoadFornecedoresIntoDgvAsync(1, GlobalConfiguration.PageSize);
        }
        else
            MessageBox.Show("Selecione um fornecedor para abrir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private async void BtnExcluirFornecedor_Click(object sender, EventArgs e)
    {
        if (DgvFornecedores.SelectedRows.Count > 0)
        {
            try
            {
                ControlButtonsForDatabaseOperations();
                var fornecedorId = (long)DgvFornecedores.SelectedRows[0].Cells["FornecedorId"].Value;
                var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(fornecedorId);

                if (fornecedor == null)
                    throw new Exception("Não foi possível selecionar fornecedor, tente novamente.");

                var dialog = MessageBox.Show($"Deseja excluir o fornecedor {fornecedor.Nome}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    await _fornecedorService.DeleteFornecedorAsync(fornecedor);
                    MessageBox.Show("Fornecedor deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao deletar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao deletar fornecedor: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Fornecedor") && ex.Message.Contains("ItemOrcamento"))
                {
                    MessageBox.Show(
                        "Não é possível excluir o fornecedor pois ele está associado a itens em ordens de serviço. Exclua ou altere os itens associados antes de tentar novamente.",
                        "Erro ao excluir fornecedor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show($"Erro ao deletar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            await LoadFornecedoresIntoDgvAsync(1, GlobalConfiguration.PageSize);
        }
        else
            MessageBox.Show("Selecione um fornecedor para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ControlButtonsForDatabaseOperations(bool buttonState = false)
    {
        buttonFornecedores.Enabled = buttonState;
        buttonVeiculos.Enabled = buttonState;
        buttonOrdensDeServico.Enabled = buttonState;
        buttonFornecedores.Enabled = buttonState;
        buttonRelatorios.Enabled = buttonState;
        BtnRefresh.Enabled = buttonState;
        BtnNextPage.Enabled = buttonState;
        BtnPreviousPage.Enabled = buttonState;
        BtnAbrirFornecedor.Enabled = buttonState;
        BtnCadastrarFornecedor.Enabled = buttonState;
        BtnExcluirFornecedor.Enabled = buttonState;
    }

    private async void TspBtnAplicar_Click(object sender, EventArgs e)
    {
        var filter = new FornecedorFilter
        {
            Nome = TspTxtNome.Text == "Nome" ? null : TspTxtNome.Text,
            Telemovel = TspTxtTelemovel.Text == "Telemóvel" ? null : TspTxtTelemovel.Text,
            Email = TspTxtEmail.Text == "Email" ? null : TspTxtEmail.Text,
            Peca = TspTxtPeca.Text == "Peça" ? null : TspTxtPeca.Text,
            EnderecoCompleto = TspTxtEndereco.Text == "Endereço" ? null : TspTxtEndereco.Text,
        };

        await LoadFornecedoresIntoDgvAsync(1, GlobalConfiguration.PageSize, filter);
        ResetFilterFields();
    }

    private void TspTxtNome_Enter(object sender, EventArgs e)
    {
        if (TspTxtNome.Text == "Nome")
        {
            TspTxtNome.Text = null;
            TspTxtNome.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtNome_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtNome.Text))
        {
            TspTxtNome.Text = "Nome";
            TspTxtNome.ForeColor = Color.Gray;
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
        TspTxtNome.Text = "Nome";
        TspTxtNome.ForeColor = Color.Gray;

        TspTxtTelemovel.Text = "Telemóvel";
        TspTxtTelemovel.ForeColor = Color.Gray;

        TspTxtEmail.Text = "Email";
        TspTxtEmail.ForeColor = Color.Gray;

        TspTxtEndereco.Text = "Endereço";
        TspTxtEndereco.ForeColor = Color.Gray;
    }

}