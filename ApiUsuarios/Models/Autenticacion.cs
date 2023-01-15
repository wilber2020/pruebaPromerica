using System.Linq;

namespace ApiUsuarios.Models
{
    public class Autenticacion
    {
        private readonly Data _datos; 
        public Autenticacion() {
        
            _datos= new Data();  
        }


        public bool ValidarCredenciales(string username, string password)
        {
            var user = _datos.Usuarios.FirstOrDefault(x => x.Usuario == username && x.Password == password);
            return user != null;
        }
        public string ObtenerRolesUsuario(string username)
        {
            var rol = _datos.Roles.FirstOrDefault(x => x.Usuario == username);

            if (rol!=null)
            {
                return rol.Rol;
            }
            return "";    
        }

    }
}
