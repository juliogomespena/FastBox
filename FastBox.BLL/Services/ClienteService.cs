﻿using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
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
        return await _clienteRepository.Query()
            .AsNoTracking()
            .Include(c => c.Endereco)
            .Include(c => c.Endereco.Concelho)
            .Include(c => c.Endereco.Concelho.Distrito)
            .Include(c => c.Usuarios)
            .Include(c => c.OrdemDeServicos)
            .Include(c => c.Veiculos)
            .Select(c => new ClienteViewModel
        {
            ClienteId = c.ClienteId,
            Nome = c.Nome,
            Sobrenome = c.Sobrenome,
            Nif = c.Nif,
            Telemovel = c.Telemovel,
            Email = c.Email,
            DataCadastro = c.DataCadastro,
            Endereco = c.Endereco,
            OrdemDeServicos = c.OrdemDeServicos,
            Usuarios = c.Usuarios,
            Veiculos = c.Veiculos
            }).
        ToListAsync();
    }

    public async Task<IEnumerable<ClienteViewModel>> GetClientsInPagesAsync(int page, int size, ClienteFilter? filter = null)
    {
        var query = _clienteRepository.Query().AsNoTracking();
        if (filter != null)
        {
            if (!String.IsNullOrWhiteSpace(filter.NomeSobrenome))
                query = query.Where(cliente => (cliente.Nome + " " + cliente.Sobrenome).Contains(filter.NomeSobrenome));

            if (!String.IsNullOrWhiteSpace(filter.Nif))
                query = query.Where(cliente => cliente.Nif != null && cliente.Nif.Contains(filter.Nif));

            if (!String.IsNullOrWhiteSpace(filter.Telemovel))
                query = query.Where(cliente => cliente.Telemovel.Contains(filter.Telemovel));

            if (!String.IsNullOrWhiteSpace(filter.Email))
                query = query.Where(cliente => cliente.Email != null && cliente.Email.Contains(filter.Email));

            if (filter.DataCadastroInicio != null && filter.DataCadastroFim != null)
                query = query.Where(cliente => cliente.DataCadastro >= filter.DataCadastroInicio && cliente.DataCadastro <= filter.DataCadastroFim);

            if (!String.IsNullOrWhiteSpace(filter.MatriculaVeiculo))
                query = query.Where(cliente => cliente.Veiculos.Any(veiculo => veiculo.Matricula.Contains(filter.MatriculaVeiculo)));

            if (!String.IsNullOrWhiteSpace(filter.EnderecoCompleto))
                query = query.Where(cliente => cliente.Endereco != null && (cliente.Endereco.Pais + " " + cliente.Endereco.Concelho.Distrito.Nome + " " + cliente.Endereco.Concelho.Nome + " " + cliente.Endereco.Freguesia + " " + cliente.Endereco.Logradouro + " " + cliente.Endereco.Numero + " " + cliente.Endereco.Complemento + " " + cliente.Endereco.CodigoPostal).Contains(filter.EnderecoCompleto));
        }

        return await query
            .Include(c => c.Endereco)
            .Include(c => c.Endereco.Concelho)
            .Include(c => c.Endereco.Concelho.Distrito)
            .Include(c => c.Usuarios)
            .Include(c => c.OrdemDeServicos)
            .Include(c => c.Veiculos)
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
                Email = c.Email,
                DataCadastro = c.DataCadastro,
                Endereco = c.Endereco,
                OrdemDeServicos = c.OrdemDeServicos,
                Usuarios = c.Usuarios,
                Veiculos = c.Veiculos
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
            Email = clienteExistente.Email,
            DataCadastro = clienteExistente.DataCadastro,
            Endereco = clienteExistente.Endereco,
            OrdemDeServicos = clienteExistente.OrdemDeServicos,
            Usuarios = clienteExistente.Usuarios,
            Veiculos = clienteExistente.Veiculos,
            EnderecoId = clienteExistente.EnderecoId,
        };
    }

    public async Task<IEnumerable<ClienteViewModel>> GetClientsByNameAsync(string searchText)
    {
        return await _clienteRepository.Query()
            .AsNoTracking()
            .Include(c => c.Endereco)
            .Include(c => c.Endereco.Concelho)
            .Include(c => c.Endereco.Concelho.Distrito)
            .Include(c => c.Usuarios)
            .Include(c => c.OrdemDeServicos)
            .Include(c => c.Veiculos)
            .OrderByDescending(c => c.ClienteId)
            .Where(c =>(c.Nome + " " + c.Sobrenome).Contains(searchText))
            .Select(c => new ClienteViewModel
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                Nif = c.Nif,
                Telemovel = c.Telemovel,
                Email = c.Email,
                Endereco = c.Endereco,
                OrdemDeServicos = c.OrdemDeServicos,
                Usuarios = c.Usuarios,
                Veiculos = c.Veiculos
            }).
            ToListAsync();
    }

    public async Task AddClientAsync(ClienteViewModel cliente)
    {
        var clienteConverted = new Cliente
        {
            Nome = cliente.Nome,
            Sobrenome = cliente.Sobrenome,
            Telemovel = cliente.Telemovel,
            Email = cliente.Email == "Não cadastrado" ? null : cliente.Email,
            Nif = cliente.Nif == "Não cadastrado" ? null: cliente.Nif,
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
        clienteExistente.Email = cliente.Email == "Não cadastrado" ? null : cliente.Email;
        clienteExistente.Nif = cliente.Nif == "Não cadastrado" ? null : cliente.Nif;
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
