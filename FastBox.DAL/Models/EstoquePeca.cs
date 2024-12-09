using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class EstoquePeca
{
    public long EstoquePecaId { get; set; }

    public string Nome { get; set; } = null!;

    public long Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public short? Margem { get; set; }

    public long FornecedorId { get; set; }

    public virtual Fornecedor Fornecedor { get; set; } = null!;
}
