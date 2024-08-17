using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
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

                // Logos de la boleta
                string logoPath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/LOGO_SGB.png");
                string logoPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/LOGO_UT.jpg");

                ImageData imageData1 = ImageDataFactory.Create(logoPath1);
                Image logo1 = new Image(imageData1).ScaleAbsolute(116.7f, 76.7f).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);

                ImageData imageData2 = ImageDataFactory.Create(logoPath2);
                Image logo2 = new Image(imageData2).ScaleAbsolute(76.7f, 76.7f).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

                // Tabla para los logos
                var logoTable = new Table(2).UseAllAvailableWidth();
                logoTable.AddCell(new Cell().Add(logo1).SetBorder(Border.NO_BORDER));
                logoTable.AddCell(new Cell().Add(logo2).SetBorder(Border.NO_BORDER));

                document.Add(logoTable);

                // Agrega el Encabezado
                var header = new Paragraph("UNIVERSIDAD TECNOLOGICA DE LA REGION NORTE DEL ESTADO DE GUERRERO")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(18);
                document.Add(header);

                var subheader = new Paragraph("BOLETA DE PRESTAMO DE LIBROS BIBLIOTECA UT")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(14);
                document.Add(subheader);

                var subsubheader = new Paragraph("La imaginación te llevará a cualquier parte")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(12);
                document.Add(subsubheader);

                // Agrega un espacio en blanco
                document.Add(new Paragraph(" "));

                // Tabla de informacion de la boleta
                var table = new Table(2).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                // Cambiar el color de la tabla
                table.SetBackgroundColor(ColorConstants.LIGHT_GRAY);

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

                // Parrafo final
                var footer = new Paragraph("El libro que estoy solicitando a la biblioteca de esta institución se encuentran en buen estado, las fechas de préstamo y de entrega se encuentran indicadas en la parte superior, me comprometo a cumplirlas y evitar las sanciones correspondientes. En caso de maltrato o extravío del libro aquí mencionado tendré que cubrir la totalidad del costo para que sea repuesto. Costo por día de retraso $10.00 pesos.")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED)
                    .SetFontSize(10);
                document.Add(footer);

                // Agrega un espacio en blanco para agregar la firma
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));
                var firma = new Paragraph("FIRMA DEL ALUMNO")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(12);
                document.Add(firma);

                // Agrega el nombre del usuario debajo de la firma
                var nombreUsuario = new Paragraph(prestamo.IdPersonaNavigation?.Nombre ?? "N/A")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(12);
                document.Add(nombreUsuario);

                document.Close();
                var byteInfo = ms.ToArray();

                return File(byteInfo, "application/pdf", "Prestamo.pdf");
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
