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
    public class PrestamoesController : Controller
    {
        private readonly BibliotecaContext _context;

        public PrestamoesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Prestamos.Include(p => p.IdEstadoPrestamoNavigation).Include(p => p.IdLibroNavigation).Include(p => p.IdPersonaNavigation);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.IdEstadoPrestamoNavigation)
                .Include(p => p.IdLibroNavigation)
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "Descripcion");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo");
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "Nombre");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,IdEstadoPrestamo,IdPersona,IdLibro,FechaDevolucion,FechaConfirmacionDevolucion,EstadoEntregado,EstadoRecibido,Estado,FechaCreacion")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "Descripcion", prestamo.IdEstadoPrestamo);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", prestamo.IdLibro);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "Nombre", prestamo.IdPersona);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "Descripcion", prestamo.IdEstadoPrestamo);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", prestamo.IdLibro);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "Nombre", prestamo.IdPersona);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,IdEstadoPrestamo,IdPersona,IdLibro,FechaDevolucion,FechaConfirmacionDevolucion,EstadoEntregado,EstadoRecibido,Estado,FechaCreacion")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
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
            ViewData["IdEstadoPrestamo"] = new SelectList(_context.EstadoPrestamos, "IdEstadoPrestamo", "Descripcion", prestamo.IdEstadoPrestamo);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", prestamo.IdLibro);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "Nombre", prestamo.IdPersona);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.IdEstadoPrestamoNavigation)
                .Include(p => p.IdLibroNavigation)
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.IdPrestamo == id);
        }
    }
}
