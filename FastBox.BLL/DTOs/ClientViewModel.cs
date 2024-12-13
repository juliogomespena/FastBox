using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class ClienteViewModel
{
    public long ClienteId { get; set; }
    public string Nome { get; set; } = null!;
    public string Sobrenome { get; set; } = null!;
    public string Nif { get; set; } = null!;
    public string Telemovel { get; set; } = null!;
    public string? Email { get; set; }
    public long? EnderecoId { get; set; }
    public DateTime DataCadastro { get; set; }
    public int? VeiculosCount { get; set; }
    public int? OrdensDeServicoCount { get; set; }
    public string? EnderecoResumido { get; set; }
    public string? EnderecoCompleto { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;
    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
