using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class ClienteService : IClienteService
{
    private readonly IRepository<Cliente> _clienteRepository;

    public ClienteService(IRepository<Cliente> clientRepository)
    {
        _clienteRepository = clientRepository;
    }

    public async Task<IEnumerable<Cliente>> GetAllClients()
    {
        return await _clienteRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Cliente>> GetClientsInPagesAsync(int page, int size)
    {
        return await _clienteRepository.Query()
        .Skip((page - 1) * size)
        .Take(size)
        .ToListAsync();
    }
    public async Task<Cliente> GetClientByIdAsync(long id)
    {
        var client = await _clienteRepository.GetByIdAsync(id);
        if (client == null)
            throw new Exception("Cliente não encontrado.");
        return client;
    }

    public async Task AddClientAsync(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
            throw new ArgumentException("O nome do cliente é obrigatório.");
        if (cliente.Nif.Length != 9)
            throw new ArgumentException("O NIF deve conter 9 dígitos.");

        await _clienteRepository.AddAsync(cliente);
    }

    public async Task UpdateClientAsync(Cliente cliente)
    {
        if (cliente.ClienteId <= 0)
            throw new ArgumentException("Cliente inválido para atualização.");

        var clientExistente = await _clienteRepository.GetByIdAsync(cliente.ClienteId);
        if (clientExistente == null)
            throw new Exception("Cliente não encontrado.");

        clientExistente.Nome = cliente.Nome;
        clientExistente.Sobrenome = cliente.Sobrenome;
        clientExistente.Telemovel = cliente.Telemovel;
        clientExistente.Email = cliente.Email;
        clientExistente.Nif = cliente.Nif;

        await _clienteRepository.UpdateAsync(clientExistente);
    }

    public async Task DeleteClientAsync(Cliente cliente)
    {
        var client = await _clienteRepository.GetByIdAsync(cliente.ClienteId);
        if (client == null)
            throw new Exception("Cliente não encontrado.");

        await _clienteRepository.DeleteAsync(cliente);
    }
}
