using DecompositorNumerico.Servico;
using Microsoft.AspNetCore.Mvc;

namespace DecompositorNumerico.API.Controllers
{
    [ApiController]
    [Route("api/CalcularDivisor")]
    public class CalcularDivisorController : ControllerBase
    {
        [HttpPost]
        [Route("Calcular")]
        public IActionResult Calcular([FromForm]int valor)
        {
            Divisores divisores = new Divisores();
            return new ObjectResult(divisores.Calcular(valor));
        }
    }
}