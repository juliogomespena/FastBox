using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs
{
    public class OrcamentoViewModel
    {
        private string? _descricao;

        public long OrcamentoId { get; set; }

        public int Numero { get; set; }

        public long OrdemDeServicoId { get; set; }

        public byte StatusOrcamento { get; set; }

        public string Status => StatusOrcamento switch
        {
            1 => "Pendente",
            2 => "Aprovado",
            3 => "Reprovado",
            _ => "Status desconhecido"
        };

        public DateTime DataCriacao { get; set; }

        public string? Descricao 
        {
            get => String.IsNullOrWhiteSpace(_descricao) ? "Sem descrição" : _descricao;
            set => _descricao = value;
        }

        public int NumeroDeItens => ItensOrcamento.Count();

        public decimal CustoTotal => Math.Round(ItensOrcamento.Sum(i => i.CustoTotal), 2, MidpointRounding.AwayFromZero);
        
        public decimal ValorTotal => Math.Round(ItensOrcamento.Sum(i => i.ValorTotal), 2, MidpointRounding.AwayFromZero); 

        public decimal LucroTotal => Math.Round(ItensOrcamento.Sum(i => i.Lucro), 2, MidpointRounding.AwayFromZero);

        public virtual OrdemDeServico OrdemDeServico { get; set; } = null!;

        public virtual ICollection<ItemOrcamentoViewModel> ItensOrcamento { get; set; } = new List<ItemOrcamentoViewModel>();
    }
}
