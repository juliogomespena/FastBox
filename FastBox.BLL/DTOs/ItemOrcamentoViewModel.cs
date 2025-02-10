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

        public float Quantidade { get; set; }

        public decimal PrecoUnitario
        {
            get => _precoUnitario;
            set => _precoUnitario = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public decimal CustoTotal => Math.Round(PrecoUnitario * (decimal)Quantidade, 2, MidpointRounding.AwayFromZero);

        public decimal ValorUnitario => Math.Round(PrecoUnitario * (1 + Margem), 4, MidpointRounding.AwayFromZero);

        public decimal ValorTotal => Math.Round(ValorUnitario * (decimal)Quantidade, 2, MidpointRounding.AwayFromZero);

        public decimal Lucro 
        {
            get
            {
                if(Descricao == "Mão de obra")
                    return Math.Round(ValorTotal, 2, MidpointRounding.AwayFromZero);
                else
                    return Math.Round(ValorTotal - CustoTotal, 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal Margem 
        {  
            get => _margem; 
            set => _margem = value / 100; 
        }

        public long FornecedorId {  get; set; }

        public string NomeFornecedor => Fornecedor.Nome;

        public int? NumeroFatura { get; set; }

        public FornecedorViewModel Fornecedor { get; set; } = null!;

        public virtual Orcamento Orcamento { get; set; } = null!;
    }
}
