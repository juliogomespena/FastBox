using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Fornecedor
{
    public long FornecedorId { get; set; }

    public string Nome { get; set; } = null!;

    public string Telemovel { get; set; } = null!;

    public string? Email { get; set; }

    public long? EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<EstoquePeca> EstoquePecas { get; set; } = new List<EstoquePeca>();

    public ICollection<ItemOrcamento> ItensOrcamento { get; set; } = new List<ItemOrcamento>();
}
