using FastBox.BLL.DTOs;
using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IVeiculoService
{
    Task<IEnumerable<Veiculo>> GetAllVeiculos();
    Task<IEnumerable<VeiculoViewModel>> GetVeiculosInPagesAsync(int page, int size);
    Task<Veiculo> GetVeiculoByIdAsync(long id);
    Task AddVeiculoAsync(Veiculo veiculo);
    Task UpdateVeiculoAsync(Veiculo veiculo);
    Task DeleteVeiculoAsync(Veiculo veiculo);
    Task<Veiculo> GetVeiculoByIdWithIncludesAsync(long id);
}
