using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormOrdensDeServico : Form
{
    private readonly IOrdemDeServicoService _ordemDeServicoService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;

    public FormOrdensDeServico(IOrdemDeServicoService ordemDeServicoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _ordemDeServicoService = ordemDeServicoService;
        _serviceProvider = serviceProvider;
    }

    public required Button buttonClientes;
    public required Button buttonVeiculos;
    public required Button buttonOrdensDeServico;
    public required Button buttonFornecedores;
    public required Button buttonRelatorios;

    private async void FormOrdensDeServico_Load(object sender, EventArgs e)
    {
        await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
        TspCmbStatus.Items.Add("Status");
        using (var scope = _serviceProvider.CreateScope())
        {
            var statusService = scope.ServiceProvider.GetRequiredService<IStatusOrdemDeServicoService>();
            var status = await statusService.GetAllStatusAsync();

            TspCmbStatus.Items.AddRange(status.Select(s => s.Nome).ToArray());
        }
        TspCmbStatus.SelectedIndex = 0;
    }

    private async Task LoadOrdensDeServicoIntoDgvAsync(int page, int size, OrdemDeServicoFilter? filter = null)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var ordensDeServico = await _ordemDeServicoService.GetOrdensInPagesAsync(page, size, filter);
            DgvOrdensDeServico.DataSource = ordensDeServico;
            DgvOrdensDeServico.Columns["ClienteId"].Visible = false;
            DgvOrdensDeServico.Columns["VeiculoId"].Visible = false;
            DgvOrdensDeServico.Columns["GarantiaEmDias"].Visible = false;
            DgvOrdensDeServico.Columns["ObservacoesGarantia"].Visible = false;
            DgvOrdensDeServico.Columns["Cliente"].Visible = false;
            DgvOrdensDeServico.Columns["Orcamentos"].Visible = false;
            DgvOrdensDeServico.Columns["Pagamentos"].Visible = false;
            DgvOrdensDeServico.Columns["Veiculo"].Visible = false;
            DgvOrdensDeServico.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
            DgvOrdensDeServico.Columns["StatusOrdemDeServicoId"].Visible = false;
            DgvOrdensDeServico.Columns["StatusOrdemDeServico"].Visible = false;
            DgvOrdensDeServico.Columns["DataConclusao"].Visible = false;
            DgvOrdensDeServico.Columns["IncluirIva"].Visible = false;
            DgvOrdensDeServico.Columns["OrdemDeServicoId"].HeaderText = "Id";
            DgvOrdensDeServico.Columns["ModeloMatricula"].HeaderText = "Veículo (matrícula)";
            DgvOrdensDeServico.Columns["NomeCliente"].HeaderText = "Cliente";
            DgvOrdensDeServico.Columns["Descricao"].HeaderText = "Descrição";
            DgvOrdensDeServico.Columns["DataAbertura"].HeaderText = "Abertura";
            DgvOrdensDeServico.Columns["EstimativaConclusao"].HeaderText = "Prazo estimado";
            DgvOrdensDeServico.Columns["ValorTotal"].HeaderText = "Valor total";
            DgvOrdensDeServico.Columns["OrcamentosCount"].HeaderText = "Orçamentos";
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
            await LoadOrdensDeServicoIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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
                await LoadOrdensDeServicoIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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

        await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
        ResetFilterFields();
    }

    private async void BtnAtualizarOrdemDeServico_Click(object sender, EventArgs e)
    {
        if (DgvOrdensDeServico.SelectedRows.Count > 0)
        {
            var ordemId = (long)DgvOrdensDeServico.SelectedRows[0].Cells["OrdemDeServicoId"].Value;
            var ordemAtual = await _ordemDeServicoService.GetOrdemByIdAsync(ordemId);

            if (ordemAtual != null)
            {
                var frmAtualizarOrdemDeServico = _serviceProvider.GetRequiredService<FormAtualizarOrdem>();
                frmAtualizarOrdemDeServico.OrdemDeServicoAtual = ordemAtual;

                var result = frmAtualizarOrdemDeServico.ShowDialog();
            }

            await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
        }
        else
            MessageBox.Show("Selecione uma ordem de serviço para abrir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (ordem.StatusOrdemDeServicoId == 5 || ordem.StatusOrdemDeServicoId == 6)
                {
                    MessageBox.Show($"A ordem já foi retirada e não pode ser excluída.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialog = MessageBox.Show($"Deseja excluir a ordem {ordem.OrdemDeServicoId}\nVeículo: {(ordem.Veiculo == null ? "não cadastrado" : $"{ordem.Veiculo.Modelo} ({ordem.Veiculo.Matricula})")}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    await _ordemDeServicoService.DeleteOrdemAsync(ordem);
                    MessageBox.Show("Ordem de serviço excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao excluir ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao excluir ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
                ControlButtonsForDatabaseOperations(true);
            }
        }
        else
            MessageBox.Show("Selecione uma ordem de serviço para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ControlButtonsForDatabaseOperations(bool buttonState = false)
    {
        buttonClientes.Enabled = buttonState;
        buttonVeiculos.Enabled = buttonState;
        buttonOrdensDeServico.Enabled = buttonState;
        buttonFornecedores.Enabled = buttonState;
        buttonRelatorios.Enabled = buttonState;
        BtnRefresh.Enabled = buttonState;
        BtnNextPage.Enabled = buttonState;
        BtnPreviousPage.Enabled = buttonState;
        BtnAbrirOrdemDeServico.Enabled = buttonState;
        BtnNovaOrdemDeServico.Enabled = buttonState;
        BtnExcluirOrdemDeServico.Enabled = buttonState;
        BtnFinalizarServico.Enabled = buttonState;
        BtnConcluirOrdem.Enabled = buttonState;
    }

    private async void BtnFinalizarServico_Click(object sender, EventArgs e)
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

                if (ordem.StatusOrdemDeServicoId == 4)
                {
                    MessageBox.Show($"A ordem já foi marcada para retirada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ordem.StatusOrdemDeServicoId == 5 || ordem.StatusOrdemDeServicoId == 6)
                {
                    MessageBox.Show($"A ordem já foi retirada e não pode ser alterada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ordem.StatusOrdemDeServicoId == 7)
                {
                    MessageBox.Show($"A ordem foi cancelada e não pode ser alterada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ordem.StatusOrdemDeServicoId != 3)
                {
                    MessageBox.Show($"A ordem precisa estar em serviço para ser finalizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialog = MessageBox.Show($"Deseja finalizar os serviços da ordem: {ordem.OrdemDeServicoId}?\nVeículo: {(ordem.Veiculo == null ? "não cadastrado" : $"{ordem.Veiculo.Modelo} ({ordem.Veiculo.Matricula})")}", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    ordem.StatusOrdemDeServicoId = 4;
                    ordem.ValorTotal = ordem.Orcamentos.Where(orcamentos => orcamentos.StatusOrcamento == 2).SelectMany(orcamento => orcamento.ItensOrcamento).Sum(itens => (itens.PrecoUnitario + (itens.PrecoUnitario * itens.Margem)) * itens.Quantidade);
                    await _ordemDeServicoService.UpdateOrdemAsync(ordem);
                    MessageBox.Show("Serviços da ordem concluídos.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao finalizar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao finalizar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
                ControlButtonsForDatabaseOperations(true);
            }
        }
        else
            MessageBox.Show("Selecione uma ordem para finalizar serviços.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private async void BtnConcluirOrdem_Click(object sender, EventArgs e)
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

                if (ordem.StatusOrdemDeServicoId == 6)
                {
                    MessageBox.Show($"A ordem já foi retirada e não pode ser alterada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ordem.StatusOrdemDeServicoId == 7)
                {
                    MessageBox.Show($"A ordem foi cancelada e não pode ser alterada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ordem.StatusOrdemDeServicoId < 4 || ordem.StatusOrdemDeServicoId > 5)
                {
                    MessageBox.Show($"A ordem precisa estar aguardando retirada para ser concluída.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialog = MessageBox.Show($"Deseja concluir a ordem de serviço: {ordem.OrdemDeServicoId}?\nVeículo: {(ordem.Veiculo == null ? "não cadastrado" : $"{ordem.Veiculo.Modelo} ({ordem.Veiculo.Matricula})")}", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    var frmConcluirOrdem = _serviceProvider.GetRequiredService<FormConcluirOrdem>();
                    frmConcluirOrdem.OrdemAtual = ordem;
                    frmConcluirOrdem.ShowDialog();
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao finalizar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao finalizar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
                ControlButtonsForDatabaseOperations(true);
            }
        }
        else
            MessageBox.Show("Selecione uma ordem para finalizar serviços.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void TspTxtCliente_Enter(object sender, EventArgs e)
    {
        if (TspTxtCliente.Text == "Cliente")
        {
            TspTxtCliente.Text = null;
            TspTxtCliente.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtCliente_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtCliente.Text))
        {
            TspTxtCliente.Text = "Cliente";
            TspTxtCliente.ForeColor = Color.Gray;
        }
    }

    private async void TspBtnAplicar_Click(object sender, EventArgs e)
    {
        var filter = new OrdemDeServicoFilter
        {
            Status = TspCmbStatus.SelectedIndex > 0 && TspCmbStatus.SelectedItem != null ? TspCmbStatus.SelectedItem.ToString() : null,
            Cliente = TspTxtCliente.Text == "Cliente" ? null : TspTxtCliente.Text,
            Veiculo = TspTxtVeiculo.Text == "Veículo" ? null : TspTxtVeiculo.Text,
            Descricao = TspTxtDescricao.Text == "Descrição" ? null : TspTxtDescricao.Text,
            DataAbertura = DateTime.TryParse(TspTxtAbertura.Text, out DateTime dataAbertura) ? new DateTime(dataAbertura.Year, dataAbertura.Month, dataAbertura.Day) : null,
            PrazoEstimado = DateTime.TryParse(TspTxtPrazo.Text, out DateTime dataPrazoEstimado) ? new DateTime(dataPrazoEstimado.Year, dataPrazoEstimado.Month, dataPrazoEstimado.Day) : null,
            ValorTotalMaiorOuIgual = TspCmbValorTotalOpcao.SelectedIndex == 0 ? true : false,
            ValorTotal = decimal.TryParse(TspTxtValorTotal.Text, out decimal valorTotal) ? valorTotal : null,
        };

        await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize, filter);

        ResetFilterFields();
    }

    private void TspTxtVeiculo_Enter(object sender, EventArgs e)
    {
        if (TspTxtVeiculo.Text == "Veículo")
        {
            TspTxtVeiculo.Text = null;
            TspTxtVeiculo.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtVeiculo_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtVeiculo.Text))
        {
            TspTxtVeiculo.Text = "Veículo";
            TspTxtVeiculo.ForeColor = Color.Gray;
        }
    }

    private void TspTxtDescricao_Enter(object sender, EventArgs e)
    {
        if (TspTxtDescricao.Text == "Descrição")
        {
            TspTxtDescricao.Text = null;
            TspTxtDescricao.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtDescricao_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtDescricao.Text))
        {
            TspTxtDescricao.Text = "Descrição";
            TspTxtDescricao.ForeColor = Color.Gray;
        }
    }

    private void TspTxtAbertura_Enter(object sender, EventArgs e)
    {
        if (TspTxtAbertura.Text == "Data de abertura")
        {
            TspTxtAbertura.Text = null;
            TspTxtAbertura.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtAbertura_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtAbertura.Text))
        {
            TspTxtAbertura.Text = "Data de abertura";
            TspTxtAbertura.ForeColor = Color.Gray;
        }
    }

    private void TspTxtPrazo_Enter(object sender, EventArgs e)
    {
        if (TspTxtPrazo.Text == "Prazo estimado")
        {
            TspTxtPrazo.Text = null;
            TspTxtPrazo.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtPrazo_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtPrazo.Text))
        {
            TspTxtPrazo.Text = "Prazo estimado";
            TspTxtPrazo.ForeColor = Color.Gray;
        }
    }

    private void TspTxtValorTotal_Enter(object sender, EventArgs e)
    {
        if (TspTxtValorTotal.Text == "Valor total")
        {
            TspTxtValorTotal.Text = null;
            TspTxtValorTotal.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtValorTotal_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtValorTotal.Text))
        {
            TspTxtValorTotal.Text = "Valor total";
            TspTxtValorTotal.ForeColor = Color.Gray;
        }
    }

    private void ResetFilterFields()
    {
        TspCmbStatus.SelectedIndex = 0;
        TspCmbValorTotalOpcao.SelectedIndex = 0;

        TspTxtCliente.Text = "Cliente";
        TspTxtCliente.ForeColor = Color.Gray;

        TspTxtVeiculo.Text = "Veículo";
        TspTxtVeiculo.ForeColor = Color.Gray;

        TspTxtDescricao.Text = "Descrição";
        TspTxtDescricao.ForeColor = Color.Gray;

        TspTxtAbertura.Text = "Data de abertura";
        TspTxtAbertura.ForeColor = Color.Gray;

        TspTxtPrazo.Text = "Prazo estimado";
        TspTxtPrazo.ForeColor = Color.Gray;

        TspTxtValorTotal.Text = "Valor total";
        TspTxtValorTotal.ForeColor = Color.Gray;
    }

    private async void BtnCancelar_Click(object sender, EventArgs e)
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


                if (ordem.StatusOrdemDeServicoId == 5 || ordem.StatusOrdemDeServicoId == 6)
                {
                    MessageBox.Show($"A ordem já foi retirada e não pode ser cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ordem.StatusOrdemDeServicoId == 7)
                {
                    MessageBox.Show($"A ordem já foi cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialog = MessageBox.Show($"Deseja cancelar a ordem {ordem.OrdemDeServicoId}\nVeículo: {(ordem.Veiculo == null ? "não cadastrado" : $"{ordem.Veiculo.Modelo} ({ordem.Veiculo.Matricula})")}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    ordem.StatusOrdemDeServicoId = 7;
                    await _ordemDeServicoService.UpdateOrdemAsync(ordem);
                    MessageBox.Show("Ordem de serviço cancelada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao cancelar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao cancelar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await LoadOrdensDeServicoIntoDgvAsync(1, GlobalConfiguration.PageSize);
                ControlButtonsForDatabaseOperations(true);
            }
        }
        else
            MessageBox.Show("Selecione uma ordem de serviço para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
