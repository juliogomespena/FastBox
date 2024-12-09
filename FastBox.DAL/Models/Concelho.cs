using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Concelho
{
    public long ConcelhoId { get; set; }

    public string Nome { get; set; } = null!;

    public long DistritoId { get; set; }

    public virtual Distrito Distrito { get; set; } = null!;

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
