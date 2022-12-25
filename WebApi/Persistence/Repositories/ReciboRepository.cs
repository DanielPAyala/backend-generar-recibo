using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.IRepositories;
using WebApi.Domain.Models;
using WebApi.Persistence.Context;

namespace WebApi.Persistence.Repositories
{
    public class ReciboRepository : IReciboRepository
    {
        private readonly AplicationDbContext _context;

        public ReciboRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recibo>> GetListRecibos()
        {
            return await _context.Recibo.ToListAsync();
        }

        public async Task SaveRecibo(Recibo recibo)
        {
            _context.Add(recibo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLogoRecibo(Recibo recibo)
        {
            _context.Entry(recibo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
