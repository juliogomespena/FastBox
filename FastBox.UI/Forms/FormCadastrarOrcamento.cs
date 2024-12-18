using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormCadastrarOrcamento : Form
{
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private ICollection<ItemOrcamentoViewModel> _items = [];

    public FormCadastrarOrcamento(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    public OrcamentoViewModel OrcamentoAtual { get; private set; }

    private async void BtnGerarOrcamento_Click(object sender, EventArgs e)
    {
        if (_items == null || !_items.Any())
        {
            MessageBox.Show("Adicione pelo menos um item ao orçamento antes de gerar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            OrcamentoAtual = new OrcamentoViewModel
            {
                StatusOrcamento = 1,
                Descricao = RTxtDescricaoCadastroOrcamento.Text,
                ItensOrcamento = _items.ToList(),
                DataCriacao = DateTime.Now
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao gerar orçamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(TxtItemCadastroOrcamento.Text))
        {
            MessageBox.Show("Digite um item para o orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtQuantidadeCadastroOrcamento.Text))
        {
            MessageBox.Show("Digite uma quantidade para o item do orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtPrecoUnitarioCadastroOrcamento.Text))
        {
            MessageBox.Show("Digite o preço unitário para o item do orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtMargemCadastroOrdem.Text))
        {
            MessageBox.Show("Digite a margem de lucro desejada para o item do orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private void TxtQuantidadeCadastroOrcamento_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void FormCadastrarOrcamento_Load(object sender, EventArgs e)
    {
        LoadItemsIntoDgvOrcamentoCadastro();
        TxtPrecoUnitarioFinalCadastroOrcamento.Text = 0.ToString("C2");
        TxtPrecoFinalTotalCadastroOrcamento.Text = 0.ToString("C2");
    }

    private void LoadItemsIntoDgvOrcamentoCadastro()
    {
        DgvOrcamentosCadastro.DataSource = null;
        DgvOrcamentosCadastro.DataSource = _items.ToList();
        DgvOrcamentosCadastro.Columns["ItemOrcamentoId"].Visible = false;
        DgvOrcamentosCadastro.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosCadastro.Columns["Orcamento"].Visible = false;
        DgvOrcamentosCadastro.Columns["Margem"].Visible = false;
        DgvOrcamentosCadastro.Columns["PrecoUnitario"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastro.Columns["ValorUnitario"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastro.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastro.Columns["CustoTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastro.Columns["Lucro"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosCadastro.Columns["Descricao"].HeaderText = "Item";
        DgvOrcamentosCadastro.Columns["PrecoUnitario"].HeaderText = "Custo unitário";
        DgvOrcamentosCadastro.Columns["ValorUnitario"].HeaderText = "Venda unitário";
        DgvOrcamentosCadastro.Columns["ValorTotal"].HeaderText = "Venda total";
        DgvOrcamentosCadastro.Columns["CustoTotal"].HeaderText = "Custo total";
        DgvOrcamentosCadastro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosCadastro.MultiSelect = false;
    }

    private void BtnIncluirItemCadastroOrcamento_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            var item = new ItemOrcamentoViewModel
            {
                Descricao = TxtItemCadastroOrcamento.Text.Trim(),
                Quantidade = int.TryParse(TxtQuantidadeCadastroOrcamento.Text, out int qtd) ? qtd : throw new FormatException("Erro ao processar a quantidade do item."),
                PrecoUnitario = decimal.TryParse(TxtPrecoUnitarioCadastroOrcamento.Text.Replace('.', ','), out decimal precoUnitario) ? precoUnitario : throw new FormatException("Erro ao processar preço unitário do item."),
                Margem = decimal.TryParse(TxtMargemCadastroOrdem.Text, out decimal margem) ? margem : throw new FormatException("Erro ao processar a margem do item.")
            };

            _items.Add(item);
            LoadItemsIntoDgvOrcamentoCadastro();

            TxtItemCadastroOrcamento.Clear();
            TxtQuantidadeCadastroOrcamento.Clear();
            TxtPrecoUnitarioCadastroOrcamento.Clear();
            TxtMargemCadastroOrdem.Clear();
            TxtPrecoUnitarioFinalCadastroOrcamento.Clear();
            TxtPrecoFinalTotalCadastroOrcamento.Clear();
            TxtItemCadastroOrcamento.Focus();
            ChkMaoDeObra.Checked = false;
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao incluir item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtMargemCadastroOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void TxtPrecoUnitarioCadastroOrcamento_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void TxtMargemCadastroOrdem_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(TxtPrecoUnitarioCadastroOrcamento.Text) && !String.IsNullOrWhiteSpace(TxtMargemCadastroOrdem.Text))
        {
            decimal margem = decimal.TryParse(TxtMargemCadastroOrdem.Text, out decimal margemValue) ? margemValue / 100 : 0;


            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioCadastroOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;

            TxtPrecoUnitarioFinalCadastroOrcamento.Text = (precoUnitario + (precoUnitario * margem)).ToString("C2");
        }
        if (!String.IsNullOrWhiteSpace(TxtPrecoUnitarioCadastroOrcamento.Text) && !String.IsNullOrWhiteSpace(TxtMargemCadastroOrdem.Text) && !String.IsNullOrWhiteSpace(TxtQuantidadeCadastroOrcamento.Text))
        {
            decimal margem = decimal.TryParse(TxtMargemCadastroOrdem.Text, out decimal margemValue) ? margemValue / 100 : 0;


            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioCadastroOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;

            int quantidade = int.TryParse(TxtQuantidadeCadastroOrcamento.Text, out int qtd) ? qtd : 0;

            TxtPrecoFinalTotalCadastroOrcamento.Text = ((precoUnitario + (precoUnitario * margem)) * quantidade).ToString("C2");
        }
    }

    private void BtnExcluirItemCadastroOrcamento_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosCadastro.CurrentRow == null)
        {
            MessageBox.Show("Selecione um item para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            int selectedIndex = DgvOrcamentosCadastro.CurrentRow.Index;

            if (selectedIndex >= 0 && selectedIndex < _items.Count)
            {
                var selectedItem = DgvOrcamentosCadastro.CurrentRow.DataBoundItem as ItemOrcamentoViewModel;
                if (selectedItem != null)
                {
                    _items.Remove(selectedItem);
                }

                LoadItemsIntoDgvOrcamentoCadastro();
                MessageBox.Show("Item excluído com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao excluir item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    private void ChkMaoDeObra_CheckedChanged(object sender, EventArgs e)
    {
        TxtItemCadastroOrcamento.Enabled = !ChkMaoDeObra.Checked;
        TxtMargemCadastroOrdem.Enabled = !ChkMaoDeObra.Checked;

        TxtItemCadastroOrcamento.Text = ChkMaoDeObra.Checked ? "Mão de obra" : "";
        TxtMargemCadastroOrdem.Text = ChkMaoDeObra.Checked ? "0" : "";
    }

    private void TxtPrecoUnitarioCadastroOrcamento_TextChanged(object sender, EventArgs e)
    {
        if (ChkMaoDeObra.Checked == true)
        {
            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioCadastroOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;
            int quantidade = int.TryParse(TxtQuantidadeCadastroOrcamento.Text, out int qtd) ? qtd : 0;
            TxtPrecoUnitarioFinalCadastroOrcamento.Text = precoUnitario.ToString("C2");
            TxtPrecoFinalTotalCadastroOrcamento.Text = (precoUnitario * quantidade).ToString("C2");
        }
    }
}
