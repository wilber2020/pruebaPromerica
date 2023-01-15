using Cliente.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cliente.Controllers
{

    public class ProductosController : Controller
    {
        private readonly Servicios _servicios;
        public ProductosController()
        {
            _servicios = new Servicios("http://localhost:47528");
        }
       
        public async Task<IActionResult> Index()
        {

            var rol = HttpContext.Session.GetString("rolsess");
            if (rol != null)
            {
                var productos = await _servicios.ProductosxRol(rol);

                ViewBag.Productos = productos;
                return View();
            }
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public IActionResult LoadPartialView([FromBody]string nombre)
        {
            var model = new Producto { producto = nombre};
            return PartialView("_ProdA", model);
        }
    }
}
