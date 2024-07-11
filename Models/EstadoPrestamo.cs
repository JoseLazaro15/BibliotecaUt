using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.Models;

[Table("ESTADO_PRESTAMO")]
public partial class EstadoPrestamo
{
    [Key]
    public int IdEstadoPrestamo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [InverseProperty("IdEstadoPrestamoNavigation")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
