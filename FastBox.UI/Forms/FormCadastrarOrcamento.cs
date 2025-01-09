using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormCadastrarOrcamento : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IFornecedorService _fornecedorService;
    private System.Windows.Forms.Timer _debounceTimer;
    private ICollection<ItemOrcamentoViewModel> _items = [];
    private bool _isUpdatingText = false;
    private FornecedorViewModel? _fornecedor;

    public FormCadastrarOrcamento(IServiceProvider serviceProvider, IFornecedorService fornecedorService)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _fornecedorService = fornecedorService;
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
        if (String.IsNullOrWhiteSpace(TxtFornecedorCadastroOrcamento.Text) || _fornecedor == null)
        {
            MessageBox.Show("Erro ao selecionar fornecedor do item, tente novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        LstSugestoesFornecedores.Width = 457;
    }

    private void LoadItemsIntoDgvOrcamentoCadastro()
    {
        DgvOrcamentosCadastro.DataSource = null;
        DgvOrcamentosCadastro.DataSource = _items.ToList();
        DgvOrcamentosCadastro.Columns["ItemOrcamentoId"].Visible = false;
        DgvOrcamentosCadastro.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosCadastro.Columns["Orcamento"].Visible = false;
        DgvOrcamentosCadastro.Columns["Margem"].Visible = false;
        DgvOrcamentosCadastro.Columns["FornecedorId"].Visible = false;
        DgvOrcamentosCadastro.Columns["Fornecedor"].Visible = false;
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
        DgvOrcamentosCadastro.Columns["NomeFornecedor"].HeaderText = "Fornecedor";
        DgvOrcamentosCadastro.Columns["NumeroFatura"].HeaderText = "Fatura";
        DgvOrcamentosCadastro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvOrcamentosCadastro.MultiSelect = false;
    }

    private async void BtnIncluirItemCadastroOrcamento_Click(object sender, EventArgs e)
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
                Margem = decimal.TryParse(TxtMargemCadastroOrdem.Text, out decimal margem) ? margem : throw new FormatException("Erro ao processar a margem do item."),
                FornecedorId = _fornecedor.FornecedorId,
                Fornecedor = _fornecedor,
                NumeroFatura = int.TryParse(TxtFaturaCadastroOrdem.Text, out int fatura) ? fatura : throw new FormatException("Erro ao processar número da fatura do item."),
            };

            _items.Add(item);
            LoadItemsIntoDgvOrcamentoCadastro();

            TxtItemCadastroOrcamento.Clear();
            TxtQuantidadeCadastroOrcamento.Clear();
            TxtPrecoUnitarioCadastroOrcamento.Clear();
            TxtMargemCadastroOrdem.Clear();
            TxtPrecoUnitarioFinalCadastroOrcamento.Clear();
            TxtPrecoFinalTotalCadastroOrcamento.Clear();
            TxtFornecedorCadastroOrcamento.Clear();
            TxtFaturaCadastroOrdem.Clear();
            TxtItemCadastroOrcamento.Focus();
            ChkMaoDeObra.Checked = false;
            _fornecedor = null;
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao incluir item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtMargemCadastroOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            e.Handled = true;

        if (e.KeyChar == '.')
            e.KeyChar = ',';
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

    private async void ChkMaoDeObra_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkMaoDeObra.Checked == true)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var fornecedorService = scope.ServiceProvider.GetRequiredService<IFornecedorService>();
                    _fornecedor = await fornecedorService.GetFornecedorByNameAsync("FastBox");
                    TxtFornecedorCadastroOrcamento.Text = _fornecedor.InfoFornecedor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar oficina como fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChkMaoDeObra.Checked = false;
            }
        }

        TxtItemCadastroOrcamento.Enabled = !ChkMaoDeObra.Checked;
        TxtMargemCadastroOrdem.Enabled = !ChkMaoDeObra.Checked;
        TxtFornecedorCadastroOrcamento.Enabled = !ChkMaoDeObra.Checked;

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

    private void TxtFornecedorCadastroOrcamento_TextChanged(object sender, EventArgs e)
    {
        if (_isUpdatingText) return;

        if (ChkMaoDeObra.Checked == true)
            return;

        _fornecedor = null;

        _debounceTimer?.Stop();
        _debounceTimer = new System.Windows.Forms.Timer { Interval = GlobalConfiguration.debounceTimeMiliseconds };
        _debounceTimer.Tick += async (s, ev) =>
        {
            _debounceTimer.Stop();

            try
            {
                string searchText = TxtFornecedorCadastroOrcamento.Text.Trim();

                if (searchText.Length >= 2)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var fornecedorService = scope.ServiceProvider.GetRequiredService<IFornecedorService>();
                        var fornecedores = await fornecedorService.GetFornecedoresByNameAsync(searchText);

                        LstSugestoesFornecedores.DataSource = fornecedores.ToList();
                        LstSugestoesFornecedores.DisplayMember = "InfoFornecedor";
                        LstSugestoesFornecedores.ValueMember = "FornecedorId";
                        AdjustListBoxSize(LstSugestoesFornecedores);
                        LstSugestoesFornecedores.Visible = fornecedores.Any();
                        LstSugestoesFornecedores.Focus();
                        if (LstSugestoesFornecedores.SelectedItem is FornecedorViewModel fornecedorSelecionado)
                            _fornecedor = fornecedorSelecionado;
                    }
                }
                else
                {
                    _fornecedor = null;
                    LstSugestoesFornecedores.DataSource = null;
                    LstSugestoesFornecedores.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        _debounceTimer.Start();
    }

    private void AdjustListBoxSize(ListBox listBox)
    {
        if (listBox.Items.Count == 0)
        {
            listBox.Visible = false;
            return;
        }

        int maxVisibleItems = 5;
        int itemHeight = listBox.ItemHeight;
        int borderHeight = 2;
        int padding = 4;

        int visibleItems = Math.Min(listBox.Items.Count, maxVisibleItems);
        listBox.Height = (itemHeight * visibleItems) + borderHeight + padding;

        listBox.Visible = true;
    }

    private void LstSugestoesFornecedores_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (LstSugestoesFornecedores.SelectedItem is FornecedorViewModel fornecedorSelecionado)
            {
                _isUpdatingText = true;
                TxtFornecedorCadastroOrcamento.Text = fornecedorSelecionado.InfoFornecedor;
                _isUpdatingText = false;
                LstSugestoesFornecedores.Visible = false;
                _fornecedor = fornecedorSelecionado;
            }
        }
    }

    private void LstSugestoesFornecedores_Click(object sender, EventArgs e)
    {
        if (LstSugestoesFornecedores.SelectedItem is FornecedorViewModel fornecedorSelecionado)
        {
            _isUpdatingText = true;
            TxtFornecedorCadastroOrcamento.Text = fornecedorSelecionado.InfoFornecedor;
            _isUpdatingText = false;
            LstSugestoesFornecedores.Visible = false;
            _fornecedor = fornecedorSelecionado;
        }
    }

    private void TxtFaturaCadastroOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }
}
