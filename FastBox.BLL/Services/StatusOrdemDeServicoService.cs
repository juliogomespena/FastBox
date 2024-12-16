using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.Services;

public class StatusOrdemDeServicoService : IStatusOrdemDeServicoService
{
    private readonly IRepository<StatusOrdemDeServico> _statusOrdemRepository;

    public StatusOrdemDeServicoService(IRepository<StatusOrdemDeServico> repository)
    {
        _statusOrdemRepository = repository;
    }

    public async Task<IEnumerable<StatusOrdemDeServicoViewModel>> GetAllStatusAsync()
    {
        return await _statusOrdemRepository.Query()
        .Select(status => new StatusOrdemDeServicoViewModel
        {
            StatusOrdemDeServicoId = status.StatusOrdemDeServicoId,
            Nome = status.Nome,
            Descricao = status.Descricao,
        }).ToListAsync();
    }
}
