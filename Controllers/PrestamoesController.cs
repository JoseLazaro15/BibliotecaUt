using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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

        // Método para generar el PDF
        public async Task<IActionResult> ImprimirSimple()
        {
            var prestamos = await _context.Prestamos.Include(p => p.IdEstadoPrestamoNavigation)
                                                    .Include(p => p.IdLibroNavigation)
                                                    .Include(p => p.IdPersonaNavigation)
                                                    .ToListAsync();

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
                foreach (var prestamo in prestamos)
                {
                    var table = new Table(2);
                    table.AddCell(new Cell().Add(new Paragraph("FECHA")));
                    table.AddCell(new Cell().Add(new Paragraph(DateTime.Now.ToString("dd/MM/yyyy")))); // Fecha actual

                    table.AddCell(new Cell().Add(new Paragraph("NOMBRE")));
                    table.AddCell(new Cell().Add(new Paragraph(prestamo.IdPersonaNavigation.Nombre)));

                    table.AddCell(new Cell().Add(new Paragraph("TELEFONO")));
                    table.AddCell(new Cell().Add(new Paragraph("N/A"))); // Puedes agregar el campo de teléfono si está disponible

                    table.AddCell(new Cell().Add(new Paragraph("CLAVE")));
                    table.AddCell(new Cell().Add(new Paragraph("N/A"))); // Puedes agregar el campo de clave si está disponible

                    table.AddCell(new Cell().Add(new Paragraph("CUATRIMESTRE")));
                    table.AddCell(new Cell().Add(new Paragraph("N/A"))); // Puedes agregar el campo de cuatrimestre si está disponible

                    table.AddCell(new Cell().Add(new Paragraph("GRUPO")));
                    table.AddCell(new Cell().Add(new Paragraph("N/A"))); // Puedes agregar el campo de grupo si está disponible

                    table.AddCell(new Cell().Add(new Paragraph("DIAS")));
                    table.AddCell(new Cell().Add(new Paragraph("N/A"))); // Puedes agregar el campo de días si está disponible

                    table.AddCell(new Cell().Add(new Paragraph("TITULO")));
                    table.AddCell(new Cell().Add(new Paragraph(prestamo.IdLibroNavigation.Titulo)));

                    table.AddCell(new Cell().Add(new Paragraph("CODIGO")));
                    table.AddCell(new Cell().Add(new Paragraph("N/A"))); // Puedes agregar el campo de código si está disponible


                    document.Add(table);

                    // Agrega un espacio entre registros
                    document.Add(new Paragraph(" "));
                }

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

                return File(byteInfo, "application/pdf", "Prestamos.pdf");
            }
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
