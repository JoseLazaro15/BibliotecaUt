using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaBiblioteca.Models
{
    public class AsignacionRol
    {
        [Key]
        public int IdAsignacionRol { get; set; }

        [ForeignKey("Persona")]
        public int IdPersona { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        public Persona Persona { get; set; }

        public Rol Rol { get; set; }
    }
}