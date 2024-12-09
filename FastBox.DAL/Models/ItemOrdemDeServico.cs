using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class ItemOrdemDeServico
{
    public long ItemOrdemDeServicoId { get; set; }

    public long OrdemDeServicoId { get; set; }

    public string Descricao { get; set; } = null!;

    public long Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public byte Margem { get; set; }

    public virtual OrdemDeServico OrdemDeServico { get; set; } = null!;
}
