using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.Models;

[Table("AUTOR")]
public partial class Autor
{
    [Key]
    public int IdAutor { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [InverseProperty("IdAutorNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
