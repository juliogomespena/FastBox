using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetAllClients();
    Task<IEnumerable<Cliente>> GetClientsInPagesAsync(int page, int size);
    Task<Cliente> GetClientByIdAsync(long id);
    Task AddClientAsync(Cliente cliente);
    Task UpdateClientAsync(Cliente cliente);
    Task DeleteClientAsync(Cliente cliente);
}
