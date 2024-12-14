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
    private readonly IOrcamentoService _orcamentoService;
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private ICollection<ItemOrcamentoViewModel> _items = [];

    public FormCadastrarOrcamento(IOrcamentoService orcamentoService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _orcamentoService = orcamentoService;
        _serviceProvider = serviceProvider;
    }

    private async void BtnGerarOrcamento_Click(object sender, EventArgs e)
    {

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
    }

    private void LoadItemsIntoDgvOrcamentoCadastro()
    {
        DgvOrcamentosCadastro.DataSource = null;
        DgvOrcamentosCadastro.DataSource = _items.ToList();
        DgvOrcamentosCadastro.Columns["ItemOrcamentoId"].Visible = false;
        DgvOrcamentosCadastro.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosCadastro.Columns["Orcamento"].Visible = false;
        DgvOrcamentosCadastro.Columns["Margem"].Visible = false;
        DgvOrcamentosCadastro.Columns["PrecoUnitario"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosCadastro.Columns["PrecoFinalUnitario"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosCadastro.Columns["PrecoFinalTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosCadastro.Columns["Descricao"].HeaderText = "Item";
        DgvOrcamentosCadastro.Columns["PrecoUnitario"].HeaderText = "Custo unitário";
        DgvOrcamentosCadastro.Columns["PrecoFinalUnitario"].HeaderText = "Preço final unitário";
        DgvOrcamentosCadastro.Columns["PrecoFinalTotal"].HeaderText = "Total";
        DgvOrcamentosCadastro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosCadastro.MultiSelect = false;
    }

    private void BtnIncluirItemCadastroOrcamento_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

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

            TxtPrecoUnitarioFinalCadastroOrcamento.Text = (precoUnitario + (precoUnitario * margem)).ToString("F2");
        }
        if (!String.IsNullOrWhiteSpace(TxtPrecoUnitarioCadastroOrcamento.Text) && !String.IsNullOrWhiteSpace(TxtMargemCadastroOrdem.Text) && !String.IsNullOrWhiteSpace(TxtQuantidadeCadastroOrcamento.Text))
        {
            decimal margem = decimal.TryParse(TxtMargemCadastroOrdem.Text, out decimal margemValue) ? margemValue / 100 : 0;


            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioCadastroOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;

            int quantidade = int.TryParse(TxtQuantidadeCadastroOrcamento.Text, out int qtd) ? qtd : 0;

            TxtPrecoFinalTotalCadastroOrcamento.Text = ((precoUnitario + (precoUnitario * margem)) * quantidade).ToString("F2");
        }
    }

    private void BtnExcluirItemCadastroOrcamento_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosCadastro.CurrentRow == null)
        {
            MessageBox.Show("Selecione um item para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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
}
