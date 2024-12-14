using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormOrdensDeServico : Form
{
    private readonly IOrdemDeServicoService _ordemDeServicoService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;
    private readonly int pageSize = 30;

    public FormOrdensDeServico(IOrdemDeServicoService ordemDeServicoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _ordemDeServicoService = ordemDeServicoService;
        _serviceProvider = serviceProvider;
    }

    public required Button buttonClientes;
    public required Button buttonVeiculos;
    public required Button buttonOrdensDeServico;
    public required Button buttonRelatorios;

    private async void FormOrdensDeServico_Load(object sender, EventArgs e)
    {
        await LoadOrdensDeServicoIntoDgvAsync(1, pageSize);
    }

    private async Task LoadOrdensDeServicoIntoDgvAsync(int page, int size)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var ordensDeServico = await _ordemDeServicoService.GetOrdensInPagesAsync(page, size);
            DgvOrdensDeServico.DataSource = ordensDeServico;
            DgvOrdensDeServico.Columns["ClienteId"].Visible = false;
            DgvOrdensDeServico.Columns["VeiculoId"].Visible = false;
            DgvOrdensDeServico.Columns["GarantiaEmDias"].Visible = false;
            DgvOrdensDeServico.Columns["ObservacoesGarantia"].Visible = false;
            DgvOrdensDeServico.Columns["Cliente"].Visible = false;
            DgvOrdensDeServico.Columns["Orcamentos"].Visible = false;
            DgvOrdensDeServico.Columns["Pagamentos"].Visible = false;
            DgvOrdensDeServico.Columns["Veiculo"].Visible = false;
            DgvOrdensDeServico.Columns["StatusOrdemDeServicoId"].Visible = false;
            DgvOrdensDeServico.Columns["StatusOrdemDeServico"].Visible = false;
            DgvOrdensDeServico.Columns["DataConclusao"].Visible = false;
            DgvOrdensDeServico.Columns["OrdemDeServicoId"].HeaderText = "Id";
            DgvOrdensDeServico.Columns["ModeloMatricula"].HeaderText = "Veículo (matrícula)";
            DgvOrdensDeServico.Columns["NomeCliente"].HeaderText = "Cliente";
            DgvOrdensDeServico.Columns["Descricao"].HeaderText = "Descrição";
            DgvOrdensDeServico.Columns["DataAbertura"].HeaderText = "Abertura";
            DgvOrdensDeServico.Columns["EstimativaConclusao"].HeaderText = "Prazo estimado";
            DgvOrdensDeServico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvOrdensDeServico.MultiSelect = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar as ordens de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            await LoadOrdensDeServicoIntoDgvAsync(currentPage, pageSize);
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
                await LoadOrdensDeServicoIntoDgvAsync(currentPage, pageSize);
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

    private async void BtnCadastrarOrdemDeServico_Click(object sender, EventArgs e)
    {
        var frmCadastrarOrdemDeServico = _serviceProvider.GetRequiredService<FormCadastrarOrdem>();
        frmCadastrarOrdemDeServico.ShowDialog();

        await LoadOrdensDeServicoIntoDgvAsync(1, pageSize);
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        await LoadOrdensDeServicoIntoDgvAsync(1, pageSize);
    }

    private async void BtnAtualizarOrdemDeServico_Click(object sender, EventArgs e)
    {
        if (DgvOrdensDeServico.SelectedRows.Count > 0)
        {
            //    var ordemId = (long)DgvOrdensDeServico.SelectedRows[0].Cells["OrdemDeServicoId"].Value;
            //    var frmAtualizarOrdemDeServico = _serviceProvider.GetRequiredService<FormAtualizarOrdemDeServico>();
            //    frmAtualizarOrdemDeServico.OrdemDeServicoId = ordemId;
            //    frmAtualizarOrdemDeServico.ShowDialog();

            //    await LoadOrdensDeServicoIntoDgvAsync(1, pageSize);
            //}
            //else
            //    MessageBox.Show("Selecione uma ordem de serviço para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private async void BtnExcluirOrdemDeServico_Click(object sender, EventArgs e)
    {
        if (DgvOrdensDeServico.SelectedRows.Count > 0)
        {
            try
            {
                ControlButtonsForDatabaseOperations();
                var ordemId = (long)DgvOrdensDeServico.SelectedRows[0].Cells["OrdemDeServicoId"].Value;
                var ordem = await _ordemDeServicoService.GetOrdemByIdAsync(ordemId);

                if (ordem == null)
                    throw new Exception("Não foi possível selecionar a ordem de serviço, tente novamente.");

                var dialog = MessageBox.Show($"Tem certeza que deseja excluir a ordem de serviço: {ordem.Descricao}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    await _ordemDeServicoService.DeleteOrdemAsync(ordem);
                    MessageBox.Show("Ordem de serviço deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao deletar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao deletar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await LoadOrdensDeServicoIntoDgvAsync(1, pageSize);
        }
        else
            MessageBox.Show("Selecione uma ordem de serviço para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        BtnAtualizarOrdemDeServico.Enabled = buttonState;
        BtnCadastrarOrdemDeServico.Enabled = buttonState;
        BtnExcluirOrdemDeServico.Enabled = buttonState;
    }
}
