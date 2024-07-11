using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.Models;

[Table("PRESTAMO")]
public partial class Prestamo
{
    [Key]
    public int IdPrestamo { get; set; }

    public int? IdEstadoPrestamo { get; set; }

    public int? IdPersona { get; set; }

    public int? IdLibro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaDevolucion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaConfirmacionDevolucion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EstadoEntregado { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EstadoRecibido { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [ForeignKey("IdEstadoPrestamo")]
    [InverseProperty("Prestamos")]
    public virtual EstadoPrestamo? IdEstadoPrestamoNavigation { get; set; }

    [ForeignKey("IdLibro")]
    [InverseProperty("Prestamos")]
    public virtual Libro? IdLibroNavigation { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("Prestamos")]
    public virtual Persona? IdPersonaNavigation { get; set; }
}
