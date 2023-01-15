using System.Collections.Generic;

namespace ApiUsuarios.Models
{
    public class Data
    {
        public List<User> Usuarios { get; }
        public List<Role> Roles { get; }

        public Data()
        {
            Usuarios = new List<User>
            {
                new User {
                 Password= "Clave1",
                 Usuario= "User1"
                },
                new User {
                 Password= "Clave2",
                 Usuario= "User2"
                }

            };

            Roles = new List<Role>
            {
                new Role
                {
                    Rol="Principal",
                    Usuario="User1"
                },
                new Role
                {
                    Rol="Delegado",
                    Usuario="User2"
                }

            };


        }




    }
}
