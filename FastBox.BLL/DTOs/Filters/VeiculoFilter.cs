using FastBox.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.DTOs.Filters;

public class VeiculoFilter
{
    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Ano { get; set; }

    public string? Matricula { get; set; }

    public string? NomeCliente { get; set; }

    public string? Observacoes { get; set; }
}
