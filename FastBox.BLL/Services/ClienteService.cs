using FastBox.BLL.DTOs;
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
        return await _clienteRepository.GetAllAsync(asNoTracking: true);
    }

    public async Task<IEnumerable<ClienteViewModel>> GetClientsInPagesAsync(int page, int size)
    {
        return await _clienteRepository.Query()
            .AsNoTracking()
            .Include(c => c.Endereco)
            .OrderByDescending(c => c.ClienteId)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(c => new ClienteViewModel
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                Nif = c.Nif,
                Telemovel = c.Telemovel,
                Email = String.IsNullOrWhiteSpace(c.Email) ? "E-mail não cadastrado" : c.Email,
                Veiculos = c.Veiculos.Count(),
                OrdensDeServico = c.OrdemDeServicos.Count(),
                DataCadastro = c.DataCadastro,
                EnderecoResumido = c.Endereco == null ? "Endereço não cadastrado" : $"{c.Endereco.Logradouro}, {c.Endereco.Numero}",
                EnderecoCompleto = c.Endereco == null ? "Endereço não cadastrado" : $"{c.Endereco.Logradouro}, {c.Endereco.Numero}, {(!string.IsNullOrWhiteSpace(c.Endereco.Complemento) ? c.Endereco.Complemento : "Sem complemento")}, {c.Endereco.Freguesia}, Concelho: {c.Endereco.Concelho.Nome}, Distrito: {c.Endereco.Concelho.Distrito.Nome}, {c.Endereco.CodigoPostal}, {c.Endereco.Pais}"
            })
            .ToListAsync();
    }

    public async Task<Cliente> GetClientByIdAsync(long id)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(id);

        if (clienteExistente == null)
            throw new Exception("Cliente não encontrado.");

        return clienteExistente;
    }

    public async Task<Cliente> GetClientByIdWithIncludesAsync(long id)
    {
        var clienteExistente = await _clienteRepository.GetByIdWithIncludesAsync(
            c => c.ClienteId == id,
            c => c.Endereco,
            c => c.Veiculos,
            c => c.OrdemDeServicos
        );

        if (clienteExistente == null)
            throw new Exception("Cliente não encontrado.");

        return clienteExistente;
    }

    public async Task<IEnumerable<ClienteViewModel>> GetClientsByNameAsync(string searchText)
    {
        return await _clienteRepository.Query()
            .AsNoTracking()
            .OrderByDescending(c => c.ClienteId)
            .Where(c =>(c.Nome + " " + c.Sobrenome).Contains(searchText))
            .Select(c => new ClienteViewModel
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                Nif = c.Nif,
                Telemovel = c.Telemovel,
                Email = c.Email == null ? "E-mail não cadastrado" : c.Email
            }).ToListAsync();
    }

    public async Task AddClientAsync(Cliente cliente)
    {
        try
        {
            await _clienteRepository.AddAsync(cliente);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um cliente com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _clienteRepository.DetachEntity(cliente);
        }
    }

    public async Task UpdateClientAsync(Cliente cliente)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(cliente.ClienteId);
        if (clienteExistente == null)
            throw new InvalidOperationException("Cliente não encontrado.");

        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Sobrenome = cliente.Sobrenome;
        clienteExistente.Telemovel = cliente.Telemovel;
        clienteExistente.Email = cliente.Email;
        clienteExistente.Nif = cliente.Nif;

        if (cliente.Endereco != null)
        {
            clienteExistente.Endereco.Logradouro = cliente.Endereco.Logradouro;
            clienteExistente.Endereco.Numero = cliente.Endereco.Numero;
            clienteExistente.Endereco.Complemento = cliente.Endereco.Complemento;
            clienteExistente.Endereco.Freguesia = cliente.Endereco.Freguesia;
            clienteExistente.Endereco.CodigoPostal = cliente.Endereco.CodigoPostal;
            clienteExistente.Endereco.ConcelhoId = cliente.Endereco.ConcelhoId;
            clienteExistente.Endereco.Pais = cliente.Endereco.Pais;
        }
        try
        {
            await _clienteRepository.UpdateAsync(clienteExistente);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um cliente com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _clienteRepository.DetachEntity(clienteExistente);
        }
    }

    public async Task DeleteClientAsync(Cliente cliente)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(cliente.ClienteId);
        if (clienteExistente == null)
            throw new Exception("Cliente não encontrado.");

        await _clienteRepository.DeleteAsync(clienteExistente);
        _clienteRepository.DetachEntity(clienteExistente);
    }
}
