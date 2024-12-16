using FastBox.BLL.DTOs;
using FastBox.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.Services.Interfaces;

public interface IStatusOrdemDeServicoService
{
    Task<IEnumerable<StatusOrdemDeServicoViewModel>> GetAllStatusAsync();
}
