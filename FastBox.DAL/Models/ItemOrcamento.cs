using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class ItemOrcamento
{
    public long ItemOrcamentoId { get; set; }

    public long OrcamentoId { get; set; }

    public string Descricao { get; set; } = null!;

    public int? NumeroFatura {  get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal Margem { get; set; }

    public long FornecedorId { get; set; }

    public Fornecedor Fornecedor { get; set; } = null!;

    public virtual Orcamento Orcamento { get; set; } = null!;
}
