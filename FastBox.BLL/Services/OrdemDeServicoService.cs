using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class OrdemDeServicoService : IOrdemDeServicoService
{
    private readonly IRepository<OrdemDeServico> _ordemRepository;

    public OrdemDeServicoService(IRepository<OrdemDeServico> ordemRepository)
    {
        _ordemRepository = ordemRepository;
    }

    public async Task<IEnumerable<OrdemDeServicoViewModel>> GetAllOrdens()
    {
        return await _ordemRepository.Query()
            .AsNoTracking()
            .Include(o => o.Cliente)
            .Include(o => o.Orcamentos)
            .Include(o => o.Pagamentos)
            .Include(o => o.StatusOrdemDeServico)
            .Include(o => o.Veiculo)
            .Select(o => new OrdemDeServicoViewModel
            {
                OrdemDeServicoId = o.OrdemDeServicoId,
                ClienteId = o.ClienteId,
                VeiculoId = o.VeiculoId,
                StatusOrdemDeServicoId = o.StatusOrdemDeServicoId,
                Descricao = o.Descricao,
                DataAbertura = o.DataAbertura,
                EstimativaConclusao = o.EstimativaConclusao,
                DataConclusao = o.DataConclusao,
                GarantiaEmDias = o.GarantiaEmDias,
                ObservacoesGarantia = o.ObservacoesGarantia,
                Cliente = o.Cliente,
                Orcamentos = o.Orcamentos,
                Pagamentos = o.Pagamentos,
                StatusOrdemDeServico = o.StatusOrdemDeServico,
                Veiculo = o.Veiculo,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<OrdemDeServicoViewModel>> GetOrdensInPagesAsync(int page, int size)
    {
        return await _ordemRepository.Query()
            .AsNoTracking()
            .Include(o => o.Cliente)
            .Include(o => o.Orcamentos)
            .Include(o => o.Pagamentos)
            .Include(o => o.StatusOrdemDeServico)
            .Include(o => o.Veiculo)
            .OrderByDescending(o => o.OrdemDeServicoId)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(o => new OrdemDeServicoViewModel
            {
                OrdemDeServicoId = o.OrdemDeServicoId,
                ClienteId = o.ClienteId,
                VeiculoId = o.VeiculoId,
                StatusOrdemDeServicoId = o.StatusOrdemDeServicoId,
                Descricao = o.Descricao,
                DataAbertura = o.DataAbertura,
                EstimativaConclusao = o.EstimativaConclusao,
                DataConclusao = o.DataConclusao,
                GarantiaEmDias = o.GarantiaEmDias,
                ObservacoesGarantia = o.ObservacoesGarantia,
                Cliente = o.Cliente,
                Orcamentos = o.Orcamentos,
                Pagamentos = o.Pagamentos,
                StatusOrdemDeServico = o.StatusOrdemDeServico,
                Veiculo = o.Veiculo,
            })
            .ToListAsync();
    }

    public async Task<OrdemDeServicoViewModel> GetOrdemByIdAsync(long id)
    {
        var ordemExistente = await _ordemRepository.Query()
            .Include(o => o.Cliente)
            .Include(o => o.Orcamentos)
            .Include(o => o.Pagamentos)
            .Include(o => o.StatusOrdemDeServico)
            .Include(o => o.Veiculo)
            .FirstOrDefaultAsync(o => o.OrdemDeServicoId == id);

        if (ordemExistente == null)
            throw new Exception("Ordem de serviço não encontrada.");

        return new OrdemDeServicoViewModel
        {
            OrdemDeServicoId = ordemExistente.OrdemDeServicoId,
            ClienteId = ordemExistente.ClienteId,
            VeiculoId = ordemExistente.VeiculoId,
            StatusOrdemDeServicoId = ordemExistente.StatusOrdemDeServicoId,
            Descricao = ordemExistente.Descricao,
            DataAbertura = ordemExistente.DataAbertura,
            EstimativaConclusao = ordemExistente.EstimativaConclusao,
            DataConclusao = ordemExistente.DataConclusao,
            GarantiaEmDias = ordemExistente.GarantiaEmDias,
            ObservacoesGarantia = ordemExistente.ObservacoesGarantia,
            Cliente = ordemExistente.Cliente,
            Orcamentos = ordemExistente.Orcamentos,
            Pagamentos = ordemExistente.Pagamentos,
            StatusOrdemDeServico = ordemExistente.StatusOrdemDeServico,
            Veiculo = ordemExistente.Veiculo,
        };
    }

    public Task AddOrdemAsync(OrdemDeServicoViewModel ordem)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrdemAsync(OrdemDeServicoViewModel ordem)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrdemAsync(OrdemDeServicoViewModel ordem)
    {
        throw new NotImplementedException();
    }
}
