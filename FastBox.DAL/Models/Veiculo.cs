using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Veiculo
{
    public long VeiculoId { get; set; }

    public long? ClienteId { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    public string Matricula { get; set; } = null!;

    public string? Observacoes { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();
}
