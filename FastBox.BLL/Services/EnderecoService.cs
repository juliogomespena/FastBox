using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IRepository<Endereco> _enderecoRepository;
    public EnderecoService(IRepository<Endereco> enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }
    public async Task<Endereco> GetEnderecoByIdAsync(long id)
    {
        var enderecoExistente = await _enderecoRepository.GetByIdAsync(id);

        if (enderecoExistente == null)
            throw new Exception("Endereço não encontrado.");

        return enderecoExistente;
    }
    public async Task<long> AddEnderecoAsync(Endereco endereco)
    {
        try
        {
            await _enderecoRepository.AddAsync(endereco);
            return endereco.EnderecoId;
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um endereço com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _enderecoRepository.DetachEntity(endereco);
        }
    }
    public async Task<long> UpdateEnderecoAsync(Endereco endereco)
    {
        try
        {
            await _enderecoRepository.UpdateAsync(endereco);
            return endereco.EnderecoId;
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um endereço com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _enderecoRepository.DetachEntity(endereco);
        }
    }
}
