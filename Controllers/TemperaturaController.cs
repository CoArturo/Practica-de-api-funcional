using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practica_de_api.Models;

namespace Practica_de_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperaturaController : ControllerBase
    {
        private readonly Logger logger;
        private readonly Fachada.ITemperaturaFachada fachada;

        public TemperaturaController(Fachada.ITemperaturaFachada fachada)
        {
            this.fachada = fachada;
            logger = Logger.Instance;
        }

        [HttpGet("fahrenheit-a-celsius")]
        public ActionResult<Models.TemperaturaEstructura> ConvertirFahrenheitACelsius(double fahrenheit)
        {
            var resultado = fachada.ConvertirFahrenheitACelsius(fahrenheit);
            Logger.Instance.Log($"Conversión de Fahrenheit a Celsius: {fahrenheit} = {resultado.Celsius}");
            return Ok(resultado);
        }
    }
}
