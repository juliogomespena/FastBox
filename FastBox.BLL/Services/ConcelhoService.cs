using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.DAL.Repositories;

namespace FastBox.BLL.Services;

public class ConcelhoService : IConcelhoService
{
    private readonly IRepository<Concelho> _concelhoRepository;
    public ConcelhoService(IRepository<Concelho> concelhoRepository)
    {
        _concelhoRepository = concelhoRepository;
    }
    public async Task<List<Concelho>> GetAllConcelhosAsync()
    {
        return (await _concelhoRepository.GetAllAsync()).OrderBy(c => c.Nome).ToList();
    }
}
