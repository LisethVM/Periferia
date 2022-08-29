using Periferia.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.ServiceContracts
{
    public interface IClientesService
    {
        Task<Cliente> AddClienteAsync(Cliente cliente);
        Task<IList<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteAsync(string id);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task DeleteClienteAsync(string clienteId);
    }
}
