using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class ClienteViewModel
{
    public long ClienteId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Nif { get; set; }
    public string Telemovel { get; set; }
    public string Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public int Veiculos { get; set; }
    public int OrdensDeServico { get; set; }
    public string EnderecoResumido { get; set; }
    public string EnderecoCompleto { get; set; }

}
