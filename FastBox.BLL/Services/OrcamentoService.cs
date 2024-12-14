using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastBox.BLL.Services;

public class OrcamentoService : IOrcamentoService
{
    public Task<IEnumerable<OrcamentoViewModel>> GetAllOrcamentos()
    {
        throw new NotImplementedException();
    }

    public Task AddOrcamentoAsync(OrcamentoViewModel orcamento)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrcamentoAsync(OrcamentoViewModel orcamento)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrcamentoAsync(OrcamentoViewModel orcamento)
    {
        throw new NotImplementedException();
    }
}
