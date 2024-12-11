using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IEnderecoService
{
    Task<long> AddEnderecoAsync(Endereco endereco);
    Task<long> UpdateEnderecoAsync(Endereco endereco);
    Task<Endereco> GetEnderecoByIdAsync(long id);
}
