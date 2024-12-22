using FastBox.BLL.DTOs;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Repositories;
using FastBox.DAL.Models;
using Microsoft.EntityFrameworkCore;
using FastBox.DAL.Migrations;
using System.Runtime.Intrinsics.Arm;

namespace FastBox.BLL.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IRepository<MetodoPagamento> _metodoDePagamentoRepository;
        private readonly IRepository<Pagamento> _pagamentoRepository;
        private readonly IRepository<OrdemDeServico> _ordemDeServicoRepository;

        public PagamentoService(IRepository<MetodoPagamento> metodoDePagamentoRepository, IRepository<Pagamento> pagamentoRepository, IRepository<OrdemDeServico> ordemDeServicoRepository)
        {
            _metodoDePagamentoRepository = metodoDePagamentoRepository;
            _pagamentoRepository = pagamentoRepository;
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<IEnumerable<MetodoDePagamentoViewModel>> GetAllMetodosDePagamento()
        {
            return await _metodoDePagamentoRepository.Query().AsNoTracking()
            .Include(m => m.Pagamentos)
            .Select(m => new MetodoDePagamentoViewModel()
            {
                MetodoPagamentoId = m.MetodoPagamentoId,
                Nome = m.Nome,
                Pagamentos = m.Pagamentos
            })
            .ToListAsync();
        }
    }
}
