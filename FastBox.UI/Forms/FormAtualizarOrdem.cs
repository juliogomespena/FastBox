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
    private bool _servicoConcluido = false;

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

            var statusOrdemDeServicoId = 1;
            if (_servicoConcluido)
                statusOrdemDeServicoId = 4;
            else if (_orcamentos.Any(o => o.StatusOrcamento == 1 || o.StatusOrcamento == 3))
                statusOrdemDeServicoId = 2;
            else if (_orcamentos.All(o => o.StatusOrcamento == 2))
                statusOrdemDeServicoId = 3;

            var ordemConverted = new OrdemDeServicoViewModel
            {
                OrdemDeServicoId = OrdemDeServicoAtual.OrdemDeServicoId,
                StatusOrdemDeServicoId = statusOrdemDeServicoId,
                ClienteId = _clienteId,
                VeiculoId = _veiculoId,
                Descricao = RTxtDescricaoOrdemAtualizar.Text.Trim(),
                DataAbertura = OrdemDeServicoAtual.DataAbertura,
                EstimativaConclusao = DateTimePickerEstimativaConclusao.Value,
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
                        Margem = itens.Margem
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
            var dialog = MessageBox.Show("Tem certeza que deseja continuar sem alterar um orçamento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.No)
                return false;
        }

        return true;
    }

    private void FormAtualizarOrdem_Load(object sender, EventArgs e)
    {
        _clienteId = OrdemDeServicoAtual.ClienteId;
        _veiculoId = OrdemDeServicoAtual.VeiculoId;
        TxtClienteOrdemAtualizar.Text = OrdemDeServicoAtual.NomeCliente;
        TxtVeiculoOrdemAtualizar.Text = OrdemDeServicoAtual.ModeloMatricula;
        RTxtDescricaoOrdemAtualizar.Text = OrdemDeServicoAtual.Descricao;
        DateTimePickerEstimativaConclusao.Value = OrdemDeServicoAtual.EstimativaConclusao ?? DateTime.Now;
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
                Margem = item.Margem
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
        DgvOrcamentosAtualizarOrdem.Columns["StatusOrcamento"].Visible = true; // converter para texto futuramente
        DgvOrcamentosAtualizarOrdem.Columns["OrdemDeServico"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["ItensOrcamento"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["StatusOrcamento"].Visible = false;
        DgvOrcamentosAtualizarOrdem.Columns["ValorTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizarOrdem.Columns["CustoTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizarOrdem.Columns["LucroTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizarOrdem.Columns["Numero"].HeaderText = "Número";
        DgvOrcamentosAtualizarOrdem.Columns["DataCriacao"].HeaderText = "Data de criação";
        DgvOrcamentosAtualizarOrdem.Columns["Descricao"].HeaderText = "Descrição";
        DgvOrcamentosAtualizarOrdem.Columns["NumeroDeItens"].HeaderText = "Itens";
        DgvOrcamentosAtualizarOrdem.Columns["CustoTotal"].HeaderText = "Custo";
        DgvOrcamentosAtualizarOrdem.Columns["ValorTotal"].HeaderText = "Valor";
        DgvOrcamentosAtualizarOrdem.Columns["LucroTotal"].HeaderText = "Lucro";
        DgvOrcamentosAtualizarOrdem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    MessageBox.Show("As alterações no orçamento não foram salvas, tente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        else
        {
            MessageBox.Show("Selecione um orçamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
}

