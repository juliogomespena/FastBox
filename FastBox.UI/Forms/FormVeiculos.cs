using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormVeiculos : Form
{
    private readonly IVeiculoService _veiculoService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;
    private readonly int pageSize = 30;
    public FormVeiculos(IVeiculoService veiculoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _veiculoService = veiculoService;
        _serviceProvider = serviceProvider;
    }

    public required Button buttonClientes;
    public required Button buttonVeiculos;
    public required Button buttonOrdensDeServico;
    public required Button buttonRelatorios;

    private async void FormVeiculos_Load(object sender, EventArgs e)
    {
        await LoadVehiclesIntoDgvAsync(1, pageSize);
    }

    private async Task LoadVehiclesIntoDgvAsync(int page, int size)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var veiculos = await _veiculoService.GetVeiculosInPagesAsync(page, size);
            DgvVeiculos.DataSource = veiculos;
            DgvVeiculos.Columns["ClienteId"].Visible = false;
            DgvVeiculos.Columns["Cliente"].Visible = false;
            DgvVeiculos.Columns["OrdemDeServicos"].Visible = false;
            DgvVeiculos.Columns["ModeloMatricula"].Visible = false;
            DgvVeiculos.Columns["Observacoes"].HeaderText = "Observações";
            DgvVeiculos.Columns["VeiculoId"].HeaderText = "Id";
            DgvVeiculos.Columns["NomeCliente"].HeaderText = "Cliente";
            DgvVeiculos.Columns["OrdensDeServico"].HeaderText = "Ordens de serviço";
            DgvVeiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvVeiculos.MultiSelect = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar os veículos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            await LoadVehiclesIntoDgvAsync(currentPage, pageSize);
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
                await LoadVehiclesIntoDgvAsync(currentPage, pageSize);
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

    private async void BtnCadastrarVeiculo_Click(object sender, EventArgs e)
    {
        var frmCadastrarVeiculo = _serviceProvider.GetRequiredService<FormCadastrarVeiculo>();
        frmCadastrarVeiculo.ShowDialog();

        await LoadVehiclesIntoDgvAsync(1, pageSize);
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        await LoadVehiclesIntoDgvAsync(1, pageSize);
    }

    private async void BtnAtualizarVeiculo_Click(object sender, EventArgs e)
    {
        if (DgvVeiculos.SelectedRows.Count > 0)
        {
            var veiculoId = (long)DgvVeiculos.SelectedRows[0].Cells["VeiculoId"].Value;
            var frmAtualizarVeiculo = _serviceProvider.GetRequiredService<FormAtualizarVeiculo>();
            frmAtualizarVeiculo.VeiculoId = veiculoId;
            frmAtualizarVeiculo.ShowDialog();

            await LoadVehiclesIntoDgvAsync(1, pageSize);
        }
        else
            MessageBox.Show("Selecione um veículo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private async void BtnExcluirVeiculo_Click(object sender, EventArgs e)
    {
        if (DgvVeiculos.SelectedRows.Count > 0)
        {
            try
            {
                ControlButtonsForDatabaseOperations();
                var veiculoId = (long)DgvVeiculos.SelectedRows[0].Cells["VeiculoId"].Value;
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(veiculoId);

                if (veiculo == null)
                    throw new Exception("Não foi possível selecionar veículo, tente novamente.");

                var dialog = MessageBox.Show($"Tem certeza que deseja excluir o veículo {veiculo.Marca} {veiculo.Modelo}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    await _veiculoService.DeleteVeiculoAsync(veiculo);
                    MessageBox.Show("Veículo deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(DbUpdateException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show($"Erro ao deletar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Erro ao deletar veículo: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao deletar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            await LoadVehiclesIntoDgvAsync(1, pageSize);
        }
        else
            MessageBox.Show("Selecione um veículo para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        BtnAtualizarVeiculo.Enabled = buttonState;
        BtnCadastrarVeiculo.Enabled = buttonState;
        BtnExcluirVeiculo.Enabled = buttonState;
    }
}