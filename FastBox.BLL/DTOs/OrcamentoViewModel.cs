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

        public decimal CustoPecas => Math.Round(ItensOrcamento.Where(i => i.Descricao != "Mão de obra").Sum(i => i.CustoTotal), 2, MidpointRounding.AwayFromZero);
        
        public decimal VendaPecas => Math.Round(ItensOrcamento.Where(i => i.Descricao != "Mão de obra").Sum(i => i.ValorTotal), 2, MidpointRounding.AwayFromZero); 

        public decimal LucroPecas => Math.Round(ItensOrcamento.Where(i => i.Descricao != "Mão de obra").Sum(i => i.Lucro), 2, MidpointRounding.AwayFromZero);

        public decimal MaoDeObra => Math.Round(ItensOrcamento.Where(i => i.Descricao == "Mão de obra").Sum(i => i.Lucro), 2, MidpointRounding.AwayFromZero);

        public decimal VendaTotal => Math.Round(VendaPecas + MaoDeObra, 2, MidpointRounding.AwayFromZero);

        public decimal IVA => Math.Round(VendaTotal * (decimal)0.23, 2, MidpointRounding.AwayFromZero);

        public decimal LucroTotal => Math.Round(VendaTotal - CustoPecas, 2, MidpointRounding.AwayFromZero);

        public virtual OrdemDeServico OrdemDeServico { get; set; } = null!;

        public virtual ICollection<ItemOrcamentoViewModel> ItensOrcamento { get; set; } = new List<ItemOrcamentoViewModel>();
    }
}
