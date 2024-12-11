using FastBox.BLL.DTOs;
using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetAllClients();
    Task<IEnumerable<ClienteViewModel>> GetClientsInPagesAsync(int page, int size);
    Task<Cliente> GetClientByIdAsync(long id);
    Task AddClientAsync(Cliente cliente);
    Task UpdateClientAsync(Cliente cliente);
    Task DeleteClientAsync(Cliente cliente);
    Task<Cliente> GetClientByIdWithIncludesAsync(long id);
}
