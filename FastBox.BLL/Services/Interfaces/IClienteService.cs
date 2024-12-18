﻿using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.DAL.Models;

namespace FastBox.BLL.Services.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteViewModel>> GetAllClients();
    Task<IEnumerable<ClienteViewModel>> GetClientsInPagesAsync(int page, int size, ClienteFilter? filter = null);
    Task<ClienteViewModel> GetClientByIdAsync(long id);
    Task<IEnumerable<ClienteViewModel>> GetClientsByNameAsync(string searchText);
    Task AddClientAsync(ClienteViewModel cliente);
    Task UpdateClientAsync(ClienteViewModel cliente);
    Task DeleteClientAsync(ClienteViewModel cliente);
}
