using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.DTOs.Filters;

public class OrdemDeServicoFilter
{
    public string? Status { get; set; }

    public string? Cliente { get; set; }

    public string? Veiculo { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataAbertura { get; set; }

    public DateTime? PrazoEstimado { get; set; }

    public decimal? ValorTotal { get; set; }
    
    public bool? ValorTotalMaiorOuIgual { get; set; }
}
