using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI.Forms;

public partial class FormVeiculos : Form
{
    private readonly IVeiculoService _veiculoService;
    private readonly IServiceProvider _serviceProvider;
    private int currentPage = 1;
    public FormVeiculos(IVeiculoService veiculoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _veiculoService = veiculoService;
        _serviceProvider = serviceProvider;
    }

    public required Button buttonClientes;
    public required Button buttonVeiculos;
    public required Button buttonOrdensDeServico;
    public required Button buttonFornecedores;
    public required Button buttonRelatorios;

    private async void FormVeiculos_Load(object sender, EventArgs e)
    {
        await LoadVehiclesIntoDgvAsync(1, GlobalConfiguration.PageSize);
    }

    private async Task LoadVehiclesIntoDgvAsync(int page, int size, VeiculoFilter? filter = null)
    {
        try
        {
            ControlButtonsForDatabaseOperations();
            var veiculos = await _veiculoService.GetVeiculosInPagesAsync(page, size, filter);
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
            DgvVeiculos.Columns["VeiculoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVeiculos.Columns["Ano"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVeiculos.Columns["Matricula"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVeiculos.Columns["OrdensDeServico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            await LoadVehiclesIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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
                await LoadVehiclesIntoDgvAsync(currentPage, GlobalConfiguration.PageSize);
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

        await LoadVehiclesIntoDgvAsync(1, GlobalConfiguration.PageSize);
    }

    private async void BtnRefresh_Click(object sender, EventArgs e)
    {
        await LoadVehiclesIntoDgvAsync(1, GlobalConfiguration.PageSize);
        ResetFilterFields();
    }

    private async void BtnAtualizarVeiculo_Click(object sender, EventArgs e)
    {
        if (DgvVeiculos.SelectedRows.Count > 0)
        {
            var veiculoId = (long)DgvVeiculos.SelectedRows[0].Cells["VeiculoId"].Value;
            var frmAtualizarVeiculo = _serviceProvider.GetRequiredService<FormAtualizarVeiculo>();
            frmAtualizarVeiculo.VeiculoId = veiculoId;
            frmAtualizarVeiculo.ShowDialog();

            await LoadVehiclesIntoDgvAsync(1, GlobalConfiguration.PageSize);
        }
        else
            MessageBox.Show("Selecione um veículo para abrir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                var dialog = MessageBox.Show($"Deseja excluir o veículo {veiculo.Modelo} ({veiculo.Matricula})?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    await _veiculoService.DeleteVeiculoAsync(veiculo);
                    MessageBox.Show("Veículo deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
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


            await LoadVehiclesIntoDgvAsync(1, GlobalConfiguration.PageSize);
        }
        else
            MessageBox.Show("Selecione um veículo para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        BtnAbrirVeiculo.Enabled = buttonState;
        BtnCadastrarVeiculo.Enabled = buttonState;
        BtnExcluirVeiculo.Enabled = buttonState;
    }

    private void TspTxtMarca_Enter(object sender, EventArgs e)
    {
        if (TspTxtMarca.Text == "Marca")
        {
            TspTxtMarca.Text = null;
            TspTxtMarca.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtMarca_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtMarca.Text))
        {
            TspTxtMarca.Text = "Marca";
            TspTxtMarca.ForeColor = Color.Gray;
        }
    }

    private async void TspBtnAplicar_Click(object sender, EventArgs e)
    {
        var filter = new VeiculoFilter
        {
            Marca = TspTxtMarca.Text == "Marca" ? null : TspTxtMarca.Text,
            Modelo = TspTxtModelo.Text == "Modelo" ? null : TspTxtModelo.Text,
            Ano = int.TryParse(TspTxtAno.Text, out int anoCarro) ? anoCarro : null,
            Matricula = TspTxtMatricula.Text == "Matrícula" ? null : TspTxtMatricula.Text,
            NomeCliente = TspTxtCliente.Text == "Cliente" ? null : TspTxtCliente.Text,
            Observacoes = TspTxtObservacoes.Text == "Observações" ? null : TspTxtObservacoes.Text,
        };

        await LoadVehiclesIntoDgvAsync(1, GlobalConfiguration.PageSize, filter);
        ResetFilterFields();
    }

    private void TspTxtModelo_Enter(object sender, EventArgs e)
    {
        if (TspTxtModelo.Text == "Modelo")
        {
            TspTxtModelo.Text = null;
            TspTxtModelo.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtModelo_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtModelo.Text))
        {
            TspTxtModelo.Text = "Modelo";
            TspTxtModelo.ForeColor = Color.Gray;
        }
    }

    private void TspTxtAno_Enter(object sender, EventArgs e)
    {
        if (TspTxtAno.Text == "Ano")
        {
            TspTxtAno.Text = null;
            TspTxtAno.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtAno_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtAno.Text))
        {
            TspTxtAno.Text = "Ano";
            TspTxtAno.ForeColor = Color.Gray;
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

    private void TspTxtObservacoes_Enter(object sender, EventArgs e)
    {
        if (TspTxtObservacoes.Text == "Observações")
        {
            TspTxtObservacoes.Text = null;
            TspTxtObservacoes.ForeColor = SystemColors.WindowText;
        }
    }

    private void TspTxtObservacoes_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TspTxtObservacoes.Text))
        {
            TspTxtObservacoes.Text = "Observações";
            TspTxtObservacoes.ForeColor = Color.Gray;
        }
    }

    private void ResetFilterFields()
    {
        TspTxtMarca.Text = "Marca";
        TspTxtMarca.ForeColor = Color.Gray;

        TspTxtModelo.Text = "Modelo";
        TspTxtModelo.ForeColor = Color.Gray;

        TspTxtAno.Text = "Ano";
        TspTxtAno.ForeColor = Color.Gray;

        TspTxtMatricula.Text = "Matrícula";
        TspTxtMatricula.ForeColor = Color.Gray;

        TspTxtCliente.Text = "Cliente";
        TspTxtCliente.ForeColor = Color.Gray;

        TspTxtObservacoes.Text = "Observações";
        TspTxtObservacoes.ForeColor = Color.Gray;
    }

}