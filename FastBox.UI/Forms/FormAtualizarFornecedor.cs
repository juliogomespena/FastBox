using FastBox.BLL.DTOs;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormAtualizarFornecedor : Form
{
    private readonly IConcelhoService _concelhoService;
    private readonly IEnderecoService _enderecoService;
    private readonly IFornecedorService _fornecedorService;
    private bool _isHandlingCheckboxChange = false;

    public FormAtualizarFornecedor(IConcelhoService concelhoService, IEnderecoService enderecoService, IFornecedorService fornecedorService)
    {
        InitializeComponent();
        _enderecoService = enderecoService;
        _concelhoService = concelhoService;
        _fornecedorService = fornecedorService;
    }

    public long FornecedorId { private get; set; }

    private async void FormAtualizarFornecedor_Load(object sender, EventArgs e)
    {
        try
        {
            var concelhos = await _concelhoService.GetAllConcelhosAsync();

            CmbConcelho.DataSource = concelhos;
            CmbConcelho.DisplayMember = "Nome";
            CmbConcelho.ValueMember = "ConcelhoId";

            var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(FornecedorId);

            if (fornecedor == null)
            {
                MessageBox.Show("Fornecedor não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            TxtNome.Text = fornecedor.Nome;
            TxtMskTelemovel.Text = fornecedor.Telemovel;
            TxtEmail.Text = fornecedor.Email;

            PanelInfoFornecedor.Enabled = true;

            if (fornecedor.Endereco != null)
            {
                ChkAtualizarEndereco.Checked = true;
                PanelEnderecoFornecedor.Enabled = true;

                TxtLogradouro.Text = fornecedor.Endereco.Logradouro;
                TxtNumeroEndereco.Text = fornecedor.Endereco.Numero;
                TxtComplemento.Text = fornecedor.Endereco.Complemento;
                TxtFreguesia.Text = fornecedor.Endereco.Freguesia;
                TxtMskCodigoPostal.Text = fornecedor.Endereco.CodigoPostal;
                CmbConcelho.SelectedValue = fornecedor.Endereco.ConcelhoId;
                TxtPais.Text = fornecedor.Endereco.Pais;
            }
            else
            {
                ChkAtualizarEndereco.Checked = false;
                PanelEnderecoFornecedor.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar informações do fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        if (ChkAtualizarEndereco.Checked)
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

    private async void BtnAtualizarFornecedor_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            BtnAtualizarFornecedor.Enabled = false;

            var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(FornecedorId);
            Endereco? enderecoExistente = null;
            long? enderecoId = null;

            if (ChkAtualizarEndereco.Checked)
            {
                if (CmbConcelho.SelectedItem is Concelho concelhoSelecionado)
                {
                    if (fornecedor.EnderecoId == null)
                    {
                        var endereco = new Endereco
                        {
                            Logradouro = TxtLogradouro.Text.Trim(),
                            Numero = TxtNumeroEndereco.Text.Trim(),
                            Complemento = TxtComplemento.Text.Trim(),
                            Freguesia = TxtFreguesia.Text.Trim(),
                            CodigoPostal = TxtMskCodigoPostal.Text.Trim(),
                            ConcelhoId = concelhoSelecionado.ConcelhoId,
                            Pais = TxtPais.Text.Trim(),
                        };
                        enderecoId = await _enderecoService.AddEnderecoAsync(endereco);
                    }
                    else
                    {
                        enderecoExistente = await _enderecoService.GetEnderecoByIdAsync((long)fornecedor.EnderecoId);
                        enderecoExistente.Logradouro = TxtLogradouro.Text.Trim();
                        enderecoExistente.Numero = TxtNumeroEndereco.Text.Trim();
                        enderecoExistente.Complemento = TxtComplemento.Text.Trim();
                        enderecoExistente.Freguesia = TxtFreguesia.Text.Trim();
                        enderecoExistente.CodigoPostal = TxtMskCodigoPostal.Text.Trim();
                        enderecoExistente.ConcelhoId = concelhoSelecionado.ConcelhoId;
                        enderecoExistente.Pais = TxtPais.Text.Trim();

                        enderecoId = enderecoExistente.EnderecoId;

                        await _enderecoService.UpdateEnderecoAsync(enderecoExistente);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um concelho válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            fornecedor.FornecedorId = fornecedor.FornecedorId;
            fornecedor.Nome = TxtNome.Text.Trim();
            fornecedor.Telemovel = TxtMskTelemovel.Text.Trim();
            fornecedor.Email = TxtEmail.Text.Trim();
            fornecedor.EnderecoId = enderecoId;

            await _fornecedorService.UpdateFornecedorAsync(fornecedor);

            MessageBox.Show("Informações alteradas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao alterar informações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao alterar informações: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao alterar informações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnAtualizarFornecedor.Enabled = true;
        }
    }

    private void ChkAtualizarEndereco_CheckedChanged_1(object sender, EventArgs e)
    {
        if (_isHandlingCheckboxChange) return;

        if (!ChkAtualizarEndereco.Checked)
        {
            var result = MessageBox.Show("Desmarcar esta opção excluirá o endereço do fornecedor. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                _isHandlingCheckboxChange = true;
                ChkAtualizarEndereco.Checked = true;
                _isHandlingCheckboxChange = false;
            }
        }
        PanelEnderecoFornecedor.Enabled = ChkAtualizarEndereco.Checked;
    }
}
