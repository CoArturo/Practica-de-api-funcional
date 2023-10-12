using Microsoft.AspNetCore.Mvc;
using Practica_de_api.Models;

namespace Practica_de_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SumaController : ControllerBase
    {
        private readonly Logger logger;

        public SumaController()
        {
            logger = Logger.Instance;
        }

        [HttpPost("Sumadora")]
        public ActionResult<int> RealizarSuma([FromBody] Models.SumadoraEstructura request)
        {
            int resultado = request.Numero1 + request.Numero2;
            logger.Log($"Suma: {request.Numero1} + {request.Numero2} = {resultado}");

            return Ok(resultado);
        }
    }
}
