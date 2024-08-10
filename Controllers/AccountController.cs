<<<<<<< HEAD

using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

=======
﻿using Microsoft.AspNetCore.Authentication;
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaBiblioteca.Models;
using PracticaBiblioteca.ViewModels;
<<<<<<< HEAD


using System;

=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                    .Include(u => u.Rol) // Asumiendo que tienes una propiedad de navegación para Rol en Usuario
                    .SingleOrDefaultAsync(u => u.NombreUsuario == model.NombreUsuario && u.Contrasena == model.Contrasena);

                if (user != null)
                {
<<<<<<< HEAD

=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
                    // Crear los claims del usuario
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.NombreUsuario),
                        new Claim(ClaimTypes.Role, user.Rol.Descripcion) // Suponiendo que Descripcion contiene el nombre del rol
<<<<<<< HEAD

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.NombreUsuario),
                        new Claim("IdUsuario", user.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, user.IdRol == 6 ? "Admin" : "Usuario") // Usar 6 para Admin y 7 para Usuario

=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

<<<<<<< HEAD

=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
                    // Autenticación del usuario
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redirigir basado en el rol del usuario
                    if (user.Rol.Descripcion == "Admin")
                    {
                        return RedirectToAction("Index", "Home"); // O cualquier otra acción para Admin
                    }
                    else if (user.Rol.Descripcion == "Usuario")
                    {
                        return RedirectToAction("Index", "Home"); // O cualquier otra acción para Usuario
<<<<<<< HEAD

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redirigir según el rol
                    if (user.IdRol == 6) // Admin
                    {
                        return RedirectToAction("AdminDashboard", "Home");
                    }
                    else if (user.IdRol == 7) // Usuario
                    {
                        return RedirectToAction("UserDashboard", "Home");
=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
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
            var roles = _context.Roles.ToList();

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

                // Iniciar sesión automáticamente al registrar
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                    new Claim(ClaimTypes.Role, (await _context.Roles.FindAsync(model.IdRol)).Descripcion)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

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