using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormCadastrarCliente : Form
{
    private readonly IConcelhoService _concelhoService;
    private readonly IEnderecoService _enderecoService;
    private readonly IClienteService _clienteService;

    public FormCadastrarCliente(IConcelhoService concelhoService, IEnderecoService enderecoService, IClienteService clienteService)
    {
        InitializeComponent();
        _enderecoService = enderecoService;
        _concelhoService = concelhoService;
        _clienteService = clienteService;
    }

    private async void FormCadastrarCliente_Load(object sender, EventArgs e)
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
            MessageBox.Show("Digite um nome para o cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (String.IsNullOrWhiteSpace(TxtSobrenome.Text))
        {
            MessageBox.Show("Digite um sobrenome para o cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Digite o logradouro do endereço do cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(TxtNumeroEndereco.Text))
            {
                MessageBox.Show("Digite um número para o endereço do cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(TxtFreguesia.Text))
            {
                MessageBox.Show("Digite a freguesia do endereço do cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    private async void BtnCadastrarCliente_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            long? enderecoId = null;

            BtnCadastrarCliente.Enabled = false;

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


            var cliente = new ClienteViewModel
            {
                Nome = TxtNome.Text.Trim(),
                Sobrenome = TxtSobrenome.Text.Trim(),
                Telemovel = TxtMskTelemovel.Text.Trim(),
                Email = TxtEmail.Text.Trim(),
                Nif = TxtMskNif.Text.Trim(),
                EnderecoId = enderecoId
            };

            await _clienteService.AddClientAsync(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show($"Erro ao cadastrar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Erro ao cadastrar cliente: {ex.InnerException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {

            MessageBox.Show($"Erro ao cadastrar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnCadastrarCliente.Enabled = true;
        }
    }

    private void TxtMskNif_TextChanged(object sender, EventArgs e)
    {
        var regex = new Regex(@"^[1-9][0-9]{8}$");
        if (regex.IsMatch(TxtMskNif.Text))
            LblInfoNif.Text = "OK!";
        else if (String.IsNullOrWhiteSpace(TxtMskNif.Text))
            LblInfoNif.Text = "";
        else
            LblInfoNif.Text = "NIF inválido!";
    }

    private void ChkCadastrarEndereco_CheckedChanged_1(object sender, EventArgs e)
    {
        PanelEnderecoCliente.Enabled = ChkCadastrarEndereco.Checked;
    }
}
