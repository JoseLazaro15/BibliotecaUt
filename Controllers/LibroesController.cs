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
    public class LibroesController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibroesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Libros.Include(l => l.IdAutorNavigation).Include(l => l.IdCategoriaNavigation).Include(l => l.IdEditorialNavigation);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdCategoriaNavigation)
                .Include(l => l.IdEditorialNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "Descripcion");
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "Descripcion");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,RutaPortada,NombrePortada,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaCreacion")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", libro.IdAutor);
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", libro.IdCategoria);
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "IdEditorial", libro.IdEditorial);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "Descripcion", libro.IdAutor);
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion", libro.IdCategoria);
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "Descripcion", libro.IdEditorial);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,RutaPortada,NombrePortada,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaCreacion")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "Descripcion", libro.IdAutor);
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion", libro.IdCategoria);
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "Descripcion", libro.IdEditorial);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdCategoriaNavigation)
                .Include(l => l.IdEditorialNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
