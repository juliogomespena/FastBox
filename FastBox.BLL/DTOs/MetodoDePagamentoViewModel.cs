using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class MetodoDePagamentoViewModel
{
    public long MetodoPagamentoId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
