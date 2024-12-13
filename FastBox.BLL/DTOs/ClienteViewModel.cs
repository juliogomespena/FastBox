using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class ClienteViewModel
{
    private string? _nif;
    private string? _email;

    public long ClienteId { get; set; }

    public string NomeSobrenome => $"{Nome} {Sobrenome}";

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string? Nif 
    { 
        get
        {
            return String.IsNullOrWhiteSpace(_nif) ? "Não cadastrado" : _nif;
        }
        set
        {
            _nif = value;
        }
    }

    public string Telemovel { get; set; } = null!;

    public string? Email 
    { 
        get
        {
            return String.IsNullOrWhiteSpace(_email) ? "Não cadastrado" : _email;
        }
        set
        {  
            _email = value; 
        }
    }

    public long? EnderecoId { get; set; }

    public DateTime DataCadastro { get; set; }

    public int? VeiculosCount => Veiculos.Count();

    public int? OrdensDeServicoCount => OrdemDeServicos.Count();

    public string? EnderecoResumido => Endereco == null ? "Não cadastrado" : $"{Endereco.Logradouro}, {Endereco.Numero}";

    public string? EnderecoCompleto => Endereco == null ? "Não cadastrado" : $"{Endereco.Logradouro}, {Endereco.Numero}, {(!string.IsNullOrWhiteSpace(Endereco.Complemento) ? Endereco.Complemento : "Sem complemento")}, {Endereco.Freguesia}, Concelho: {Endereco.Concelho.Nome}, Distrito: {Endereco.Concelho.Distrito.Nome}, {Endereco.CodigoPostal}, {Endereco.Pais}";

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
