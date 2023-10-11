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
        private string filePath = "C:/Users/abela/OneDrive/Escritorio/Practica-de-api-master/Practica-de-api-master/bin/Debug/net6.0/usuario.json";

        private ControlUsuario controlUsuario;

        public UsuarioController()
        {
            controlUsuario = new ControlUsuario(filePath);
        }

        //[HttpPost]
        //[Route("Login")]

        //public IActionResult Login(string nombreusuario, string contraseña)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(nombreusuario) || string.IsNullOrEmpty(contraseña))
        //        {
        //            return BadRequest("Nombre de usuario y contraseña son requeridos.");
        //        }

        //        List<Models.UsuarioEstructura> usuarios = controlUsuario.CargarUsuarios();

        //        if (usuarios == null)
        //        {
        //            return BadRequest("Error al cargar usuarios.");
        //        }

        //        if (AuthenticateUser(usuarios, nombreusuario, contraseña))
        //        {
        //            return Ok("Inicio de sesión exitoso");
        //        }

        //        return BadRequest("Nombre de usuario o contraseña incorrectos");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error interno del servidor: " + ex.Message);
        //    }
        //}

        //private bool AuthenticateUser(List<Models.UsuarioEstructura> usuarios, string nombreusuario, string contrasena)
        //{
        //    var user = usuarios.FirstOrDefault(u => u.NombreUsuario == nombreusuario);

        //    if (user != null)
        //    {
        //        if (user.Contraseña == contrasena)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}


        //public IActionResult Login(string nombreusuario, string contraseña)
        //{
        //    try
        //    {
        //        List<Models.UsuarioEstructura> usuarios = controlUsuario.CargarUsuarios();

        //        if (AuthenticateUser(usuarios, nombreusuario, contraseña))
        //        {
        //            return Ok("Inicio de sesión exitoso");
        //        }

        //        return BadRequest("Nombre de usuario o contraseña incorrectos");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error interno del servidor: " + ex.Message);
        //    }
        //}

        //private bool AuthenticateUser(List<Models.UsuarioEstructura> usuarios, string nombreusuario, string contrasena)
        //{
        //    var user = usuarios.FirstOrDefault(u => u.NombreUsuario == nombreusuario);

        //    if (user != null && user.Contraseña == contrasena)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

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
                // Handle the error and return an appropriate response.
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

            // Buscar el usuario en la lista
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



        //[HttpGet]
        //[Route("GetUser/{id}/{nombre}/{apellido}/{edad}/{nombreusuario}/{contraseña}")]
        //public string Get(string id, string nombre, string apellido, string edad, string nombreusuario, string contraseña)
        //{
        //    Models.UsuarioEstructura usuario = new Models.UsuarioEstructura();
        //    usuario.Id = id;
        //    usuario.Nombre = nombre;
        //    usuario.Apellido = apellido;
        //    usuario.Edad = edad;
        //    usuario.NombreUsuario = nombreusuario;
        //    usuario.Contraseña = contraseña;

        //    string result = JsonConvert.SerializeObject(usuario);
        //    Post(usuario);
        //    return result;
        //}

        //[HttpPost]
        //[Route("PostUser")]
        //public string Post(Models.UsuarioEstructura usuario)
        //{
        //    controlUsuario.AddUsuario(usuario);
        //    return "El usuario se ha agregado correctamente al archivo JSON.";
        //}
    }
}
