using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormCadastrarFornecedor : Form
{
    private readonly IConcelhoService _concelhoService;
    private readonly IEnderecoService _enderecoService;
    private readonly IFornecedorService _fornecedorService;

    public FormCadastrarFornecedor(IConcelhoService concelhoService, IEnderecoService enderecoService, IFornecedorService fornecedorService)
    {
        InitializeComponent();
        _enderecoService = enderecoService;
        _concelhoService = concelhoService;
        _fornecedorService = fornecedorService;
    }

    private async void FormCadastrarFornecedor_Load(object sender, EventArgs e)
    {
        try
        {
            var concelhos = await _concelhoService.GetAllConcelhosAsync();

            CmbConcelho.DataSource = concelhos;
            CmbConcelho.DisplayMember = "Nome";
            CmbConcelho.ValueMember = "ConcelhoId";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar concelhos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool CheckFields()
    {
        if (String.IsNullOrWhiteSpace(TxtNome.Text))
        {
            MessageBox.Show("Digite um nome para o fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (TxtMskTelemovel.Text.Length != 16)
        {
            MessageBox.Show("Digite um telemóvel válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (ChkCadastrarEndereco.Checked)
        {
            if (String.IsNullOrWhiteSpace(TxtLogradouro.Text))
            {
                MessageBox.Show("Digite o logradouro do endereço do fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(TxtNumeroEndereco.Text))
            {
                MessageBox.Show("Digite um número para o endereço do fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(TxtFreguesia.Text))
            {
                MessageBox.Show("Digite a freguesia do endereço do fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (TxtMskCodigoPostal.Text.Length != 8)
            {
                MessageBox.Show("Digite um código postal válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        return true;
    }

    private async void BtnCadastrarFornecedor_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            long? enderecoId = null;

            BtnCadastrarFornecedor.Enabled = false;

            if (ChkCadastrarEndereco.Checked)
            {
                if (CmbConcelho.SelectedItem is Concelho concelhoSelecionado)
                {
                    var endereco = new Endereco
                    {
                        Logradouro = TxtLogradouro.Text.Trim(),
                        Numero = TxtNumeroEndereco.Text.Trim(),
                        Complemento = TxtComplemento.Text.Trim(),
                        Freguesia = TxtFreguesia.Text.Trim(),
                        CodigoPostal = TxtMskCodigoPostal.Text.Trim(),
                        ConcelhoId = concelhoSelecionado.ConcelhoId,
                        Pais = TxtPais.Text.Trim()
                    };

                    enderecoId = await _enderecoService.AddEnderecoAsync(endereco);
                }
                else
                {
                    MessageBox.Show("Selecione um concelho válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            var fornecedor = new FornecedorViewModel
            {
                Nome = TxtNome.Text.Trim(),
                Telemovel = TxtMskTelemovel.Text.Trim(),
                Email = TxtEmail.Text.Trim(),
                EnderecoId = enderecoId,
            };

            await _fornecedorService.AddFornecedorAsync(fornecedor);

            MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao cadastrar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao cadastrar fornecedor: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao cadastrar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnCadastrarFornecedor.Enabled = true;
        }
    }

    private void ChkCadastrarEndereco_CheckedChanged_1(object sender, EventArgs e)
    {
        PanelEnderecoFornecedor.Enabled = ChkCadastrarEndereco.Checked;
    }
}
