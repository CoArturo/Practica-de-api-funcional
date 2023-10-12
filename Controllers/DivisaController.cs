using Microsoft.AspNetCore.Mvc;
using Practica_de_api.Fachada;
using Practica_de_api.Models;

namespace Practica_de_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisaController : ControllerBase
    {
        private readonly Fachada.IDivisaFachada divisaFachada;

        private readonly Logger logger;

        public DivisaController(IDivisaFachada divisaFachada)
        {
            logger = Logger.Instance;
            this.divisaFachada = divisaFachada;
        }

        [HttpGet("dolar-a-peso-dominicano")]
        public ActionResult<Models.DivisasEstructuras> ConvertirDolarAPesoDominicano(double dolar)
        {
            var resultado = divisaFachada.ConvertirDolarAPesoDominicano(dolar);
            logger.Log($"Conversión de Dólar a Peso Dominicano: {dolar} = {resultado.PesoDominicano}");
            return Ok(resultado);
        }
    }
}
