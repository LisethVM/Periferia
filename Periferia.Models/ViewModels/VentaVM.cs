using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.Models.ViewModels
{
    public class VentaVM
    {
        public string ClienteId { get;set; }
        public int ValorTotal { get; set; }
        public IList<ProductoVendidoVM> ProductosVendidos { get; set; }
    }
    public class ProductoVendidoVM
    {
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
