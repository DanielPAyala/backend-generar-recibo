using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.IRepositories
{
    public interface IReciboRepository
    {
        Task SaveRecibo(Recibo recibo);
        Task<List<Recibo>> GetListRecibos();
        Task UpdateLogoRecibo(Recibo recibo);
    }
}
