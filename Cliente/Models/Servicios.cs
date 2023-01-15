using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    public class Servicios
    {
        private  HttpClient _httpClient;

        public Servicios(string url = "http://localhost:57026")
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
        }

        public bool Login(string username, string password)
        {
           

            var parametros = new { Usuario = username, Password = password };
            var json = JsonConvert.SerializeObject(parametros);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync("/api/Autenticacion/Login", content).Result;

            return response.IsSuccessStatusCode;
        }
        public async Task<string> ObtenerRolesUsuario(string username)
        {
           

            var parametros = new { Usuario = username };
            var json = JsonConvert.SerializeObject(parametros);
            

            var response = await _httpClient.GetAsync("/api/Autenticacion/Rol?username=" + username);
            if (response.IsSuccessStatusCode)
            {
                var rol =  await response.Content.ReadAsStringAsync();
               
                return rol;
            }
            else
            {
                throw new Exception("Error al conectarse al API");
            }          
        }
        public async Task<List<Producto>> ProductosxRol(string rol)
        {
           

            var parametros = new { rol = rol };
            var json = JsonConvert.SerializeObject(parametros);
            

            var response = await _httpClient.GetAsync("/api/Productos/ProductosxRol?rol=" + rol);
            if (response.IsSuccessStatusCode)
            {
                var content =  await response.Content.ReadAsStringAsync();
               var productos = JsonConvert.DeserializeObject<List<Producto>>(content);
                return productos;
            }
            else
            {
                throw new Exception("Error al conectarse al API");
            }          
        }
    }
}
