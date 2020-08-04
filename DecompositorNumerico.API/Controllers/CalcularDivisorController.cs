using DecompositorNumerico.Servico;
using Microsoft.AspNetCore.Mvc;

namespace DecompositorNumerico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcularDivisorController : ControllerBase
    {
        [HttpGet]
        [ActionName("Calcular")]
        public ActionResult Calcular(int valor)
        {
            Divisores divisores = new Divisores();
            return new ObjectResult(divisores.Calcular(valor));
        }
    }
}