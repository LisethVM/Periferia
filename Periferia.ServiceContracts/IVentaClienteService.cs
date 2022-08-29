using Periferia.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.ServiceContracts
{
    public interface IVentaClienteService
    {
        Task<VentaCliente> AddVentaClienteAsync(VentaCliente ventaCliente);
        Task<IList<VentaCliente>> GetAllVentaClientesAsync();
        
    }
}
