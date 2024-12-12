using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FastBox.UI.Forms;

public partial class FormAtualizarCliente : Form
{
    private readonly IConcelhoService _concelhoService;
    private readonly IEnderecoService _enderecoService;
    private readonly IClienteService _clienteService;
    private bool _isHandlingCheckboxChange = false;

    public FormAtualizarCliente(IConcelhoService concelhoService, IEnderecoService enderecoService, IClienteService clienteService)
    {
        InitializeComponent();
        _enderecoService = enderecoService;
        _concelhoService = concelhoService;
        _clienteService = clienteService;
    }

    public long ClienteId { get; set; }

    private async void FormAtualizarCliente_Load(object sender, EventArgs e)
    {
        try
        {
            var concelhos = await _concelhoService.GetAllConcelhosAsync();

            CmbConcelho.DataSource = concelhos;
            CmbConcelho.DisplayMember = "Nome";
            CmbConcelho.ValueMember = "ConcelhoId";

            var cliente = await _clienteService.GetClientByIdWithIncludesAsync(ClienteId);

            if (cliente == null)
            {
                MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            TxtNome.Text = cliente.Nome;
            TxtSobrenome.Text = cliente.Sobrenome;
            TxtMskTelemovel.Text = cliente.Telemovel;
            TxtEmail.Text = cliente.Email;
            TxtMskNif.Text = cliente.Nif;

            PanelInfoCliente.Enabled = true;

            if (cliente.Endereco != null)
            {
                ChkCadastrarEndereco.Checked = true;
                PanelEnderecoCliente.Enabled = true;

                TxtLogradouro.Text = cliente.Endereco.Logradouro;
                TxtNumeroEndereco.Text = cliente.Endereco.Numero;
                TxtComplemento.Text = cliente.Endereco.Complemento;
                TxtFreguesia.Text = cliente.Endereco.Freguesia;
                TxtMskCodigoPostal.Text = cliente.Endereco.CodigoPostal;
                CmbConcelho.SelectedValue = cliente.Endereco.ConcelhoId;
                TxtPais.Text = cliente.Endereco.Pais;
            }
            else
            {
                ChkCadastrarEndereco.Checked = false;
                PanelEnderecoCliente.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar informações do cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        if (TxtMskNif.Text.Length != 9 || LblInfoNif.Text == "NIF inválido!")
        {
            MessageBox.Show("Digite um NIF válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    private async void BtnAtualizarCliente_Click(object sender, EventArgs e)
    {
        if (!CheckFields())
            return;

        try
        {
            BtnAtualizarCliente.Enabled = false;

            var cliente = await _clienteService.GetClientByIdAsync(ClienteId);
            Endereco enderecoExistente;
            long? enderecoId = null;

            if (ChkCadastrarEndereco.Checked)
            {
                if (CmbConcelho.SelectedItem is Concelho concelhoSelecionado)
                {
                    if (cliente.EnderecoId == null)
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
                        enderecoExistente = await _enderecoService.GetEnderecoByIdAsync((long)cliente.EnderecoId);
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
            

            cliente.Nome = TxtNome.Text.Trim();
            cliente.Sobrenome = TxtSobrenome.Text.Trim();
            cliente.Telemovel = TxtMskTelemovel.Text.Trim();
            cliente.Email = TxtEmail.Text.Trim();
            cliente.Nif = TxtMskNif.Text.Trim();
            cliente.EnderecoId = enderecoId;

            await _clienteService.UpdateClientAsync(cliente);

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
            BtnAtualizarCliente.Enabled = true;
        }
    }

    private void TxtMskNif_TextChanged(object sender, EventArgs e)
    {
        var regex = new Regex(@"^[1-9][0-9]{8}$");
        if (regex.IsMatch(TxtMskNif.Text))
            LblInfoNif.Text = "OK!";
        else
            LblInfoNif.Text = "NIF inválido!";
    }

    private void ChkCadastrarEndereco_CheckedChanged(object sender, EventArgs e)
    {
        if (_isHandlingCheckboxChange) return;

        if (!ChkCadastrarEndereco.Checked)
        {
            var result = MessageBox.Show("Desmarcar esta opção excluirá o endereço do cliente. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                _isHandlingCheckboxChange = true;
                ChkCadastrarEndereco.Checked = true;
                _isHandlingCheckboxChange = false;
            }
        }
        PanelEnderecoCliente.Enabled = ChkCadastrarEndereco.Checked;
    }
}
