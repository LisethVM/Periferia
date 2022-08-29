using Microsoft.EntityFrameworkCore;
using Periferia.DataAccess.Repository;
using Periferia.Models.EntityModels;
using Periferia.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.Services
{
    public class VentaClienteService : IVentaClienteService
    {
        readonly IRepository<VentaCliente> _ventaClienteRepository;
        public VentaClienteService(IRepository<VentaCliente> ventaClienteRepository)
        {
            _ventaClienteRepository = ventaClienteRepository;
        }

        public async Task<VentaCliente> AddVentaClienteAsync(VentaCliente ventaCliente)
        {
            return await _ventaClienteRepository.AddAsync(ventaCliente);
        }

        public async Task<IList<VentaCliente>> GetAllVentaClientesAsync()
        {
            return await _ventaClienteRepository.AsQueryable()
                .Include(x => x.Cliente)
                .Include(x => x.ProductosVendidos).ThenInclude(x => x.Producto)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync(); 
        }
    }
}
