using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Recibo> Recibo { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
    }
}
