using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaBiblioteca.Models;
using PracticaBiblioteca.ViewModels;
using System;
using System.Collections.Generic;
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
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.NombreUsuario),
                        new Claim("IdUsuario", user.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, user.IdRol == 6 ? "Admin" : "Usuario") // Usar 6 para Admin y 7 para Usuario
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redirigir según el rol
                    if (user.IdRol == 6) // Admin
                    {
                        return RedirectToAction("AdminDashboard", "Home");
                    }
                    else if (user.IdRol == 7) // Usuario
                    {
                        return RedirectToAction("UserDashboard", "Home");
                    }
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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
