using FastBox.DAL.Models;
using System.Reflection.Metadata.Ecma335;

namespace FastBox.BLL.DTOs;

public class VeiculoViewModel
{
    private string? _observacoes;
    public long VeiculoId { get; set; }

    public long? ClienteId { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    public string Matricula { get; set; } = null!;

    public string? NomeCliente => Cliente == null ? "Não cadastrado" : Cliente.ToString();

    public int OrdensDeServico => OrdemDeServicos.Count();

    public string? Observacoes 
    {
        get => string.IsNullOrEmpty(_observacoes) ? "Sem observações" : _observacoes;
        set => _observacoes = value;
    }

    public string? ModeloMatricula => $"{Modelo} ({Matricula})";

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();
}
