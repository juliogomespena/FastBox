namespace FastBox.DAL.Models;

public class NivelDeAcesso
{
    public int NivelDeAcessoId { get; set; }
    public string Descricao { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
