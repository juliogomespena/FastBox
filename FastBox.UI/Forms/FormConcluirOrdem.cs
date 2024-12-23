using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastBox.UI.Forms;

public partial class FormConcluirOrdem : Form
{
    private readonly IOrdemDeServicoService _ordemDeServicoService;
    private readonly IServiceProvider _serviceProvider;

    public FormConcluirOrdem(IOrdemDeServicoService ordemDeServicoService, IPagamentoService pagamentoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _ordemDeServicoService = ordemDeServicoService;
        _serviceProvider = serviceProvider;
    }

    public OrdemDeServicoViewModel OrdemAtual { get; set; }

    private async void BtnReceberPagamento_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            BtnReceberPagamento.Enabled = false;

            if (!decimal.TryParse(TxtEuroConcluirOrdem.Text.Replace('.', ','), out decimal valorRecebido))
                throw new InvalidOperationException("O formato do valor recebido está incorreto.");

            var pagamento = new Pagamento
            {
                OrdemDeServicoId = OrdemAtual.OrdemDeServicoId,
                Valor = valorRecebido,
                DataPagamento = DateTime.Now,
                MetodoPagamentoId = (long)(CmbMetodosDePagamentoConcluirOrdem.SelectedValue ?? throw new InvalidOperationException("Método de pagamento não selecionado ou inválido."))
            };

            var novoTotalDePagamentos = OrdemAtual.Pagamentos.Sum(p => p.Valor) + pagamento.Valor;

            if (novoTotalDePagamentos > OrdemAtual.ValorTotal)
                throw new InvalidOperationException($"O valor do pagamento excede o total da ordem. Excedente: {novoTotalDePagamentos - OrdemAtual.ValorTotal:C2}");

            OrdemAtual.Pagamentos.Add(pagamento);
            OrdemAtual.DataGarantia = DtpGarantiaConcluirOrdem.Value;
            OrdemAtual.ObservacoesGarantia = RTxtObservacoesGarantiaConcluirOrdem.Text == "Observações da garantia" ? null : RTxtObservacoesGarantiaConcluirOrdem.Text;
            await _ordemDeServicoService.UpdateOrdemAsync(OrdemAtual);

            MessageBox.Show($"Pagamento de {valorRecebido.ToString("C2")} recebido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao receber pagamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao receber pagamento: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao receber pagamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnReceberPagamento.Enabled = true;
        }
    }

    private bool CheckFields()
    {
        if (TxtEuroConcluirOrdem.Text == $"Total: {OrdemAtual.ValorTotal}")
        {
            MessageBox.Show("Digite uma quantia a ser recebida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (CmbMetodosDePagamentoConcluirOrdem.SelectedIndex == 0)
        {
            MessageBox.Show("Escolha um método de pagamento para o recebimento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private async void FormConcluirOrdem_Load(object sender, EventArgs e)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var metodoDePagamentoService = scope.ServiceProvider.GetRequiredService<IPagamentoService>();
            var metodosDePagamento = await metodoDePagamentoService.GetAllMetodosDePagamento();
            var listaDeMetodosDePagamento = new List<MetodoDePagamentoViewModel>
                {
                    new MetodoDePagamentoViewModel
                    {
                        MetodoPagamentoId = 0,
                        Nome = "Método de pagamento"
                    }
                };
            listaDeMetodosDePagamento.AddRange(metodosDePagamento);

            CmbMetodosDePagamentoConcluirOrdem.DataSource = listaDeMetodosDePagamento;
            CmbMetodosDePagamentoConcluirOrdem.DisplayMember = "Nome";
            CmbMetodosDePagamentoConcluirOrdem.ValueMember = "MetodoPagamentoId";
            CmbMetodosDePagamentoConcluirOrdem.SelectedIndex = 0;
        }

        TxtIdConcluirOrdem.Text = OrdemAtual.OrdemDeServicoId.ToString();
        TxtClienteConcluirOrdem.Text = OrdemAtual.NomeCliente;
        TxtVeiculoConcluirOrdem.Text = $"{OrdemAtual.Veiculo.Modelo} ({OrdemAtual.Veiculo.Matricula})";
        TxtEuroConcluirOrdem.Text = $"Total: {OrdemAtual.ValorTotal - OrdemAtual.Pagamentos.Sum(p => p.Valor)}";

        if (OrdemAtual.DataGarantia != null)
        {
            DtpGarantiaConcluirOrdem.Value = OrdemAtual.DataGarantia.Value;
            RTxtObservacoesGarantiaConcluirOrdem.Text = OrdemAtual.ObservacoesGarantia;
            RTxtObservacoesGarantiaConcluirOrdem.ForeColor = SystemColors.WindowText;
            if (RTxtObservacoesGarantiaConcluirOrdem.Text == "Sem observações")
            {
                RTxtObservacoesGarantiaConcluirOrdem.Text = "Observações da garantia";
                RTxtObservacoesGarantiaConcluirOrdem.ForeColor = Color.Gray;
            }
        }

        LoadItensIntoDgvOrcamentoConcluirOrdem(ConvertOrcamentosIntoOrcamentoViewModel(OrdemAtual.Orcamentos));
    }

    private List<OrcamentoViewModel> ConvertOrcamentosIntoOrcamentoViewModel(ICollection<Orcamento> orcamento)
    {
        var orcamentosConverted = OrdemAtual.Orcamentos.Select(o => new OrcamentoViewModel
        {
            OrcamentoId = o.OrcamentoId,
            OrdemDeServicoId = o.OrdemDeServicoId,
            StatusOrcamento = o.StatusOrcamento,
            DataCriacao = o.DataCriacao,
            Descricao = o.Descricao,
            OrdemDeServico = o.OrdemDeServico,
            ItensOrcamento = o.ItensOrcamento.Select(i => new ItemOrcamentoViewModel
            {
                ItemOrcamentoId = i.ItemOrcamentoId,
                OrcamentoId = i.OrcamentoId,
                Descricao = i.Descricao,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario,
                Margem = i.Margem * 100,
                FornecedorId = i.FornecedorId,
                Fornecedor = new FornecedorViewModel
                {
                    FornecedorId = i.FornecedorId,
                    Nome = i.Fornecedor.Nome,
                    Telemovel = i.Fornecedor.Telemovel,
                    Email = i.Fornecedor.Email,
                    EnderecoId = i.Fornecedor.EnderecoId,
                    Endereco = i.Fornecedor.Endereco,
                    EstoquePecas = i.Fornecedor.EstoquePecas,
                    ItensOrcamento = i.Fornecedor.ItensOrcamento,
                },
                Orcamento = i.Orcamento,
            }).ToList(),
        }).ToList();

        int novoNumero = 1;
        foreach (var orcamentoAtual in orcamentosConverted.OrderBy(o => o.Numero))
        {
            orcamentoAtual.Numero = novoNumero++;
        }

        return orcamentosConverted;
    }

    private void LoadItensIntoDgvOrcamentoConcluirOrdem(List<OrcamentoViewModel> orcamentos)
    {
        DgvOrcamentosConcluirOrdem.DataSource = null;
        DgvOrcamentosConcluirOrdem.DataSource = orcamentos;
        DgvOrcamentosConcluirOrdem.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosConcluirOrdem.Columns["OrdemDeServicoId"].Visible = false;
        DgvOrcamentosConcluirOrdem.Columns["StatusOrcamento"].Visible = true;
        DgvOrcamentosConcluirOrdem.Columns["OrdemDeServico"].Visible = false;
        DgvOrcamentosConcluirOrdem.Columns["ItensOrcamento"].Visible = false;
        DgvOrcamentosConcluirOrdem.Columns["StatusOrcamento"].Visible = false;
        DgvOrcamentosConcluirOrdem.Columns["Descricao"].Visible = false;
        DgvOrcamentosConcluirOrdem.Columns["VendaPecas"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["CustoPecas"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["LucroPecas"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["MaoDeObra"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["VendaTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["LucroTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["IVA"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosConcluirOrdem.Columns["Numero"].HeaderText = "Número";
        DgvOrcamentosConcluirOrdem.Columns["DataCriacao"].HeaderText = "Data de criação";
        DgvOrcamentosConcluirOrdem.Columns["NumeroDeItens"].HeaderText = "Itens";
        DgvOrcamentosConcluirOrdem.Columns["CustoPecas"].HeaderText = "Custo peças";
        DgvOrcamentosConcluirOrdem.Columns["VendaPecas"].HeaderText = "Venda peças";
        DgvOrcamentosConcluirOrdem.Columns["LucroPecas"].HeaderText = "Lucro peças";
        DgvOrcamentosConcluirOrdem.Columns["MaoDeObra"].HeaderText = "Mão de obra";
        DgvOrcamentosConcluirOrdem.Columns["VendaTotal"].HeaderText = "Venda total";
        DgvOrcamentosConcluirOrdem.Columns["LucroTotal"].HeaderText = "Lucro total";
        DgvOrcamentosConcluirOrdem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosConcluirOrdem.MultiSelect = false;
    }

    private void TxtEuroConcluirOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void TxtEuroConcluirOrdem_Enter(object sender, EventArgs e)
    {
        if (TxtEuroConcluirOrdem.Text == $"Total: {OrdemAtual.ValorTotal - OrdemAtual.Pagamentos.Sum(p => p.Valor)}")
        {
            TxtEuroConcluirOrdem.Text = null;
            TxtEuroConcluirOrdem.ForeColor = SystemColors.WindowText;
        }
    }

    private void TxtEuroConcluirOrdem_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtEuroConcluirOrdem.Text))
        {
            TxtEuroConcluirOrdem.Text = $"Total: {OrdemAtual.ValorTotal - OrdemAtual.Pagamentos.Sum(p => p.Valor)}";
            TxtEuroConcluirOrdem.ForeColor = Color.Gray;
        }
    }

    private void RTxtObservacoesGarantiaConcluirOrdem_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(RTxtObservacoesGarantiaConcluirOrdem.Text))
        {
            RTxtObservacoesGarantiaConcluirOrdem.Text = "Observações da garantia";
            RTxtObservacoesGarantiaConcluirOrdem.ForeColor = Color.Gray;
        }
    }

    private void RTxtObservacoesGarantiaConcluirOrdem_Enter(object sender, EventArgs e)
    {
        if (RTxtObservacoesGarantiaConcluirOrdem.Text == "Observações da garantia")
        {
            RTxtObservacoesGarantiaConcluirOrdem.Text = null;
            RTxtObservacoesGarantiaConcluirOrdem.ForeColor = SystemColors.WindowText;
        }
    }
}
