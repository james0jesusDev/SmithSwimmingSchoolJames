using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmithSwimmingSchoolJames.Models;
using System.Diagnostics;

namespace SmithSwimmingSchoolJames.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {// Vista para el visinate no le damos rol de seguridad ya que primero tendra que estar registrado
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
