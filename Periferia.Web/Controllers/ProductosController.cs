using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Periferia.Models.EntityModels;
using Periferia.ServiceContracts;
using Periferia.Services;

namespace Periferia.Web.Controllers
{
    public class ProductosController : Controller
    {
        readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }


        // GET: Productos
        public async Task<ActionResult> Index()
        {
            var products = await _productosService.GetAllProductsAsync();
            return View(products);
        }

        // GET: Productos/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productosService.GetProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nombre,ValorUnitario")] Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productosService.AddProductoAsync(producto);
                    return RedirectToAction(nameof(Index));
                }
                return View(producto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productosService.GetProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("Nombre,ValorUnitario,Id")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productosService.UpdateProducto(producto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productosService.GetProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmation(string id)
        {
            try
            {
                await _productosService.DeleteProductoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<bool> ProductoExists(string id)
        {
            return (await _productosService.GetProductoAsync(id)) != null;
        }
    }
}
