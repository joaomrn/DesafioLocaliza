using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DecompositorNumerico.Aplicacao.Models;
using RestSharp;
using Newtonsoft.Json;
using DecompositorNumerico.Dominio;

namespace DecompositorNumerico.Aplicacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Divisor = "";
            ViewBag.DivisorPrimo = "";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Calcular(int valor)
        {
            if (valor < 2)
            {
                TempData["ValorInvalido"] = $@" Numero invalido!";
                return View("Index");
            }

            var client = new RestClient("https://localhost:44312/api/");
            var request = new RestRequest("CalcularDivisor/Calcular");
            request.AddParameter("valor", valor);
            request.RequestFormat = DataFormat.Json;
            var response = client.Post(request);
            var content = response.Content;
            var retorno = JsonConvert.DeserializeObject<Divisor>(content);


            string divisores = string.Empty;
            foreach (var item in retorno.Divisores)
            {
                divisores += item.ToString() + ", ";
            }

            divisores = divisores.Remove(divisores.Length - 1);
            divisores = divisores.Remove(divisores.Length - 1);

            string divisoresPrimos = string.Empty;
            foreach (var item in retorno.DivisoresPrimos)
            {
                divisoresPrimos += item.ToString() + ", ";
            }
            divisoresPrimos = divisoresPrimos.Remove(divisoresPrimos.Length - 1);
            divisoresPrimos = divisoresPrimos.Remove(divisoresPrimos.Length - 1);

            ViewBag.Divisor = divisores;
            ViewBag.DivisorPrimo = divisoresPrimos;
            return View("Index");
        }
    }
}
