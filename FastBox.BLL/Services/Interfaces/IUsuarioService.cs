using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IUsuarioService
{
    Task<Usuario> ValidateLoginAsync(string loginOrEmail, string password);
    Task AddUserAsync(Usuario user);
}
