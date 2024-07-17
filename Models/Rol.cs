using System;
using System.ComponentModel.DataAnnotations;

namespace PracticaBiblioteca.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
