using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Endereco
{
    public long EnderecoId { get; set; }

    public string Logradouro { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Complemento { get; set; }

    public string Freguesia { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public long ConcelhoId { get; set; }

    public string Pais { get; set; } = null!;

    public virtual Cliente? Cliente { get; set; }

    public virtual Concelho Concelho { get; set; } = null!;

    public virtual Fornecedor? Fornecedor { get; set; }
}
