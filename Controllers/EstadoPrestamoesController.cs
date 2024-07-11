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
    public class EstadoPrestamoesController : Controller
    {
        private readonly BibliotecaContext _context;

        public EstadoPrestamoesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: EstadoPrestamoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoPrestamos.ToListAsync());
        }

        // GET: EstadoPrestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPrestamo = await _context.EstadoPrestamos
                .FirstOrDefaultAsync(m => m.IdEstadoPrestamo == id);
            if (estadoPrestamo == null)
            {
                return NotFound();
            }

            return View(estadoPrestamo);
        }

        // GET: EstadoPrestamoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoPrestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoPrestamo,Descripcion,Estado,FechaCreacion")] EstadoPrestamo estadoPrestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoPrestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPrestamo);
        }

        // GET: EstadoPrestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPrestamo = await _context.EstadoPrestamos.FindAsync(id);
            if (estadoPrestamo == null)
            {
                return NotFound();
            }
            return View(estadoPrestamo);
        }

        // POST: EstadoPrestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoPrestamo,Descripcion,Estado,FechaCreacion")] EstadoPrestamo estadoPrestamo)
        {
            if (id != estadoPrestamo.IdEstadoPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoPrestamoExists(estadoPrestamo.IdEstadoPrestamo))
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
            return View(estadoPrestamo);
        }

        // GET: EstadoPrestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPrestamo = await _context.EstadoPrestamos
                .FirstOrDefaultAsync(m => m.IdEstadoPrestamo == id);
            if (estadoPrestamo == null)
            {
                return NotFound();
            }

            return View(estadoPrestamo);
        }

        // POST: EstadoPrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoPrestamo = await _context.EstadoPrestamos.FindAsync(id);
            if (estadoPrestamo != null)
            {
                _context.EstadoPrestamos.Remove(estadoPrestamo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoPrestamoExists(int id)
        {
            return _context.EstadoPrestamos.Any(e => e.IdEstadoPrestamo == id);
        }
    }
}
