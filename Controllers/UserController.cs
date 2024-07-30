using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PracticaBiblioteca.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class UserController : Controller
    {
        public IActionResult UserDashboard()
        {
            return View();
        }

        // Otros métodos y acciones para el Usuario
    }
}
