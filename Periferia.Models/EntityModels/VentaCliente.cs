using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.Models.EntityModels
{
    public class VentaCliente : EntityBase
    {
        public string ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ValorTotal { get; set; }

        public IList<ProductoVendido> ProductosVendidos { get; set; }
    }
}
