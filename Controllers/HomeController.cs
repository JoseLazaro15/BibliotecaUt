using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaBiblioteca.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PracticaBiblioteca.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acción para la vista de bienvenida
        [AllowAnonymous]
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Index()
        {
            var userRole = User.IsInRole("Admin") ? "Admin" :
                           User.IsInRole("Usuario") ? "Usuario" : "Unknown";
            ViewData["UserRole"] = userRole;

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
    }
}