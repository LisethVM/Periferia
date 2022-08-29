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
    public class ClientesService : IClientesService
    {
        readonly IRepository<Cliente> _clienteRepository;

        public ClientesService(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.AddAsync(cliente);
        }

        public async Task DeleteClienteAsync(string clienteId)
        {
            var cliente = await _clienteRepository.GetAsync(x => x.Id.Equals(clienteId));
            if (cliente != null)
                await _clienteRepository.DeleteAsync(cliente);
        }

        public async Task<IList<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> GetClienteAsync(string id)
        {
            return await _clienteRepository.GetAsync(x => x.Id.Equals(id));
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            return await _clienteRepository.UpdateAsync(cliente);
        }
    }
}
