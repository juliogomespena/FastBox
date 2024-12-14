using FastBox.BLL.DTOs;

namespace FastBox.BLL.Services.Interfaces;

public interface IItemOrcamento
{
    Task AddItemOrcamentoAsync(ItemOrcamentoViewModel item);
    Task UpdateItemOrcamentoAsync(ItemOrcamentoViewModel item);
    Task DeleteItemOrcamentoAsync(ItemOrcamentoViewModel item);
}
