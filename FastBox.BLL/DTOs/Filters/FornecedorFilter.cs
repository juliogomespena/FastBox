using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.DTOs.Filters;

public class FornecedorFilter
{
    public string Nome { get; set; }

    public string Telemovel { get; set; }

    public string Email { get; set; }

    public string Peca { get; set; }

    public string EnderecoCompleto { get; set; }
}
