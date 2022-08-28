using Microsoft.EntityFrameworkCore;
using Periferia.Models;
using Periferia.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.DataAccess
{
    public class TiendaDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoVendido> ProductosVendidos { get; set; }
        public DbSet<VentaCliente> Ventas { get; set; }

        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
