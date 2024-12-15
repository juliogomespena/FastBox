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

public partial class FormAtualizarOrcamento : Form
{
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;

    public FormAtualizarOrcamento(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    public OrcamentoViewModel OrcamentoAtual { get; set; }
    public ICollection<ItemOrcamentoViewModel> _items = [];

    private async void BtnAtualizarOrcamento_Click(object sender, EventArgs e)
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
                Descricao = RTxtDescricaoAtualizarOrcamento.Text,
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
        if (String.IsNullOrWhiteSpace(TxtItemAtualizarOrcamento.Text))
        {
            MessageBox.Show("Digite um item para o orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtQuantidadeAtualizarOrcamento.Text))
        {
            MessageBox.Show("Digite uma quantidade para o item do orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtPrecoUnitarioAtualizarOrcamento.Text))
        {
            MessageBox.Show("Digite o preço unitário para o item do orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtMargemAtualizarOrdem.Text))
        {
            MessageBox.Show("Digite a margem de lucro desejada para o item do orçamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private void TxtQuantidadeAtualizarOrcamento_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void FormAtualizarOrcamento_Load(object sender, EventArgs e)
    {
        RTxtDescricaoAtualizarOrcamento.Text = OrcamentoAtual.Descricao;
        _items = OrcamentoAtual.ItensOrcamento;
        LoadItemsIntoDgvOrcamentoAtualizar();
    }

    private void LoadItemsIntoDgvOrcamentoAtualizar()
    {
        DgvOrcamentosAtualizar.DataSource = null;
        DgvOrcamentosAtualizar.DataSource = _items.ToList();
        DgvOrcamentosAtualizar.Columns["ItemOrcamentoId"].Visible = false;
        DgvOrcamentosAtualizar.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosAtualizar.Columns["Orcamento"].Visible = false;
        DgvOrcamentosAtualizar.Columns["Margem"].Visible = false;
        DgvOrcamentosAtualizar.Columns["PrecoUnitario"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizar.Columns["ValorUnitario"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizar.Columns["ValorTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizar.Columns["CustoTotal"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizar.Columns["Lucro"].DefaultCellStyle.Format = "F2";
        DgvOrcamentosAtualizar.Columns["Descricao"].HeaderText = "Item";
        DgvOrcamentosAtualizar.Columns["PrecoUnitario"].HeaderText = "Custo";
        DgvOrcamentosAtualizar.Columns["ValorUnitario"].HeaderText = "Valor";
        DgvOrcamentosAtualizar.Columns["ValorTotal"].HeaderText = "Valor total";
        DgvOrcamentosAtualizar.Columns["CustoTotal"].HeaderText = "Custo total";
        DgvOrcamentosAtualizar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosAtualizar.MultiSelect = false;
    }

    private void BtnIncluirItemAtualizarOrcamento_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            var item = new ItemOrcamentoViewModel
            {
                Descricao = TxtItemAtualizarOrcamento.Text.Trim(),
                Quantidade = int.TryParse(TxtQuantidadeAtualizarOrcamento.Text, out int qtd) ? qtd : throw new FormatException("Erro ao processar a quantidade do item."),
                PrecoUnitario = decimal.TryParse(TxtPrecoUnitarioAtualizarOrcamento.Text.Replace('.', ','), out decimal precoUnitario) ? precoUnitario : throw new FormatException("Erro ao processar preço unitário do item."),
                Margem = decimal.TryParse(TxtMargemAtualizarOrdem.Text, out decimal margem) ? margem : throw new FormatException("Erro ao processar a margem do item.")
            };

            _items.Add(item);
            LoadItemsIntoDgvOrcamentoAtualizar();

            TxtItemAtualizarOrcamento.Clear();
            TxtQuantidadeAtualizarOrcamento.Clear();
            TxtPrecoUnitarioAtualizarOrcamento.Clear();
            TxtMargemAtualizarOrdem.Clear();
            TxtPrecoUnitarioFinalAtualizarOrcamento.Clear();
            TxtPrecoFinalTotalAtualizarOrcamento.Clear();
            TxtItemAtualizarOrcamento.Focus();
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao incluir item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtMargemAtualizarOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void TxtPrecoUnitarioAtualizarOrcamento_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void TxtMargemAtualizarOrdem_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(TxtPrecoUnitarioAtualizarOrcamento.Text) && !String.IsNullOrWhiteSpace(TxtMargemAtualizarOrdem.Text))
        {
            decimal margem = decimal.TryParse(TxtMargemAtualizarOrdem.Text, out decimal margemValue) ? margemValue / 100 : 0;


            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioAtualizarOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;

            TxtPrecoUnitarioFinalAtualizarOrcamento.Text = (precoUnitario + (precoUnitario * margem)).ToString("F2");
        }
        if (!String.IsNullOrWhiteSpace(TxtPrecoUnitarioAtualizarOrcamento.Text) && !String.IsNullOrWhiteSpace(TxtMargemAtualizarOrdem.Text) && !String.IsNullOrWhiteSpace(TxtQuantidadeAtualizarOrcamento.Text))
        {
            decimal margem = decimal.TryParse(TxtMargemAtualizarOrdem.Text, out decimal margemValue) ? margemValue / 100 : 0;


            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioAtualizarOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;

            int quantidade = int.TryParse(TxtQuantidadeAtualizarOrcamento.Text, out int qtd) ? qtd : 0;

            TxtPrecoFinalTotalAtualizarOrcamento.Text = ((precoUnitario + (precoUnitario * margem)) * quantidade).ToString("F2");
        }
    }

    private void BtnExcluirItemAtualizarOrcamento_Click(object sender, EventArgs e)
    {
        if (DgvOrcamentosAtualizar.CurrentRow == null)
        {
            MessageBox.Show("Selecione um item para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            int selectedIndex = DgvOrcamentosAtualizar.CurrentRow.Index;

            if (selectedIndex >= 0 && selectedIndex < _items.Count)
            {
                var selectedItem = DgvOrcamentosAtualizar.CurrentRow.DataBoundItem as ItemOrcamentoViewModel;
                if (selectedItem != null)
                {
                    _items.Remove(selectedItem);
                }

                LoadItemsIntoDgvOrcamentoAtualizar();
                MessageBox.Show("Item excluído com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao excluir item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
