using FastBox.DAL.Models;

namespace FastBox.UI.Helper;

internal class Session
{
    public static long UserId { get; private set; }
    public static string Username { get; private set; }
    public static int NivelDeAcessoId { get; private set; }
    public static long? ClienteId { get; private set; }

    public static void Initiate(Usuario user)
    {
        UserId = user.UsuarioId;
        Username = user.Login;
        NivelDeAcessoId = user.NivelDeAcessoId;
        ClienteId = user.ClienteId;
    }

    public static void Terminate()
    {
        UserId = 0;
        Username = null;
        NivelDeAcessoId = 0;
    }

    public static bool ActiveSession()
    {
        return UserId > 0;
    }
}
