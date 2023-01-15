using Cliente.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cliente.Controllers
{
    public class LoginController : Controller
    {
        private readonly Servicios _servicios;
        public LoginController() {
            _servicios = new Servicios();  
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
           
            var response = _servicios.Login(login.Usuario, login.Password);
            if (response)
            {
                var rol = await _servicios.ObtenerRolesUsuario(login.Usuario);
              

                HttpContext.Session.SetString("usersess", login.Usuario);
                HttpContext.Session.SetString("rolsess", rol);
                return RedirectToAction("Index", "Productos");
            }
            else
            {
                ViewBag.alert = "Usuario o contrasena incorrecta";
                return View("Index");
            }

            
        }
    }
}
