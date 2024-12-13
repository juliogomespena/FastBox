using FastBox.BLL.DTOs;

namespace FastBox.BLL.Services.Interfaces;

public interface IOrdemDeServicoService
{
    Task<IEnumerable<OrdemDeServicoViewModel>> GetAllOrdens();
    Task<IEnumerable<OrdemDeServicoViewModel>> GetOrdensInPagesAsync(int page, int size);
    Task<OrdemDeServicoViewModel> GetOrdemByIdAsync(long id);
    Task AddOrdemAsync(OrdemDeServicoViewModel ordem);
    Task UpdateOrdemAsync(OrdemDeServicoViewModel ordem);
    Task DeleteOrdemAsync(OrdemDeServicoViewModel ordem);
}
