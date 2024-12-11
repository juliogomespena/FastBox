using FastBox.BLL.Helper;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IRepository<Usuario> _userRepository;
    public UsuarioService(IRepository<Usuario> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task AddUserAsync(Usuario user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Login))
            throw new ArgumentException("Login e E-mail são obrigatórios!");

        user.Senha = Password.HashPassword(user.Senha);

        try
        {
            await _userRepository.AddAsync(user);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um usuário com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _userRepository.DetachEntity(user);
        }

    }

    public async Task<Usuario> ValidateLoginAsync(string loginOrEmail, string password)
    {
        int maxRetries = 3;

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                var user = await _userRepository.FirstOrDefaultAsync(u => u.Email == loginOrEmail || u.Login == loginOrEmail);

                if (user == null || !Password.VerifyPassword(password, user.Senha))
                    throw new UnauthorizedAccessException("Usuário ou senha incorretos!");

                return user;
            }
            catch (TimeoutException)
            {
                if (attempt == maxRetries)
                    throw;

                await Task.Delay(2000);
            }
        }
        throw new Exception("Erro inesperado durante a autenticação. Tente novamente mais tarde.");
    }
}
