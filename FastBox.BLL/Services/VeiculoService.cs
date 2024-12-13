using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class VeiculoService : IVeiculoService
{
    private readonly IRepository<Veiculo> _veiculoRepository;

    public VeiculoService(IRepository<Veiculo> veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<IEnumerable<VeiculoViewModel>> GetAllVeiculos()
    {
        return await _veiculoRepository.Query()
            .AsNoTracking()
            .Include(v => v.Cliente)
            .Include(v => v.OrdemDeServicos)
            .Select(v => new VeiculoViewModel
            {
                VeiculoId = v.VeiculoId,
                ClienteId = v.ClienteId == null ? 0 : v.ClienteId,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Matricula = v.Matricula,
                NomeCliente = v.Cliente == null ? "Não cadastrado" : v.Cliente.ToString(),
                Observacoes = string.IsNullOrEmpty(v.Observacoes) ? "Sem observações" : v.Observacoes,
                Cliente = v.Cliente,
                OrdemDeServicos = v.OrdemDeServicos
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<VeiculoViewModel>> GetVeiculosInPagesAsync(int page, int size)
    {
        return await _veiculoRepository.Query()
        .AsNoTracking()
        .Include(v => v.Cliente)
        .OrderByDescending(v => v.VeiculoId)
        .Skip((page - 1) * size)
        .Take(size)
        .Select(v => new VeiculoViewModel
        {
            VeiculoId = v.VeiculoId,
            Marca = v.Marca,
            Modelo = v.Modelo,
            Ano = v.Ano,
            Matricula = v.Matricula,
            NomeCliente = v.Cliente == null ? "Não cadastrado" : v.Cliente.ToString(),
            Observacoes = string.IsNullOrEmpty(v.Observacoes) ? "Sem observações" : v.Observacoes,
        })
        .ToListAsync();
    }

    public async Task<VeiculoViewModel> GetVeiculoByIdAsync(long id)
    {
        var veiculoExistente = await _veiculoRepository.Query()
            .Include(v => v.Cliente)
            .Include(v => v.OrdemDeServicos)
            .FirstOrDefaultAsync(v => v.VeiculoId == id);

        if (veiculoExistente == null)
            throw new Exception("Veículo não encontrado.");

        return new VeiculoViewModel
        {
            VeiculoId = veiculoExistente.VeiculoId,
            ClienteId = veiculoExistente.ClienteId == null ? 0 : veiculoExistente.ClienteId,
            Marca = veiculoExistente.Marca,
            Modelo = veiculoExistente.Modelo,
            Ano = veiculoExistente.Ano,
            Matricula = veiculoExistente.Matricula,
            NomeCliente = veiculoExistente.Cliente == null ? "Não cadastrado" : veiculoExistente.Cliente.ToString(),
            Observacoes = string.IsNullOrEmpty(veiculoExistente.Observacoes) ? "Sem observações" : veiculoExistente.Observacoes,
            Cliente = veiculoExistente.Cliente,
            OrdemDeServicos = veiculoExistente.OrdemDeServicos
        };
    }

    public async Task AddVeiculoAsync(VeiculoViewModel veiculo)
    {
        var veiculoConverted = new Veiculo
        {
            ClienteId = veiculo.ClienteId,
            Marca = veiculo.Marca,
            Modelo = veiculo.Modelo,
            Ano = veiculo.Ano,
            Matricula = veiculo.Matricula,
            Observacoes = veiculo.Observacoes,
            Cliente = veiculo.Cliente,
            OrdemDeServicos = veiculo.OrdemDeServicos
        };

        try
        {
            await _veiculoRepository.AddAsync(veiculoConverted);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um veículo com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _veiculoRepository.DetachEntity(veiculoConverted);
        }
    }

    public async Task UpdateVeiculoAsync(VeiculoViewModel veiculo)
    {
        var veiculoExistente = await _veiculoRepository.GetByIdAsync(veiculo.VeiculoId);
        if (veiculoExistente == null)
            throw new InvalidOperationException("Veículo não encontrado.");

        veiculoExistente.ClienteId = veiculo.ClienteId;
        veiculoExistente.Marca = veiculo.Marca;
        veiculoExistente.Modelo = veiculo.Modelo;
        veiculoExistente.Ano = veiculo.Ano;
        veiculoExistente.Matricula = veiculo.Matricula;
        veiculoExistente.Observacoes = veiculo.Observacoes;

        try
        {
            await _veiculoRepository.UpdateAsync(veiculoExistente);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um veículo com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _veiculoRepository.DetachEntity(veiculoExistente);
        }
    }

    public async Task DeleteVeiculoAsync(VeiculoViewModel veiculo)
    {
        var veiculoExistente = await _veiculoRepository.GetByIdAsync(veiculo.VeiculoId);
        if (veiculoExistente == null)
            throw new Exception("Veículo não encontrado.");

        await _veiculoRepository.DeleteAsync(veiculoExistente);
        _veiculoRepository.DetachEntity(veiculoExistente);
    }
}
