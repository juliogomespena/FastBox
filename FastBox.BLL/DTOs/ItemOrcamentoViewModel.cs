using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs
{
    public class ItemOrcamentoViewModel
    {
        private decimal _precoUnitario;
        private decimal _margem;

        public long ItemOrcamentoId { get; set; }

        public long OrcamentoId { get; set; }

        public string Descricao { get; set; } = null!;

        public int Quantidade { get; set; }

        public decimal PrecoUnitario
        {
            get => _precoUnitario;
            set => _precoUnitario = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public decimal PrecoFinalUnitario => Math.Round(PrecoUnitario + (PrecoUnitario * Margem),2,MidpointRounding.AwayFromZero);

        public decimal PrecoFinalTotal => Math.Round(PrecoFinalUnitario * Quantidade, 2, MidpointRounding.AwayFromZero);

        public decimal Margem 
        {  
            get => _margem; 
            set => _margem = value / 100; 
        }

        public virtual Orcamento Orcamento { get; set; } = null!;
    }
}
