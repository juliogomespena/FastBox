using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class StatusOrdemDeServico
{
    public long StatusOrdemDeServicoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();
}
