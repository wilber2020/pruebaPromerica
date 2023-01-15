using System.Collections.Generic;

namespace ApiProductos.Models
{
    public class Data
    {
        public List<Producto> _productos { get; }

        public Data()
        {
            _productos = new List<Producto>
            {
                new Producto
                {
                    Rol = "Principal",
                    producto = "Prod_A"
                },
               new Producto
                {
                    Rol = "Principal",
                    producto = "Prod_B"
                },
               new Producto
                {
                    Rol = "Principal",
                    producto = "Prod_C"
                },
               new Producto
                {
                    Rol = "Delegado",
                    producto = "Prod_A"
                },
               new Producto
                {
                    Rol = "Delegado",
                    producto = "Prod_C"
                },

            };
        }
    }
}
