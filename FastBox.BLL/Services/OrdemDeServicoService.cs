﻿using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.Intrinsics.Arm;

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
                .ThenInclude(i => i.ItensOrcamento)
                    .ThenInclude(f => f.Fornecedor)
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
                ValorTotal  = o.ValorTotal,
                IncluirIva = o.IncluirIva,
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

    public async Task<IEnumerable<OrdemDeServicoViewModel>> GetOrdensInPagesAsync(int page, int size, OrdemDeServicoFilter? filter = null)
    {
        var query = _ordemRepository.Query().AsNoTracking();

        if(filter != null)
        {
            if (!String.IsNullOrWhiteSpace(filter.Status))
                query = query.Where(ordem => ordem.StatusOrdemDeServico.Nome.Equals(filter.Status));
            if (!String.IsNullOrWhiteSpace(filter.Cliente))
                query = query.Where(ordem => ordem.Cliente != null && (ordem.Cliente.Nome + " " + ordem.Cliente.Sobrenome).Contains(filter.Cliente));
            if (!String.IsNullOrWhiteSpace(filter.Veiculo))
                query = query.Where(ordem => ordem.Veiculo != null && (ordem.Veiculo.Modelo + " " + ordem.Veiculo.Marca + " " + ordem.Veiculo.Matricula).Contains(filter.Veiculo));
            if (!String.IsNullOrWhiteSpace(filter.Descricao))
                query = query.Where(ordem => ordem.Descricao.Contains(filter.Descricao));
            if (filter.DataAbertura != null)
                query = query.Where(ordem => ordem.DataAbertura.Date == filter.DataAbertura.Value.Date);
            if (filter.PrazoEstimado != null)
                query = query.Where(ordem => ordem.EstimativaConclusao != null && ordem.EstimativaConclusao.Value.Date == filter.PrazoEstimado.Value.Date);
            if (filter.ValorTotal != null && filter.ValorTotalMaiorOuIgual == true)
                query = query.Where(ordem => ordem.ValorTotal >= filter.ValorTotal);
            if (filter.ValorTotal != null && filter.ValorTotalMaiorOuIgual == false)
                query = query.Where(ordem => ordem.ValorTotal <= filter.ValorTotal);            
        }

        return await query
            .AsNoTracking()
            .Include(o => o.Cliente)
            .Include(o => o.Orcamentos)
                .ThenInclude(i => i.ItensOrcamento)
                        .ThenInclude(f => f.Fornecedor)
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
                ValorTotal = o.ValorTotal,
                IncluirIva = o.IncluirIva,
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
                    .ThenInclude(f => f.Fornecedor)
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
            ValorTotal = ordemExistente.ValorTotal,
            IncluirIva = ordemExistente.IncluirIva,
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
        var statusOrdemDeServicoId = DetermineOrderStatus(ordem);

        var valorTotalOrdem = Math.Round(ordem.Orcamentos.Where(orcamentos => orcamentos.StatusOrcamento == 2).SelectMany(orcamento => orcamento.ItensOrcamento).Sum(itens => (itens.PrecoUnitario + (itens.PrecoUnitario * itens.Margem)) * itens.Quantidade), 2, MidpointRounding.AwayFromZero);

        if (ordem.IncluirIva == true)
            valorTotalOrdem = Math.Round(valorTotalOrdem + (valorTotalOrdem * (decimal)0.23), 2, MidpointRounding.AwayFromZero);

        var ordemConverted = new OrdemDeServico
        {
            StatusOrdemDeServicoId = statusOrdemDeServicoId,
            ClienteId = ordem.ClienteId,
            VeiculoId = ordem.VeiculoId,
            Descricao = ordem.Descricao,
            EstimativaConclusao = ordem.EstimativaConclusao,
            ValorTotal = valorTotalOrdem,
            IncluirIva = ordem.IncluirIva,
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
                    Margem = itens.Margem,
                    FornecedorId = itens.FornecedorId,
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
            if (ordemExistente.StatusOrdemDeServicoId == 7)
                throw new InvalidOperationException("A ordem de serviço foi cancelada e não pode ser alterada.");
            if (ordemExistente.StatusOrdemDeServicoId == 6)
                throw new InvalidOperationException("A ordem de serviço foi concluída e não pode ser alterada.");
            if (ordemExistente.StatusOrdemDeServicoId == 5)
                throw new InvalidOperationException("O veículo já foi retirado e a ordem não pode ser alterada.");

            var statusOrdemDeServicoId = DetermineOrderStatus(ordem);

            var valorTotalOrdem = Math.Round(ordem.Orcamentos.Where(orcamentos => orcamentos.StatusOrcamento == 2).SelectMany(orcamento => orcamento.ItensOrcamento).Sum(itens => (itens.PrecoUnitario + (itens.PrecoUnitario * itens.Margem)) * itens.Quantidade), 2, MidpointRounding.AwayFromZero);

            if (ordem.IncluirIva == true)
                valorTotalOrdem = Math.Round(valorTotalOrdem + (valorTotalOrdem * (decimal)0.23), 2, MidpointRounding.AwayFromZero);

            if (ordem.StatusOrdemDeServicoId == 7)
                foreach (var orcamento in ordem.Orcamentos) orcamento.StatusOrcamento = 3;

            ordemExistente.StatusOrdemDeServicoId = statusOrdemDeServicoId;
            ordemExistente.ClienteId = ordem.ClienteId;
            ordemExistente.VeiculoId = ordem.VeiculoId;
            ordemExistente.Descricao = ordem.Descricao;
            ordemExistente.EstimativaConclusao = ordem.EstimativaConclusao;
            ordemExistente.ValorTotal = valorTotalOrdem;
            ordemExistente.IncluirIva = ordem.IncluirIva;

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
                            itemExistente.FornecedorId = itemViewModel.FornecedorId;
                        }
                        else
                        {
                            orcamentoExistente.ItensOrcamento.Add(new ItemOrcamento
                            {
                                Descricao = itemViewModel.Descricao,
                                Quantidade = itemViewModel.Quantidade,
                                PrecoUnitario = itemViewModel.PrecoUnitario,
                                Margem = itemViewModel.Margem,
                                FornecedorId = itemViewModel.FornecedorId
                            });
                        }
                    }

                    var itensParaRemover = orcamentoExistente.ItensOrcamento.Where(i => i.ItemOrcamentoId > 0 && !orcamentoViewModel.ItensOrcamento.Any(v => v.ItemOrcamentoId == i.ItemOrcamentoId)).ToList();

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
                            Margem = i.Margem,
                            FornecedorId = i.FornecedorId,
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

    private int DetermineOrderStatus(OrdemDeServicoViewModel ordem)
    {
        var statusOrdemDeServicoId = 1;
        if (ordem.StatusOrdemDeServicoId == 7)
            statusOrdemDeServicoId = 7;
        else if (ordem.StatusOrdemDeServicoId > 3)
            statusOrdemDeServicoId = (int)ordem.StatusOrdemDeServicoId;
        else if (ordem.Orcamentos.Any(o => o.StatusOrcamento == 2) && ordem.Orcamentos.Any(o => o.StatusOrcamento == 3))
            statusOrdemDeServicoId = 3;
        else if (ordem.Orcamentos.Any(o => o.StatusOrcamento == 1 || o.StatusOrcamento == 3))
            statusOrdemDeServicoId = 2;
        else if (ordem.Orcamentos.All(o => o.StatusOrcamento == 2) && ordem.Orcamentos.Count != 0)
            statusOrdemDeServicoId = 3;

        return statusOrdemDeServicoId;
    }
}
