using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Pagamento
{
    public long PagamentoId { get; set; }

    public long OrdemDeServicoId { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataPagamento { get; set; }

    public long MetodoPagamentoId { get; set; }

    public virtual MetodoPagamento MetodoPagamento { get; set; } = null!;

    public virtual OrdemDeServico OrdemDeServico { get; set; } = null!;
}
