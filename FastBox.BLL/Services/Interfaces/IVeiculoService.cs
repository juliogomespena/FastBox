using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.DAL.Models;
using System.Linq.Expressions;

namespace FastBox.BLL.Services.Interfaces;

public interface IVeiculoService
{
    Task<IEnumerable<VeiculoViewModel>> GetVeiculosAsync(Expression<Func<Veiculo, bool>>? filter = null);
    Task<IEnumerable<VeiculoViewModel>> GetVeiculosInPagesAsync(int page, int size, VeiculoFilter? filter = null);
    Task<VeiculoViewModel> GetVeiculoByIdAsync(long id);
    Task AddVeiculoAsync(VeiculoViewModel veiculo);
    Task UpdateVeiculoAsync(VeiculoViewModel veiculo);
    Task DeleteVeiculoAsync(VeiculoViewModel veiculo);
}
