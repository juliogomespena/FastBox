using FastBox.DAL.Models;

namespace FastBox.BLL.DTOs;

public class VeiculoViewModel
{
    public long VeiculoId { get; set; }
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public int Ano { get; set; }
    public string Matricula { get; set; } = null!;
    public string? Cliente { get; set; }
    public int OrdensDeServico { get; set; }
    public string? ObservacoesResumido { get; set; }
    public string? ObservacoesCompleto { get; set; }
}
