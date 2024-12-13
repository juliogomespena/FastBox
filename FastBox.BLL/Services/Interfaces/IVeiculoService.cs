using FastBox.BLL.DTOs;
using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IVeiculoService
{
    Task<IEnumerable<VeiculoViewModel>> GetAllVeiculos();
    Task<IEnumerable<VeiculoViewModel>> GetVeiculosInPagesAsync(int page, int size);
    Task<VeiculoViewModel> GetVeiculoByIdAsync(long id);
    Task AddVeiculoAsync(VeiculoViewModel veiculo);
    Task UpdateVeiculoAsync(VeiculoViewModel veiculo);
    Task DeleteVeiculoAsync(VeiculoViewModel veiculo);
}
