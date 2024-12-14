using FastBox.BLL.DTOs;

namespace FastBox.BLL.Services.Interfaces;

public interface IOrcamentoService
{
    Task<IEnumerable<OrcamentoViewModel>> GetAllOrcamentos();
    Task AddOrcamentoAsync(OrcamentoViewModel orcamento);
    Task UpdateOrcamentoAsync(OrcamentoViewModel orcamento);
    Task DeleteOrcamentoAsync(OrcamentoViewModel orcamento);
}
