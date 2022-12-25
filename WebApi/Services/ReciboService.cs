using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.IRepositories;
using WebApi.Domain.IServices;
using WebApi.Domain.Models;

namespace WebApi.Services
{
    public class ReciboService : IReciboService
    {
        private readonly IReciboRepository _reciboRepository;
        public ReciboService(IReciboRepository reciboRepository)
        {
            _reciboRepository = reciboRepository;
        }
        public async Task<List<Recibo>> GetListRecibos()
        {
            return await _reciboRepository.GetListRecibos();
        }

        public async Task SaveRecibo(Recibo recibo)
        {
            await _reciboRepository.SaveRecibo(recibo);
        }

        public async Task UpdateLogoRecibo(Recibo recibo)
        {
            await _reciboRepository.UpdateLogoRecibo(recibo);
        }
    }
}
