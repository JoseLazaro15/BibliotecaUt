using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaBiblioteca.Models;

namespace PracticaBiblioteca.Controllers
{
    public class AsignacionRolController : Controller
    {
        private readonly BibliotecaContext _context;

        public AsignacionRolController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: AsignacionRol
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.AsignacionRoles.Include(a => a.Persona).Include(a => a.Rol);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: AsignacionRol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionRol = await _context.AsignacionRoles
                .Include(a => a.Persona)
                .Include(a => a.Rol)
                .FirstOrDefaultAsync(m => m.IdAsignacionRol == id);
            if (asignacionRol == null)
            {
                return NotFound();
            }

            return View(asignacionRol);
        }

        // GET: AsignacionRol/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: AsignacionRol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacionRol,IdPersona,IdRol,FechaAsignacion")] AsignacionRol asignacionRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", asignacionRol.IdPersona);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", asignacionRol.IdRol);
            return View(asignacionRol);
        }

        // GET: AsignacionRol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionRol = await _context.AsignacionRoles.FindAsync(id);
            if (asignacionRol == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", asignacionRol.IdPersona);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", asignacionRol.IdRol);
            return View(asignacionRol);
        }

        // POST: AsignacionRol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacionRol,IdPersona,IdRol,FechaAsignacion")] AsignacionRol asignacionRol)
        {
            if (id != asignacionRol.IdAsignacionRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionRolExists(asignacionRol.IdAsignacionRol))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", asignacionRol.IdPersona);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", asignacionRol.IdRol);
            return View(asignacionRol);
        }

        // GET: AsignacionRol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionRol = await _context.AsignacionRoles
                .Include(a => a.Persona)
                .Include(a => a.Rol)
                .FirstOrDefaultAsync(m => m.IdAsignacionRol == id);
            if (asignacionRol == null)
            {
                return NotFound();
            }

            return View(asignacionRol);
        }

        // POST: AsignacionRol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacionRol = await _context.AsignacionRoles.FindAsync(id);
            if (asignacionRol != null)
            {
                _context.AsignacionRoles.Remove(asignacionRol);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionRolExists(int id)
        {
            return _context.AsignacionRoles.Any(e => e.IdAsignacionRol == id);
        }
    }
}
