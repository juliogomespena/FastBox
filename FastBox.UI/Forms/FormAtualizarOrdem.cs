using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Printing;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormAtualizarOrdem : Form
{
    private readonly IOrdemDeServicoService _ordemService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private long? _clienteId = null;
    private long? _veiculoId = null;
    private ICollection<OrcamentoViewModel> _orcamentos = [];

    public FormAtualizarOrdem(IOrdemDeServicoService ordemService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _ordemService = ordemService;
        _serviceProvider = serviceProvider;
    }

    public OrdemDeServicoViewModel OrdemDeServicoAtual { get; set; }

    private async void BtnAtualizarOrdem_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            BtnAtualizarOrdem.Enabled = false;

            var ordemConverted = new OrdemDeServicoViewModel
            {
                OrdemDeServicoId = OrdemDeServicoAtual.OrdemDeServicoId,
                ClienteId = _clienteId,
                VeiculoId = _veiculoId,
                StatusOrdemDeServicoId = OrdemDeServicoAtual.StatusOrdemDeServicoId,
                Descricao = RTxtDescricaoOrdemAtualizar.Text.Trim(),
                DataAbertura = OrdemDeServicoAtual.DataAbertura,
                EstimativaConclusao = DateTimePickerEstimativaConclusao.Value,
                IncluirIva = ChkIncluirIvaAtualizarOrdem.Checked,
                Orcamentos = _orcamentos.Select(orcamento => new Orcamento
                {
                    OrcamentoId = orcamento.OrcamentoId,
                    StatusOrcamento = orcamento.StatusOrcamento,
                    DataCriacao = orcamento.DataCriacao,
                    Descricao = orcamento.Descricao,
                    ItensOrcamento = orcamento.ItensOrcamento.Select(itens => new ItemOrcamento
                    {
                        ItemOrcamentoId = itens.ItemOrcamentoId,
                        Descricao = itens.Descricao,
                        Quantidade = itens.Quantidade,
                        PrecoUnitario = itens.PrecoUnitario,
                        Margem = itens.Margem,
                        FornecedorId = itens.FornecedorId,
                        NumeroFatura = itens.NumeroFatura
                    }).ToList()
                }).ToList(),
            };

            await _ordemService.UpdateOrdemAsync(ordemConverted);

            MessageBox.Show("Ordem de serviço alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao alterar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao alterar ordem de serviço: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao alterar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnAtualizarOrdem.Enabled = true;
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(RTxtDescricaoOrdemAtualizar.Text))
        {
            MessageBox.Show("Digite uma breve descrição para a ordem de serviço.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var dataAtual = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
        var dataSelecionada = DateTimePickerEstimativaConclusao.Value.Date.AddHours(DateTimePickerEstimativaConclusao.Value.Hour);

        if (dataSelecionada < dataAtual)
        {
            MessageBox.Show("Selecione uma data e hora válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (!_orcamentos.Any())
        {
            var dialog = MessageBox.Show("Deseja continuar sem alterar um orçamento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;
        }

        return true;
    }

    private void FormAtualizarOrdem_Load(object sender, EventArgs e)
    {
        string pagamentos = string.Empty;

        if (OrdemDeServicoAtual.StatusOrdemDeServicoId == 7 || OrdemDeServicoAtual.StatusOrdemDeServicoId == 6 || OrdemDeServicoAtual.StatusOrdemDeServicoId == 5)
        {
            TxtClienteOrdemAtualizar.Enabled = false;
            TxtVeiculoOrdemAtualizar.Enabled = false;
            RTxtDescricaoOrdemAtualizar.ReadOnly = true;
            DateTimePickerEstimativaConclusao.Enabled = false;
            BtnNovoClienteOrdemAtualizar.Enabled = false;
            BtnNovoVeiculoOrdemAtualizar.Enabled = false;
            BtnNovoOrcamentoOrdemAtualizar.Enabled = false;
            BtnAprovarOrcamentoOrdemAtualizar.Enabled = false;
            BtnExcluirOrcamentoOrdemAtualizar.Enabled = false;
            BtnReprovarOrcamentoOrdemAtualizar.Enabled = false;
            BtnAtualizarOrdem.Enabled = false;
            ChkIncluirIvaAtualizarOrdem.Enabled = false;

            if (OrdemDeServicoAtual.StatusOrdemDeServicoId == 6 || OrdemDeServicoAtual.StatusOrdemDeServicoId == 5)
            {
                if (String.IsNullOrWhiteSpace(OrdemDeServicoAtual.Descricao))
                    pagamentos = "Pagamentos:\n";
                else
                    pagamentos = "\n\nPagamentos:\n";

                foreach (Pagamento pagamento in OrdemDeServicoAtual.Pagamentos)
                    pagamentos += OrdemDeServicoAtual.Pagamentos.Count > 1 ? $"{pagamento.MetodoPagamento.Nome}: {pagamento.Valor} - " : $"{pagamento.MetodoPagamento.Nome}: {pagamento.Valor}";
            }
        }

        _clienteId = OrdemDeServicoAtual.ClienteId;
        _veiculoId = OrdemDeServicoAtual.VeiculoId;
        TxtClienteOrdemAtualizar.Text = OrdemDeServicoAtual.NomeCliente;
        TxtVeiculoOrdemAtualizar.Text = OrdemDeServicoAtual.ModeloMatricula;
        RTxtDescricaoOrdemAtualizar.Text = OrdemDeServicoAtual.Descricao + $"{pagamentos}";
        DateTimePickerEstimativaConclusao.Value = OrdemDeServicoAtual.EstimativaConclusao ?? DateTime.Now;
        ChkIncluirIvaAtualizarOrdem.Checked = OrdemDeServicoAtual.IncluirIva;
        _orcamentos = OrdemDeServicoAtual.Orcamentos.Select(orcamento => new OrcamentoViewModel
        {
            OrcamentoId = orcamento.OrcamentoId,
            OrdemDeServicoId = orcamento.OrdemDeServicoId,
            StatusOrcamento = orcamento.StatusOrcamento,
            DataCriacao = orcamento.DataCriacao,
            Descricao = orcamento.Descricao,
            ItensOrcamento = orcamento.ItensOrcamento.Select(item => new ItemOrcamentoViewModel
            {
                ItemOrcamentoId = item.ItemOrcamentoId,
                OrcamentoId = item.OrcamentoId,
                Descricao = item.Descricao,
                Quantidade = item.Quantidade,
                PrecoUnitario = item.PrecoUnitario,
                Margem = item.Margem * 100,
                FornecedorId = item.FornecedorId,
                NumeroFatura = item.NumeroFatura,
                Fornecedor = new FornecedorViewModel
                {
                    Nome = item.Fornecedor.Nome,
                    Telemovel = item.Fornecedor.Telemovel,
                    Email = item.Fornecedor.Email,
                    EnderecoId = item.Fornecedor.EnderecoId,
                    Endereco = item.Fornecedor.Endereco,
                }
            }).ToList()
        }).ToList();

        int novoNumero = 1;
        foreach (var orcamento in _orcamentos.OrderBy(o => o.Numero))
        {
            orcamento.Numero = novoNumero++;
        }

        LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
        DateTimePickerEstimativaConclusao.MinDate = DateTime.Now;
    }

    private void BtnNovoClienteOrdemAtualizar_Click(object sender, EventArgs e)
    {
        var frmCadastrarCliente = _serviceProvider.GetRequiredService<FormCadastrarCliente>();
        var result = frmCadastrarCliente.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarCliente.NomeSobrenomeClienteCadastrado))
        {
            TxtClienteOrdemAtualizar.Text = frmCadastrarCliente.NomeSobrenomeClienteCadastrado;
        }
    }

    private void BtnNovoVeiculoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        var frmCadastrarVeiculo = _serviceProvider.GetRequiredService<FormCadastrarVeiculo>();
        frmCadastrarVeiculo.NomeCliente = TxtClienteOrdemAtualizar.Text;
        frmCadastrarVeiculo.MatriculaParaCadastro = TxtVeiculoOrdemAtualizar.Text;
        var result = frmCadastrarVeiculo.ShowDialog();
        if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(frmCadastrarVeiculo.MatriculaVeiculoCadastrado))
        {
            TxtVeiculoOrdemAtualizar.Text = string.Empty;
            TxtVeiculoOrdemAtualizar.Text = frmCadastrarVeiculo.MatriculaVeiculoCadastrado;
        }
    }

    private void BtnNovoOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        var frmCadastrarOrcamento = _serviceProvider.GetRequiredService<FormCadastrarOrcamento>();
        var result = frmCadastrarOrcamento.ShowDialog();

        if (result == DialogResult.OK && frmCadastrarOrcamento.OrcamentoAtual != null)
        {
            var orcamentoAtual = frmCadastrarOrcamento.OrcamentoAtual;
            orcamentoAtual.Numero = _orcamentos.Count() + 1;

            _orcamentos.Add(orcamentoAtual);

            MessageBox.Show("Orçamento cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
        }
        else
            MessageBox.Show("Orçamento não cadastrado, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem()
    {
        DgvOrcamentosAtualizarOrdem.DataSource = null;
        DgvOrcamentosAtualizarOrdem.DataSource = _orcamentos.ToList();
        DgvOrcamentosAtualizarOrdem.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["OrdemDeServicoId"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["StatusOrcamento"].Visible = true;
        DgvOrcamentosAtualizarOrdem.Columns["OrdemDeServico"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["ItensOrcamento"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["StatusOrcamento"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["Descricao"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["VendaPecas"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["CustoPecas"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["LucroPecas"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["MaoDeObra"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["VendaTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["LucroTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["IVA"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizarOrdem.Columns["Numero"].HeaderText = "Nº";
        DgvOrcamentosAtualizarOrdem.Columns["DataCriacao"].HeaderText = "Data de criação";
        DgvOrcamentosAtualizarOrdem.Columns["NumeroDeItens"].HeaderText = "Itens";
        DgvOrcamentosAtualizarOrdem.Columns["CustoPecas"].HeaderText = "Peças";
        DgvOrcamentosAtualizarOrdem.Columns["VendaPecas"].HeaderText = "Venda";
        DgvOrcamentosAtualizarOrdem.Columns["LucroPecas"].HeaderText = "Lucro";
        DgvOrcamentosAtualizarOrdem.Columns["MaoDeObra"].HeaderText = "Mão de obra";
        DgvOrcamentosAtualizarOrdem.Columns["VendaTotal"].HeaderText = "Total";
        DgvOrcamentosAtualizarOrdem.Columns["LucroTotal"].HeaderText = "Lucro T.";
        DgvOrcamentosAtualizarOrdem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        DgvOrcamentosAtualizarOrdem.Columns["NumeroDeItens"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        DgvOrcamentosAtualizarOrdem.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        DgvOrcamentosAtualizarOrdem.Columns["MaoDeObra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        DgvOrcamentosAtualizarOrdem.MultiSelect = false;
    }

    private void DateTimePickerEstimativaConclusao_ValueChanged(object sender, EventArgs e)
    {
        var dataAtual = DateTime.Now;

        if (DateTimePickerEstimativaConclusao.Value < dataAtual)
        {
            MessageBox.Show("A data e hora selecionadas não podem ser anteriores à data e hora atuais.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

            DateTimePickerEstimativaConclusao.Value = dataAtual;
        }
    }

    private void TxtVeiculoOrdemAtualizar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }

    private void BtnEditarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                var frmAtualizarOrcamento = _serviceProvider.GetRequiredService<FormAtualizarOrcamento>();
                frmAtualizarOrcamento.OrcamentoAtual = orcamentoSelecionado;

                if (OrdemDeServicoAtual.StatusOrdemDeServicoId == 7 || OrdemDeServicoAtual.StatusOrdemDeServicoId == 6 || OrdemDeServicoAtual.StatusOrdemDeServicoId == 5)
                    frmAtualizarOrcamento.IsOrdemCancelledCompletedOrAwaitingPayment = true;

                var result = frmAtualizarOrcamento.ShowDialog();

                if (result == DialogResult.OK && frmAtualizarOrcamento.OrcamentoAtual != null)
                {
                    orcamentoSelecionado.StatusOrcamento = frmAtualizarOrcamento.OrcamentoAtual.StatusOrcamento;
                    orcamentoSelecionado.Descricao = frmAtualizarOrcamento.OrcamentoAtual.Descricao;
                    orcamentoSelecionado.ItensOrcamento = frmAtualizarOrcamento._items.ToList();

                    MessageBox.Show("Orçamento alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
                }
                else
                {
                    if (frmAtualizarOrcamento.IsOrdemCancelledCompletedOrAwaitingPayment == false)
                        MessageBox.Show("As alterações no orçamento não foram salvas!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para abrir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnExcluirOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                _orcamentos.Remove(orcamentoSelecionado);

                int novoNumero = 1;
                foreach (var orcamento in _orcamentos.OrderBy(o => o.Numero))
                {
                    orcamento.Numero = novoNumero++;
                }

                MessageBox.Show("Orçamento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
            }
            else
                MessageBox.Show("Erro ao excluir orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnAprovarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                orcamentoSelecionado.StatusOrcamento = 2;

                MessageBox.Show("Orçamento aprovado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
            }
            else
                MessageBox.Show("Erro ao aprovar orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para aprovar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnReprovarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count > 0)
        {
            var numeroOrcamento = (int)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["Numero"].Value;

            var orcamentoSelecionado = _orcamentos.FirstOrDefault(o => o.Numero == numeroOrcamento);

            if (orcamentoSelecionado != null)
            {
                orcamentoSelecionado.StatusOrcamento = 3;

                MessageBox.Show("Orçamento reprovado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrcamentosIntoDgvOrcamentosAtualizarOrdem();
            }
            else
                MessageBox.Show("Erro ao reprovar orçamento, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para reprovar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private async void BtnExportarOrcamentoOrdemAtualizar_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizarOrdem.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecione um orçamento para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            long orcamentoId = (long)DgvOrcamentosAtualizarOrdem.SelectedRows[0].Cells["OrcamentoId"].Value;
            var orcamento = _orcamentos.FirstOrDefault(o => o.OrcamentoId == orcamentoId);
            if (orcamento != null)
            {
                VeiculoViewModel? veiculo = null;

                using (var scope = _serviceProvider.CreateScope())
                {
                    if (_veiculoId != null)
                    {
                        var veiculoService = scope.ServiceProvider.GetRequiredService<IVeiculoService>();
                        veiculo = await veiculoService.GetVeiculoByIdAsync((long)_veiculoId);
                    }

                }
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Salvar orçamento como PDF";
				saveFileDialog.FileName = $"Orçamento Nº{orcamento.Numero} {(veiculo is null ? "Viatura não cadastrada" : veiculo.ModeloMatricula)} {orcamento.DataCriacao:dd-MM-yyyy HHmmss}";

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;


                    try
                    {
                        PDF.GenerateOrcamento(orcamento, veiculo, filePath);
                        MessageBox.Show("Orçamento exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string? folderPath = Path.GetDirectoryName(filePath);
                        if (folderPath != null)
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = folderPath,
                                UseShellExecute = true,
                                Verb = "open"
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao exportar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

