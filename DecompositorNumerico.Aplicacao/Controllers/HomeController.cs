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

     
        public IActionResult Calcular(int valor)
        {
            var client = new RestClient("https://localhost:44312/");
            var request = new RestRequest("CalcularDivisor/Calcular/");
            request.AddJsonBody(new { valor = JsonConvert.SerializeObject(valor) });
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request);
            var content = response.Content;
            var retornos = JsonConvert.DeserializeObject<Divisor>(content);


            return View();
        }
    }
}
