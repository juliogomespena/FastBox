using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class MetodoPagamento
{
    public long MetodoPagamentoId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
