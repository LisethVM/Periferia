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
    public class ProductosService : IProductosService
    {
        private readonly IRepository<Producto> _productsRepository;

        public ProductosService(IRepository<Producto> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Producto> AddProductoAsync(Producto producto)
        {
            return await _productsRepository.AddAsync(producto);
        }

        public async Task DeleteProductoAsync(string productoId)
        {
            var producto = await _productsRepository.GetAsync(x => x.Id.Equals(productoId));
            if (producto != null)
                await _productsRepository.DeleteAsync(producto);
        }

        public async Task<IList<Producto>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<Producto> GetProductoAsync(string id)
        {
            return await _productsRepository.GetAsync(x => x.Id.Equals(id));
        }

        public async Task<Producto> UpdateProducto(Producto producto)
        {
            return await _productsRepository.UpdateAsync(producto);
        }
    }
}
