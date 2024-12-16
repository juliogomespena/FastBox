using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.DTOs.Filters;

public class ClienteFilter
{
    public string? NomeSobrenome { get; set; }

    public string? Nif { get; set; }

    public string? Telemovel { get; set; }

    public string? Email { get; set; }

    public DateTime? DataCadastroInicio { get; set; }
    public DateTime? DataCadastroFim { get; set; }

    public string? MatriculaVeiculo { get; set; }

    public string? EnderecoCompleto { get; set; }
}
