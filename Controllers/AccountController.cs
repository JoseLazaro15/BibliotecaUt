using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaBiblioteca.Models;
using PracticaBiblioteca.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaBiblioteca.Controllers
{
    public class AccountController : Controller
    {
        private readonly BibliotecaContext _context;

        public AccountController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Usuarios
                    .SingleOrDefaultAsync(u => u.NombreUsuario == model.NombreUsuario && u.Contrasena == model.Contrasena);

                if (user != null)
                {
                    // Aquí puedes realizar la autenticación del usuario (por ejemplo, establecer cookies de autenticación).
                    // Por simplicidad, redirigimos al usuario a la página de inicio.
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            // Filtrar la lista de roles para incluir solo el rol "Usuario"
            var roles = _context.Roles.Where(r => r.Descripcion == "Usuario").ToList();

            // Crear un SelectList con los roles filtrados
            ViewBag.Roles = new SelectList(roles, "IdRol", "Descripcion");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    NombreUsuario = model.NombreUsuario,
                    Contrasena = model.Contrasena,
                    IdRol = model.IdRol,
                    FechaCreacion = DateTime.Now
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Aquí podrías realizar la autenticación del nuevo usuario si lo deseas.

                return RedirectToAction("Index", "Home");
            }

            // Recargar la lista de roles en caso de error de validación.
            ViewBag.Roles = new SelectList(_context.Roles, "IdRol", "Descripcion");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Aquí podrías realizar la lógica de cierre de sesión (por ejemplo, eliminar cookies de autenticación).
            return RedirectToAction("Index", "Home");
        }
    }
}