using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class StatusOrdemDeServicoViewModel
{
    public long StatusOrdemDeServicoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;
}
