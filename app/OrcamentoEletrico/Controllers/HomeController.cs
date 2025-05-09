using Microsoft.AspNetCore.Mvc;
using OrcamentoEletricoApp.Models.ViewErrors;
using System.Diagnostics;

namespace OrcamentoEletricoApp.Controllers
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

        public IActionResult Pessoa()
        {
            return View("Pessoa");
        }

        public IActionResult Orcamento()
        {
            return View("Orcamento");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
