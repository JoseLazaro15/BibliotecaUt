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

<<<<<<< HEAD
<<<<<<< HEAD

        public async Task<IActionResult> ImprimirSimple(int id)
        {
            var prestamo = await _context.Prestamos
                                         .Include(p => p.IdEstadoPrestamoNavigation)
                                         .Include(p => p.IdLibroNavigation)
                                         .Include(p => p.IdPersonaNavigation)
                                         .FirstOrDefaultAsync(p => p.IdPrestamo == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            using (var ms = new MemoryStream())
            {
                var writer = new PdfWriter(ms);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Agrega el encabezado
                var header = new Paragraph("UNIVERSIDAD TECNOLOGICA DE LA REGION NORTE DEL ESTADO DE GUERRERO")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(18);
                document.Add(header);

                var subheader = new Paragraph("PRESTAMO DE LIBROS BIBLIOTECA UT")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(14);
                document.Add(subheader);

                var subsubheader = new Paragraph("La imaginación te llevará a cualquier parte")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(12);
                document.Add(subsubheader);

                // Agrega un espacio
                document.Add(new Paragraph(" "));

                // Agrega la tabla de información
                var table = new Table(2);
                table.AddCell(new Cell().Add(new Paragraph("FECHA DE IMPRESION")));
                table.AddCell(new Cell().Add(new Paragraph(DateTime.Now.ToString("dd/MM/yyyy")))); // Fecha actual

                table.AddCell(new Cell().Add(new Paragraph("FECHA DE DEVOLUCION")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.FechaDevolucion?.ToString("dd/MM/yyyy") ?? "N/A")));

                table.AddCell(new Cell().Add(new Paragraph("FECHA DE CONFIRMACION DE DEVOLUCION")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.FechaConfirmacionDevolucion?.ToString("dd/MM/yyyy") ?? "N/A")));

                table.AddCell(new Cell().Add(new Paragraph("ESTADO ENTREGADO")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.EstadoEntregado?.ToString() ?? "N/A")));

                table.AddCell(new Cell().Add(new Paragraph("ESTADO RECIBIDO")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.EstadoRecibido?.ToString() ?? "N/A")));

                table.AddCell(new Cell().Add(new Paragraph("FECHA DE CREACION")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.FechaCreacion?.ToString("dd/MM/yyyy"))));

                table.AddCell(new Cell().Add(new Paragraph("DESCRIPCION DEL ESTADO")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.IdEstadoPrestamoNavigation?.Descripcion ?? "N/A")));

                table.AddCell(new Cell().Add(new Paragraph("TITULO DEL LIBRO")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.IdLibroNavigation?.Titulo ?? "N/A")));

                table.AddCell(new Cell().Add(new Paragraph("NOMBRE DEL USUARIO")));
                table.AddCell(new Cell().Add(new Paragraph(prestamo.IdPersonaNavigation?.Nombre ?? "N/A")));

                document.Add(table);

                // Agrega un espacio entre registros
                document.Add(new Paragraph(" "));

                // Agrega un párrafo final
                var footer = new Paragraph("El libro que estoy solicitando a la biblioteca de esta institución se encuentran en buen estado, las fechas de préstamo y de entrega se encuentran indicadas en la parte superior, me comprometo a cumplirlas y evitar las sanciones correspondientes. En caso de maltrato o extravío del libro aquí mencionado tendré que cubrir la totalidad del costo para que sea repuesto. Costo por día de retraso $3.00 pesos.")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED)
                    .SetFontSize(10);
                document.Add(footer);

                // Agrega un espacio y la firma
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));
                var firma = new Paragraph("FIRMA DEL ALUMNO")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(12);
                document.Add(firma);

                document.Close();
                var byteInfo = ms.ToArray();

                return File(byteInfo, "application/pdf", "Prestamo.pdf");
            }
        }









=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
=======
>>>>>>> parent of 55d5842 (Merge commit '4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8')
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
