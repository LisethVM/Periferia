using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.Models.EntityModels
{
    public class ProductoVendido : EntityBase
    {
        public string ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public string VentaClienteId { get; set; }
        public virtual VentaCliente VentaCliente { get; set; }
    }
}
