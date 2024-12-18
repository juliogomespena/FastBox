using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class OrdemDeServico
{
    public long OrdemDeServicoId { get; set; }

    public long? ClienteId { get; set; }

    public long? VeiculoId { get; set; }

    public long StatusOrdemDeServicoId { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DataAbertura { get; set; }
    public DateTime? EstimativaConclusao { get; set; }

    public DateTime? DataConclusao { get; set; }

    public decimal? ValorTotal { get; set; }

    public bool IncluirIva { get; set; }

    public int? GarantiaEmDias { get; set; }

    public string? ObservacoesGarantia { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual StatusOrdemDeServico StatusOrdemDeServico { get; set; } = null!;

    public virtual Veiculo? Veiculo { get; set; }
}
