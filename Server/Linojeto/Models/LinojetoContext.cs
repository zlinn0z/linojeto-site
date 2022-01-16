using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linojeto.Models
{
    public class LinojetoContext : DbContext
    {
        public LinojetoContext(DbContextOptions<LinojetoContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
