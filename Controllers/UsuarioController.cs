using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Cors;

namespace Practica_de_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private string filePath = "C:/Users/abela/source/repos/Programacion 2/Practica-de-api-master/Practica-de-api-master/bin/Debug/net6.0/usuario.json";

        private ControlUsuario controlUsuario;

        public UsuarioController()
        {
            controlUsuario = new ControlUsuario(filePath);
        }

        [HttpPost]
        [Route("PostUser")]
        public IActionResult Post(Models.UsuarioEstructura usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El objeto de usuario es nulo.");
            }

            List<Models.UsuarioEstructura> usuarios = controlUsuario.GetAllUsuarios();

            if (usuarios == null)
            {
                usuarios = new List<Models.UsuarioEstructura>();
            }
            else if (usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario || u.Id == usuario.Id))
            {
                return BadRequest("El usuario ya existe.");
            }

            usuarios.Add(usuario);

            string newJson = JsonConvert.SerializeObject(usuarios);

            try
            {
                System.IO.File.WriteAllText(filePath, newJson);
                return Ok("El usuario se ha agregado correctamente al archivo JSON.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al escribir en el archivo JSON: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Models.UsuarioEstructura credenciales)
        {
            List<Models.UsuarioEstructura> usuarios;
            try
            {
                string jsonText = System.IO.File.ReadAllText(filePath);
                usuarios = JsonConvert.DeserializeObject<List<Models.UsuarioEstructura>>(jsonText);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al leer el archivo JSON de usuarios");
            }

            var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == credenciales.NombreUsuario);

            if (usuario == null)
            {
                return Unauthorized("Nombre de usuario no encontrado");
            }

            if (usuario.Contraseña != credenciales.Contraseña)
            {
                return Unauthorized("Contraseña incorrecta");
            }
      
            return Ok("Autenticación exitosa");
            

        }
    }
}
