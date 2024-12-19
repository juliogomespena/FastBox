using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IFornecedorService
{
    Task<IEnumerable<FornecedorViewModel>> GetAllFornecedores();
    Task<IEnumerable<FornecedorViewModel>> GetFornecedoresInPagesAsync(int page, int size, FornecedorFilter? filter = null);
    Task<FornecedorViewModel> GetFornecedorByIdAsync(long id);
    Task<IEnumerable<FornecedorViewModel>> GetFornecedoresByNameAsync(string searchText);

    Task<FornecedorViewModel> GetFornecedorByNameAsync(string searchText);
    Task AddFornecedorAsync(FornecedorViewModel fornecedor);
    Task UpdateFornecedorAsync(FornecedorViewModel fornecedor);
    Task DeleteFornecedorAsync(FornecedorViewModel fornecedor);
}
