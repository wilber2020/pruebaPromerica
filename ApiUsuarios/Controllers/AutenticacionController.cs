using ApiUsuarios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly Autenticacion _auth;
        public AutenticacionController()
        {
            _auth = new Autenticacion();
        }

        [HttpPost("login")]
        public ActionResult<string> Login(User usuario)
        {
            if (_auth.ValidarCredenciales(usuario.Usuario, usuario.Password))
            {
                return Ok("Login correcto...");
            }
            return Unauthorized("Usuario o password invalido...");
        }

        [HttpGet("Rol")]
        public ActionResult<string> ObtenerRolesUsuario(string username)
        {
            var role = _auth.ObtenerRolesUsuario(username);
            if (!string.IsNullOrEmpty(role))
            {
                return Ok(role);
            }
            return NotFound("Usuario no encontrado...");
        }

    }
}
