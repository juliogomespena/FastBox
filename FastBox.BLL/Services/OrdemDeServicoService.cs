using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class OrdemDeServicoService : IOrdemDeServicoService
{
    private readonly IRepository<OrdemDeServico> _ordemRepository;
    private readonly IRepository<Orcamento> _orcamentoRepository;
    private readonly IRepository<ItemOrcamento> _itemOrcamentoRepository;

    public OrdemDeServicoService(IRepository<OrdemDeServico> ordemRepository, IRepository<Orcamento> orcamentoRepository, IRepository<ItemOrcamento> itemOrcamentoRepository)
    {
        _ordemRepository = ordemRepository;
        _orcamentoRepository = orcamentoRepository;
        _itemOrcamentoRepository = itemOrcamentoRepository;
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
                .ThenInclude(o => o.ItensOrcamento)
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

    public async Task AddOrdemAsync(OrdemDeServicoViewModel ordem)
    {
        var ordemConverted = new OrdemDeServico
        {
            StatusOrdemDeServicoId = ordem.StatusOrdemDeServicoId,
            ClienteId = ordem.ClienteId,
            VeiculoId = ordem.VeiculoId,
            Descricao = ordem.Descricao,
            EstimativaConclusao = ordem.EstimativaConclusao,
            Orcamentos = ordem.Orcamentos.Select(orcamento => new Orcamento
            {
                StatusOrcamento = orcamento.StatusOrcamento,
                DataCriacao = orcamento.DataCriacao,
                Descricao = orcamento.Descricao == "Sem descrição" ? null : orcamento.Descricao,
                ItensOrcamento = orcamento.ItensOrcamento.Select(itens => new ItemOrcamento
                {
                    Descricao = itens.Descricao,
                    Quantidade = itens.Quantidade,
                    PrecoUnitario = itens.PrecoUnitario,
                    Margem = itens.Margem
                }).ToList()
            }).ToList()
        };

        try
        {
            await _ordemRepository.AddAsync(ordemConverted);
        }
        catch (DbUpdateException ex)
        {

            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe uma ordem com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            _ordemRepository.DetachEntity(ordemConverted);
        }
    }

    public async Task UpdateOrdemAsync(OrdemDeServicoViewModel ordem)
    {
        OrdemDeServico? ordemExistente = null;

        try
        {
            ordemExistente = await _ordemRepository.Query()
                .Include(o => o.Orcamentos)
                    .ThenInclude(o => o.ItensOrcamento)
                .FirstOrDefaultAsync(o => o.OrdemDeServicoId == ordem.OrdemDeServicoId);

            if (ordemExistente == null)
                throw new InvalidOperationException("Ordem de serviço não encontrada.");

            ordemExistente.StatusOrdemDeServicoId = ordem.StatusOrdemDeServicoId;
            ordemExistente.ClienteId = ordem.ClienteId;
            ordemExistente.VeiculoId = ordem.VeiculoId;
            ordemExistente.Descricao = ordem.Descricao;
            ordemExistente.EstimativaConclusao = ordem.EstimativaConclusao;

            foreach (var orcamentoViewModel in ordem.Orcamentos)
            {
                var orcamentoExistente = ordemExistente.Orcamentos
                    .FirstOrDefault(o => o.OrcamentoId == orcamentoViewModel.OrcamentoId);

                if (orcamentoExistente != null)
                {
                    orcamentoExistente.StatusOrcamento = orcamentoViewModel.StatusOrcamento;
                    orcamentoExistente.Descricao = orcamentoViewModel.Descricao == "Sem descrição" ? null : orcamentoViewModel.Descricao;

                    foreach (var itemViewModel in orcamentoViewModel.ItensOrcamento)
                    {
                        var itemExistente = orcamentoExistente.ItensOrcamento
                            .FirstOrDefault(i => i.ItemOrcamentoId == itemViewModel.ItemOrcamentoId);

                        if (itemExistente != null)
                        {
                            itemExistente.Descricao = itemViewModel.Descricao;
                            itemExistente.Quantidade = itemViewModel.Quantidade;
                            itemExistente.PrecoUnitario = itemViewModel.PrecoUnitario;
                            itemExistente.Margem = itemViewModel.Margem;
                        }
                        else
                        {
                            orcamentoExistente.ItensOrcamento.Add(new ItemOrcamento
                            {
                                Descricao = itemViewModel.Descricao,
                                Quantidade = itemViewModel.Quantidade,
                                PrecoUnitario = itemViewModel.PrecoUnitario,
                                Margem = itemViewModel.Margem
                            });
                        }
                    }

                    var itensParaRemover = orcamentoExistente.ItensOrcamento
                        .Where(i => !orcamentoViewModel.ItensOrcamento.Any(v => v.ItemOrcamentoId == i.ItemOrcamentoId))
                        .ToList();

                    foreach (var itemRemovido in itensParaRemover)
                    {
                        orcamentoExistente.ItensOrcamento.Remove(itemRemovido);
                    }
                }
                else
                {
                    ordemExistente.Orcamentos.Add(new Orcamento
                    {
                        StatusOrcamento = orcamentoViewModel.StatusOrcamento,
                        DataCriacao = orcamentoViewModel.DataCriacao,
                        Descricao = orcamentoViewModel.Descricao == "Sem descrição" ? null : orcamentoViewModel.Descricao,
                        ItensOrcamento = orcamentoViewModel.ItensOrcamento.Select(i => new ItemOrcamento
                        {
                            Descricao = i.Descricao,
                            Quantidade = i.Quantidade,
                            PrecoUnitario = i.PrecoUnitario,
                            Margem = i.Margem
                        }).ToList()
                    });
                }
            }

            var orcamentosParaRemover = ordemExistente.Orcamentos
                .Where(o => !ordem.Orcamentos.Any(v => v.OrcamentoId == o.OrcamentoId))
                .ToList();
            foreach (var orcamentoRemovido in orcamentosParaRemover)
            {
                foreach (var item in orcamentoRemovido.ItensOrcamento.ToList())
                {
                    _itemOrcamentoRepository.RemoveEntity(item);
                }

                _orcamentoRepository.RemoveEntity(orcamentoRemovido);
            }

            await _ordemRepository.UpdateAsync(ordemExistente);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("UNIQUE") ?? false)
                throw new InvalidOperationException("Já existe uma ordem com os mesmos dados únicos.");

            throw;
        }
        finally
        {
            if (ordemExistente != null)
                _ordemRepository.DetachEntity(ordemExistente);
        }
    }

    public async Task DeleteOrdemAsync(OrdemDeServicoViewModel ordem)
    {
        var ordemExistente = await _ordemRepository.GetByIdAsync(ordem.OrdemDeServicoId);

        if (ordemExistente == null)
            throw new Exception("Ordem de serviço não encontrada.");

        await _ordemRepository.DeleteAsync(ordemExistente);
        _ordemRepository.DetachEntity(ordemExistente);
    }
}
