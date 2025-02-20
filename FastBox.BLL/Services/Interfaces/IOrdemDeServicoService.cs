using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;

namespace FastBox.BLL.Services.Interfaces;

public interface IOrdemDeServicoService
{
    Task<IEnumerable<OrdemDeServicoViewModel>> GetAllOrdens(OrdemDeServicoFilter? filter = null);
    Task<IEnumerable<OrdemDeServicoViewModel>> GetOrdensInPagesAsync(int page, int size, OrdemDeServicoFilter? filter = null);
    Task<OrdemDeServicoViewModel> GetOrdemByIdAsync(long id);
    Task AddOrdemAsync(OrdemDeServicoViewModel ordem);
    Task UpdateOrdemAsync(OrdemDeServicoViewModel ordem);
    Task DeleteOrdemAsync(OrdemDeServicoViewModel ordem);
}
