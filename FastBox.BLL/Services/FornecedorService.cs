using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FastBox.BLL.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IRepository<Fornecedor> _fornecedorRepository;

    public FornecedorService(IRepository<Fornecedor> fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public Task<IEnumerable<FornecedorViewModel>> GetAllFornecedores()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FornecedorViewModel>> GetFornecedoresInPagesAsync(int page, int size, FornecedorFilter? filter = null)
    {
        var query = _fornecedorRepository.Query().AsNoTracking();
        if (filter != null)
        {
            if (!String.IsNullOrWhiteSpace(filter.Nome))
                query = query.Where(fornecedor => fornecedor.Nome.Contains(filter.Nome));

            if (!String.IsNullOrWhiteSpace(filter.Telemovel))
                query = query.Where(fornecedor => fornecedor.Telemovel.Contains(filter.Telemovel));

            if (!String.IsNullOrWhiteSpace(filter.Email))
                query = query.Where(fornecedor => fornecedor.Email != null && fornecedor.Email.Contains(filter.Email));

            if (!String.IsNullOrWhiteSpace(filter.Peca))
                query = query.Where(fornecedor => fornecedor.ItensOrcamento.Select(peca => peca.Descricao).Contains(filter.Peca) || fornecedor.EstoquePecas.Select(peca => peca.Nome).Contains(filter.Peca));

            if (!String.IsNullOrWhiteSpace(filter.EnderecoCompleto))
                query = query.Where(fornecedor => fornecedor.Endereco != null && (fornecedor.Endereco.Pais + " " + fornecedor.Endereco.Concelho.Distrito.Nome + " " + fornecedor.Endereco.Concelho.Nome + " " + fornecedor.Endereco.Freguesia + " " + fornecedor.Endereco.Logradouro + " " + fornecedor.Endereco.Numero + " " + fornecedor.Endereco.Complemento + " " + fornecedor.Endereco.CodigoPostal).Contains(filter.EnderecoCompleto));
        }

        return await query
            .Include(f => f.Endereco)
            .Include(f => f.Endereco.Concelho)
            .Include(f => f.Endereco.Concelho.Distrito)
            .Include(f => f.EstoquePecas)
            .Include(f => f.ItensOrcamento)
            .OrderByDescending(f => f.FornecedorId)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(f => new FornecedorViewModel
            {
                Nome = f.Nome,
                Telemovel = f.Telemovel,
                Email = f.Email,
                EnderecoId = f.EnderecoId,
                Endereco = f.Endereco,
                EstoquePecas = f.EstoquePecas,
                ItensOrcamento = f.ItensOrcamento
            })
            .ToListAsync();
    }

    public Task<FornecedorViewModel> GetFornecedorByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FornecedorViewModel>> GetFornecedoresByNameAsync(string searchText)
    {
        throw new NotImplementedException();
    }

    public async Task AddFornecedorAsync(FornecedorViewModel fornecedor)
    {
        var fornecedorConverted = new Fornecedor
        {
            Nome = fornecedor.Nome,
            Telemovel = fornecedor.Telemovel,
            Email = fornecedor.Email == "Não cadastrado" ? null : fornecedor.Email,
            EnderecoId = fornecedor.EnderecoId
        };
        try
        {
            await _fornecedorRepository.AddAsync(fornecedorConverted);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um fornecedor com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _fornecedorRepository.DetachEntity(fornecedorConverted);
        }
    }

    public Task UpdateFornecedorAsync(FornecedorViewModel fornecedor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFornecedorAsync(FornecedorViewModel fornecedor)
    {
        throw new NotImplementedException();
    }
}
