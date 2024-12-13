using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FastBox.BLL.Services;

public class ClienteService : IClienteService
{
    private readonly IRepository<Cliente> _clienteRepository;

    public ClienteService(IRepository<Cliente> clientRepository)
    {
        _clienteRepository = clientRepository;
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllClients()
    {
        var clientes = await _clienteRepository.Query().ToListAsync();
        return clientes.Select(c => new ClienteViewModel
        {
            ClienteId = c.ClienteId,
            Nome = c.Nome,
            Sobrenome = c.Sobrenome,
            Nif = c.Nif,
            Telemovel = c.Telemovel,
            Email = String.IsNullOrWhiteSpace(c.Email) ? "E-mail não cadastrado" : c.Email,
            DataCadastro = c.DataCadastro,
            VeiculosCount = c.Veiculos.Count(),
            OrdensDeServicoCount = c.OrdemDeServicos.Count(),
            EnderecoResumido = c.Endereco == null ? "Endereço não cadastrado" : $"{c.Endereco.Logradouro}, {c.Endereco.Numero}",
            EnderecoCompleto = c.Endereco == null ? "Endereço não cadastrado" : $"{c.Endereco.Logradouro}, {c.Endereco.Numero}, {(!string.IsNullOrWhiteSpace(c.Endereco.Complemento) ? c.Endereco.Complemento : "Sem complemento")}, {c.Endereco.Freguesia}, Concelho: {c.Endereco.Concelho.Nome}, Distrito: {c.Endereco.Concelho.Distrito.Nome}, {c.Endereco.CodigoPostal}, {c.Endereco.Pais}",
            Endereco = c.Endereco,
            OrdemDeServicos = c.OrdemDeServicos,
            Usuarios = c.Usuarios,
            Veiculos = c.Veiculos,
        }).ToList();
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
                DataCadastro = c.DataCadastro,
                VeiculosCount = c.Veiculos.Count(),
                OrdensDeServicoCount = c.OrdemDeServicos.Count(),
                EnderecoResumido = c.Endereco == null ? "Endereço não cadastrado" : $"{c.Endereco.Logradouro}, {c.Endereco.Numero}",
                EnderecoCompleto = c.Endereco == null ? "Endereço não cadastrado" : $"{c.Endereco.Logradouro}, {c.Endereco.Numero}, {(!string.IsNullOrWhiteSpace(c.Endereco.Complemento) ? c.Endereco.Complemento : "Sem complemento")}, {c.Endereco.Freguesia}, Concelho: {c.Endereco.Concelho.Nome}, Distrito: {c.Endereco.Concelho.Distrito.Nome}, {c.Endereco.CodigoPostal}, {c.Endereco.Pais}",
            })
            .ToListAsync();
    }

    public async Task<ClienteViewModel> GetClientByIdAsync(long id)
    {
        var clienteExistente = await _clienteRepository.Query()
    .Include(c => c.Endereco)
    .Include(c => c.Endereco.Concelho)
    .Include(c => c.Endereco.Concelho.Distrito)
    .Include(c => c.Usuarios) 
    .Include(c => c.OrdemDeServicos)
    .Include(c => c.Veiculos)
    .FirstOrDefaultAsync(c => c.ClienteId == id);

        if (clienteExistente == null)
            throw new Exception("Cliente não encontrado.");

        return new ClienteViewModel 
        {
            ClienteId = clienteExistente.ClienteId,
            Nome = clienteExistente.Nome,
            Sobrenome = clienteExistente.Sobrenome,
            Nif = clienteExistente.Nif,
            Telemovel = clienteExistente.Telemovel,
            Email = String.IsNullOrWhiteSpace(clienteExistente.Email) ? "E-mail não cadastrado" : clienteExistente.Email,
            DataCadastro = clienteExistente.DataCadastro,
            VeiculosCount = clienteExistente.Veiculos.Count(),
            OrdensDeServicoCount = clienteExistente.OrdemDeServicos.Count(),
            EnderecoId = clienteExistente.EnderecoId,
            EnderecoResumido = clienteExistente.Endereco == null ? "Endereço não cadastrado" : $"{clienteExistente.Endereco.Logradouro}, {clienteExistente.Endereco.Numero}",
            EnderecoCompleto = clienteExistente.Endereco == null ? "Endereço não cadastrado" : $"{clienteExistente.Endereco.Logradouro}, {clienteExistente.Endereco.Numero}, {(!string.IsNullOrWhiteSpace(clienteExistente.Endereco.Complemento) ? clienteExistente.Endereco.Complemento : "Sem complemento")}, {clienteExistente.Endereco.Freguesia}, Concelho: {clienteExistente.Endereco.Concelho.Nome}, Distrito: {clienteExistente.Endereco.Concelho.Distrito.Nome}, {clienteExistente.Endereco.CodigoPostal}, {clienteExistente.Endereco.Pais}",
            Endereco = clienteExistente.Endereco,
            OrdemDeServicos = clienteExistente.OrdemDeServicos,
            Usuarios = clienteExistente.Usuarios,
            Veiculos = clienteExistente.Veiculos,
        };
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
                Email = String.IsNullOrWhiteSpace(c.Email) ? "E-mail não cadastrado" : c.Email,
            }).ToListAsync();
    }

    public async Task AddClientAsync(ClienteViewModel cliente)
    {
        var clienteConverted = new Cliente
        {
            Nome = cliente.Nome,
            Sobrenome = cliente.Sobrenome,
            Telemovel = cliente.Telemovel,
            Email = cliente.Email,
            Nif = cliente.Nif,
            EnderecoId = cliente.EnderecoId
        };
        try
        {
            await _clienteRepository.AddAsync(clienteConverted);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um cliente com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _clienteRepository.DetachEntity(clienteConverted);
        }
    }

    public async Task UpdateClientAsync(ClienteViewModel cliente)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(cliente.ClienteId);
        if (clienteExistente == null)
            throw new InvalidOperationException("Cliente não encontrado.");

        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Sobrenome = cliente.Sobrenome;
        clienteExistente.Telemovel = cliente.Telemovel;
        clienteExistente.Email = cliente.Email;
        clienteExistente.Nif = cliente.Nif;
        clienteExistente.EnderecoId = cliente.EnderecoId;

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

    public async Task DeleteClientAsync(ClienteViewModel cliente)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(cliente.ClienteId);
        if (clienteExistente == null)
            throw new Exception("Cliente não encontrado.");

        await _clienteRepository.DeleteAsync(clienteExistente);
        _clienteRepository.DetachEntity(clienteExistente);
    }
}
