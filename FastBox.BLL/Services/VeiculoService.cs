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

    public async Task<IEnumerable<Veiculo>> GetAllVeiculos()
    {
        return await _veiculoRepository.GetAllAsync(asNoTracking: true);
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
            OrdensDeServico = v.OrdemDeServicos.Count,
            Observacoes = string.IsNullOrEmpty(v.Observacoes) ? "Sem observações" : v.Observacoes,
        })
        .ToListAsync();
    }

    public async Task<Veiculo> GetVeiculoByIdAsync(long id)
    {
        var veiculoExistente = await _veiculoRepository.GetByIdAsync(id);

        if (veiculoExistente == null)
            throw new Exception("Veículo não encontrado.");

        return veiculoExistente;
    }

    public async Task<Veiculo> GetVeiculoByIdWithIncludesAsync(long id)
    {
        var veiculoExistente = await _veiculoRepository.GetByIdWithIncludesAsync(
            v => v.VeiculoId == id,
            v => v.Cliente,
            v => v.OrdemDeServicos
        );

        if (veiculoExistente == null)
            throw new Exception("Veículo não encontrado.");

        return veiculoExistente;
    }

    public async Task AddVeiculoAsync(Veiculo veiculo)
    {
        try
        {
            await _veiculoRepository.AddAsync(veiculo);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe um veículo com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _veiculoRepository.DetachEntity(veiculo);
        }
    }

    public async Task UpdateVeiculoAsync(Veiculo veiculo)
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

    public async Task DeleteVeiculoAsync(Veiculo veiculo)
    {
        var veiculoExistente = await _veiculoRepository.GetByIdAsync(veiculo.VeiculoId);
        if (veiculoExistente == null)
            throw new Exception("Veículo não encontrado.");

        await _veiculoRepository.DeleteAsync(veiculoExistente);
        _veiculoRepository.DetachEntity(veiculoExistente);
    }
}
