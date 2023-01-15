using ApiProductos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Data _data;
        public ProductosController()
        {
            _data= new Data();
        }
        [HttpGet("ProductosxRol")]
        public List<Producto> ProductosxRol(string rol)
        {
            return _data._productos.FindAll(p => p.Rol == rol);
        }
    }
}
