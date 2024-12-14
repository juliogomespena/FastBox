using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs
{
    public class OrcamentoViewModel
    {
        public long OrcamentoId { get; set; }

        public long OrdemDeServicoId { get; set; }

        public byte StatusOrcamento { get; set; }

        public DateTime DataCriacao { get; set; }

        public string? Descricao { get; set; } = null!;

        public virtual OrdemDeServico OrdemDeServico { get; set; } = null!;

        public virtual ICollection<ItemOrcamento> ItensOrcamento { get; set; } = new List<ItemOrcamento>();
    }
}
