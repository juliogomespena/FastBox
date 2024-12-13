using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class VeiculoViewModel
{
    public long VeiculoId { get; set; }

    public long? ClienteId { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    public string Matricula { get; set; } = null!;

    public string? NomeCliente { get; set; }

    public int OrdensDeServico { get; set; }

    public string? Observacoes { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();
}
