using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Periferia.DataAccess;
using Periferia.Models.EntityModels;
using Periferia.Models.ViewModels;
using Periferia.ServiceContracts;

namespace Periferia.Web.Controllers
{
    public class VentaClientesController : Controller
    {
        private readonly IVentaClienteService _ventaClienteService;
        private readonly IProductosService _productosService;
        private readonly IClientesService _clientesService;
        public VentaClientesController(IVentaClienteService ventaClienteService,
                                        IProductosService productosService,
                                        IClientesService clientesService)
        {
            _ventaClienteService = ventaClienteService;
            _productosService = productosService;
            _clientesService = clientesService;
        }

        // GET: VentaClientes
        public async Task<IActionResult> Index()
        {

            return View(await _ventaClienteService.GetAllVentaClientesAsync());
        }


        // GET: VentaClientes/Create
        public async Task<IActionResult> Create()
        {
            IList<Producto> productos = await _productosService.GetAllProductsAsync();
            IList<Cliente> clientes = await _clientesService.GetAllClientesAsync();

            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nombre");
            ViewBag.Productos = JsonConvert.SerializeObject(productos);

            return View();
        }

        // POST: VentaClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateConfirm([FromBody]VentaVM venta)
        {
            VentaCliente ventaCliente = new()
            {
                ClienteId = venta.ClienteId,
                ValorTotal = venta.ValorTotal,
                ProductosVendidos = venta.ProductosVendidos.Select(x => new ProductoVendido { ProductoId = x.ProductoId, Cantidad = x.Cantidad }).ToList()
            };
            await _ventaClienteService.AddVentaClienteAsync(ventaCliente);
            return Ok();
        }

    }
}
