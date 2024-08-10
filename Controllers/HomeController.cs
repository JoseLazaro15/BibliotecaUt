using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
=======
using PracticaBiblioteca.Models;
>>>>>>> 4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8

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

        // Vista para el panel de usuario
        public IActionResult UserDashboard()
        {
            return View();
        }

        // Vista para el panel de administrador
        public IActionResult AdminDashboard()
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