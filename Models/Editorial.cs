using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.Models;

[Table("EDITORIAL")]
public partial class Editorial
{
    [Key]
    public int IdEditorial { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [InverseProperty("IdEditorialNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
