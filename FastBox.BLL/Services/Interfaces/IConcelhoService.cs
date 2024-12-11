using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IConcelhoService
{
    Task<List<Concelho>> GetAllConcelhosAsync();
}
