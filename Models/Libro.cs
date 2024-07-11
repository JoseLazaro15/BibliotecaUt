using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.Models;

[Table("LIBRO")]
public partial class Libro
{
    [Key]
    public int IdLibro { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Titulo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RutaPortada { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NombrePortada { get; set; }

    public int? IdAutor { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdEditorial { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Ubicacion { get; set; }

    public int? Ejemplares { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [ForeignKey("IdAutor")]
    [InverseProperty("Libros")]
    public virtual Autor? IdAutorNavigation { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("Libros")]
    public virtual Categorium? IdCategoriaNavigation { get; set; }

    [ForeignKey("IdEditorial")]
    [InverseProperty("Libros")]
    public virtual Editorial? IdEditorialNavigation { get; set; }

    [InverseProperty("IdLibroNavigation")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
