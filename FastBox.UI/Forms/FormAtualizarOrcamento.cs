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

public partial class FormAtualizarOrcamento : Form
{
    private readonly IServiceProvider _serviceProvider;
    private System.Windows.Forms.Timer _debounceTimer;
    private bool _isUpdatingText = false;
    private FornecedorViewModel? _fornecedor;
    private long _tempItemId = -1;

    public FormAtualizarOrcamento(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    public OrcamentoViewModel OrcamentoAtual { get; set; }
    public ICollection<ItemOrcamentoViewModel> _items = [];
    public bool IsOrdemCancelledCompletedOrAwaitingPayment = false;

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

    private void SetAllControlsEnabled(Control parent, bool enabled)
    {
        TxtItemAtualizarOrcamento.Enabled = enabled;
        ChkMaoDeObra.Enabled = enabled;
        TxtQuantidadeAtualizarOrcamento.Enabled = enabled;
        TxtPrecoUnitarioAtualizarOrcamento.Enabled = enabled;
        TxtMargemAtualizarOrdem.Enabled = enabled;
        TxtPrecoFinalTotalAtualizarOrcamento.Enabled = enabled;
        TxtPrecoUnitarioFinalAtualizarOrcamento.Enabled = enabled;
        TxtFornecedorAtualizarOrcamento.Enabled = enabled;
        BtnIncluirItemAtualizarOrcamento.Enabled = enabled;
        BtnExcluirItemAtualizarOrcamento.Enabled = enabled;
        RTxtDescricaoAtualizarOrcamento.Enabled = enabled;
        BtnAtualizarOrcamento.Enabled = enabled;
        TxtFaturaAtualizarOrdem.Enabled = enabled;
        DgvOrcamentosAtualizar.Enabled = true;
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
        if (String.IsNullOrWhiteSpace(TxtFornecedorAtualizarOrcamento.Text) || _fornecedor == null)
        {
            MessageBox.Show("Erro ao selecionar fornecedor do item, tente novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        if (IsOrdemCancelledCompletedOrAwaitingPayment)
            SetAllControlsEnabled(this, false);

        RTxtDescricaoAtualizarOrcamento.Text = OrcamentoAtual.Descricao;
        _items = OrcamentoAtual.ItensOrcamento;
        LoadItemsIntoDgvOrcamentoAtualizar();
        TxtPrecoUnitarioFinalAtualizarOrcamento.Text = 0.ToString("C2");
        TxtPrecoFinalTotalAtualizarOrcamento.Text = 0.ToString("C2");
        LstSugestoesFornecedores.Width = 457;
    }

    private void LoadItemsIntoDgvOrcamentoAtualizar()
    {
        DgvOrcamentosAtualizar.DataSource = null;
        DgvOrcamentosAtualizar.DataSource = _items.ToList();
        DgvOrcamentosAtualizar.Columns["ItemOrcamentoId"].Visible = false;
        DgvOrcamentosAtualizar.Columns["OrcamentoId"].Visible = false;
        DgvOrcamentosAtualizar.Columns["Orcamento"].Visible = false;
        DgvOrcamentosAtualizar.Columns["Margem"].Visible = false;
        DgvOrcamentosAtualizar.Columns["FornecedorId"].Visible = false;
        DgvOrcamentosAtualizar.Columns["Fornecedor"].Visible = false;
        DgvOrcamentosAtualizar.Columns["PrecoUnitario"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizar.Columns["ValorUnitario"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizar.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizar.Columns["CustoTotal"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizar.Columns["Lucro"].DefaultCellStyle.Format = "C2";
        DgvOrcamentosAtualizar.Columns["Descricao"].HeaderText = "Item";
        DgvOrcamentosAtualizar.Columns["Quantidade"].HeaderText = "Quant.";
        DgvOrcamentosAtualizar.Columns["PrecoUnitario"].HeaderText = "Custo";
        DgvOrcamentosAtualizar.Columns["CustoTotal"].HeaderText = "Custo T.";
        DgvOrcamentosAtualizar.Columns["ValorUnitario"].HeaderText = "Venda Un.";
        DgvOrcamentosAtualizar.Columns["ValorTotal"].HeaderText = "Venda T.";
        DgvOrcamentosAtualizar.Columns["NomeFornecedor"].HeaderText = "Fornecedor";
        DgvOrcamentosAtualizar.Columns["NumeroFatura"].HeaderText = "Fatura";

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
                ItemOrcamentoId = _tempItemId--,
                Descricao = TxtItemAtualizarOrcamento.Text.Trim(),
                Quantidade = int.TryParse(TxtQuantidadeAtualizarOrcamento.Text, out int qtd) ? qtd : throw new FormatException("Erro ao processar a quantidade do item."),
                PrecoUnitario = decimal.TryParse(TxtPrecoUnitarioAtualizarOrcamento.Text.Replace('.', ','), out decimal precoUnitario) ? precoUnitario : throw new FormatException("Erro ao processar preço unitário do item."),
                Margem = decimal.TryParse(TxtMargemAtualizarOrdem.Text, out decimal margem) ? margem : throw new FormatException("Erro ao processar a margem do item."),
                FornecedorId = _fornecedor.FornecedorId,
                Fornecedor = _fornecedor,
                NumeroFatura = int.TryParse(TxtFaturaAtualizarOrdem.Text, out int fatura) ? fatura : throw new FormatException("Erro ao processar número da fatura do item."),
            };

            _items.Add(item);
            LoadItemsIntoDgvOrcamentoAtualizar();

            TxtItemAtualizarOrcamento.Clear();
            TxtQuantidadeAtualizarOrcamento.Clear();
            TxtPrecoUnitarioAtualizarOrcamento.Clear();
            TxtMargemAtualizarOrdem.Clear();
            TxtPrecoUnitarioFinalAtualizarOrcamento.Clear();
            TxtPrecoFinalTotalAtualizarOrcamento.Clear();
            TxtFaturaAtualizarOrdem.Clear();
            TxtFornecedorAtualizarOrcamento.Clear();
            TxtItemAtualizarOrcamento.Focus();
            ChkMaoDeObra.Checked = false;
            _fornecedor = null;
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao incluir item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtMargemAtualizarOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            e.Handled = true;

        if (e.KeyChar == '.')
            e.KeyChar = ',';
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

            TxtPrecoUnitarioFinalAtualizarOrcamento.Text = Math.Round((precoUnitario + (precoUnitario * margem)), 2, MidpointRounding.AwayFromZero).ToString("C2");
        }
        if (!String.IsNullOrWhiteSpace(TxtPrecoUnitarioAtualizarOrcamento.Text) && !String.IsNullOrWhiteSpace(TxtMargemAtualizarOrdem.Text) && !String.IsNullOrWhiteSpace(TxtQuantidadeAtualizarOrcamento.Text))
        {
            decimal margem = decimal.TryParse(TxtMargemAtualizarOrdem.Text, out decimal margemValue) ? margemValue / 100 : 0;


            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioAtualizarOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;

            int quantidade = int.TryParse(TxtQuantidadeAtualizarOrcamento.Text, out int qtd) ? qtd : 0;

            TxtPrecoFinalTotalAtualizarOrcamento.Text = Math.Round(((precoUnitario + (precoUnitario * margem)) * quantidade), 2, MidpointRounding.AwayFromZero).ToString("C2");
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

    private async void ChkMaoDeObra_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkMaoDeObra.Checked == true)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var fornecedorService = scope.ServiceProvider.GetRequiredService<IFornecedorService>();
                    var fornecedor = await fornecedorService.GetFornecedorByNameAsync("FastBox");
                    _fornecedor = fornecedor;
                    TxtFornecedorAtualizarOrcamento.Text = fornecedor.InfoFornecedor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar oficina como fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChkMaoDeObra.Checked = false;
            }
        }

        TxtItemAtualizarOrcamento.Enabled = !ChkMaoDeObra.Checked;
        TxtMargemAtualizarOrdem.Enabled = !ChkMaoDeObra.Checked;
        TxtFornecedorAtualizarOrcamento.Enabled = !ChkMaoDeObra.Checked;
        TxtFaturaAtualizarOrdem.Enabled = !ChkMaoDeObra.Checked;

        TxtItemAtualizarOrcamento.Text = ChkMaoDeObra.Checked ? "Mão de obra" : "";
        TxtMargemAtualizarOrdem.Text = ChkMaoDeObra.Checked ? "0" : "";
        TxtFaturaAtualizarOrdem.Text = "0001";
    }

    private void TxtPrecoUnitarioAtualizarOrcamento_TextChanged(object sender, EventArgs e)
    {
        if (ChkMaoDeObra.Checked == true)
        {
            decimal precoUnitario = decimal.TryParse(TxtPrecoUnitarioAtualizarOrcamento.Text.Replace('.', ','), out decimal precoUnitarioValue) ? precoUnitarioValue : 0;
            int quantidade = int.TryParse(TxtQuantidadeAtualizarOrcamento.Text, out int qtd) ? qtd : 0;
            TxtPrecoUnitarioFinalAtualizarOrcamento.Text = precoUnitario.ToString("C2");
            TxtPrecoFinalTotalAtualizarOrcamento.Text = (precoUnitario * quantidade).ToString("C2");
        }
    }

    private void TxtFornecedorAtualizarOrcamento_TextChanged(object sender, EventArgs e)
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
                string searchText = TxtFornecedorAtualizarOrcamento.Text.Trim();

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
                TxtFornecedorAtualizarOrcamento.Text = fornecedorSelecionado.InfoFornecedor;
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
            TxtFornecedorAtualizarOrcamento.Text = fornecedorSelecionado.InfoFornecedor;
            _isUpdatingText = false;
            LstSugestoesFornecedores.Visible = false;
            _fornecedor = fornecedorSelecionado;
        }
    }

    private void TxtFaturaAtualizarOrdem_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }
}
