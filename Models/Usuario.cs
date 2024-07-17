using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticaBiblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con Rol
        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }

    }
}
