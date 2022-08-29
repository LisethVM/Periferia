using Periferia.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.ServiceContracts
{
    public interface IProductosService
    {
        Task<Producto> AddProductoAsync(Producto producto);
        Task<IList<Producto>> GetAllProductsAsync();
        Task<Producto> GetProductoAsync(string id);
        Task<Producto> UpdateProducto(Producto producto);
        Task DeleteProductoAsync(string productoId);
    }
}
