using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Distrito
{
    public long DistritoId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Concelho> Concelhos { get; set; } = new List<Concelho>();
}
