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

    public async Task<IEnumerable<FornecedorViewModel>> GetAllFornecedores()
    {
        return await _fornecedorRepository.Query()
            .AsNoTracking()
            .Include(f => f.Endereco)
            .Include(f => f.Endereco.Concelho)
            .Include(f => f.Endereco.Concelho.Distrito)
            .Include(f => f.EstoquePecas)
            .Include(f => f.ItensOrcamento)
            .Select(f => new FornecedorViewModel
            {
                FornecedorId = f.FornecedorId,
                Nome = f.Nome,
                Telemovel = f.Telemovel,
                Email = f.Email,
                EnderecoId = f.EnderecoId,
                Endereco = f.Endereco,
                EstoquePecas = f.EstoquePecas,
                ItensOrcamento = f.ItensOrcamento
            }).
        ToListAsync();
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
                FornecedorId = f.FornecedorId,
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

    public async Task<FornecedorViewModel> GetFornecedorByIdAsync(long id)
    {
        var fornecedorExistente = await _fornecedorRepository.Query()
            .Include(f => f.EstoquePecas)
            .Include(f => f.ItensOrcamento)
            .Include(f => f.Endereco)
            .FirstOrDefaultAsync(f => f.FornecedorId == id);

        if (fornecedorExistente == null)
            throw new Exception("Fornecedor não encontrado.");

        return new FornecedorViewModel
        {
            FornecedorId = fornecedorExistente.FornecedorId,
            Nome = fornecedorExistente.Nome,
            Telemovel = fornecedorExistente.Telemovel,
            Email = fornecedorExistente.Email,
            EnderecoId = fornecedorExistente.EnderecoId,
            Endereco = fornecedorExistente.Endereco,
            ItensOrcamento = fornecedorExistente.ItensOrcamento,
            EstoquePecas = fornecedorExistente.EstoquePecas
        };
    }

    public async Task<IEnumerable<FornecedorViewModel>> GetFornecedoresByNameAsync(string searchText)
    {
        return await _fornecedorRepository.Query()
            .AsNoTracking()
            .Include(f => f.Endereco)
            .Include(f => f.Endereco.Concelho)
            .Include(f => f.Endereco.Concelho.Distrito)
            .Include(f => f.EstoquePecas)
            .Include(f => f.ItensOrcamento)
            .OrderByDescending(f => f.FornecedorId)
            .Where(f => f.Nome.Contains(searchText))
            .Select(f => new FornecedorViewModel
            {
                FornecedorId = f.FornecedorId,
                Nome = f.Nome,
                Telemovel = f.Telemovel,
                Email = f.Email,
                EnderecoId = f.EnderecoId,
                Endereco = f.Endereco,
                EstoquePecas = f.EstoquePecas,
                ItensOrcamento = f.ItensOrcamento
            }).
            ToListAsync();
    }

    public async Task<FornecedorViewModel> GetFornecedorByNameAsync(string searchText)
    {
        var fornecedorExistente = await _fornecedorRepository.Query()
            .AsNoTracking()
            .Include(f => f.Endereco)
                .ThenInclude(c => c.Concelho)
                    .ThenInclude(d => d.Distrito)
            .Include(f => f.EstoquePecas)
            .Include(f => f.ItensOrcamento)
            .Where(f => f.Nome == searchText)
            .Select(f => new FornecedorViewModel
            {
                FornecedorId = f.FornecedorId,
                Nome = f.Nome,
                Telemovel = f.Telemovel,
                Email = f.Email,
                EnderecoId = f.EnderecoId,
                Endereco = f.Endereco,
                EstoquePecas = f.EstoquePecas,
                ItensOrcamento = f.ItensOrcamento
            })
            .FirstOrDefaultAsync();

        if (fornecedorExistente == null)
            throw new Exception("Fornecedor não encontrado.");

        return fornecedorExistente;
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

    public async Task UpdateFornecedorAsync(FornecedorViewModel fornecedor)
    {
        var fornecedorExistente = await _fornecedorRepository.GetByIdAsync(fornecedor.FornecedorId);
        if (fornecedorExistente == null)
            throw new InvalidOperationException("Fornecedor não encontrado.");

        fornecedorExistente.Nome = fornecedor.Nome;
        fornecedorExistente.Telemovel = fornecedor.Telemovel;
        fornecedorExistente.Email = fornecedor.Email == "Não cadastrado" ? null : fornecedor.Email;
        fornecedorExistente.EnderecoId = fornecedor.EnderecoId;

        try
        {
            await _fornecedorRepository.UpdateAsync(fornecedorExistente);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um fornecedor com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _fornecedorRepository.DetachEntity(fornecedorExistente);
        }
    }

    public async Task DeleteFornecedorAsync(FornecedorViewModel fornecedor)
    {
        var fornecedorExistente = await _fornecedorRepository.GetByIdAsync(fornecedor.FornecedorId);
        if (fornecedorExistente == null)
            throw new Exception("Fornecedor não encontrado.");

        await _fornecedorRepository.DeleteAsync(fornecedorExistente);
        _fornecedorRepository.DetachEntity(fornecedorExistente);
    }
}
