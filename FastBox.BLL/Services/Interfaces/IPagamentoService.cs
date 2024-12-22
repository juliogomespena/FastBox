using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IPagamentoService
{
    Task<IEnumerable<MetodoDePagamentoViewModel>> GetAllMetodosDePagamento();
}
