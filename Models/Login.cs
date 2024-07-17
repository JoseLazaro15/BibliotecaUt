using PracticaBiblioteca.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PracticaBiblioteca.Models
{
    public class Login
    {
        [Key]
        public int IdLogin { get; set; }

        [ForeignKey("Persona")]
        public int IdPersona { get; set; }

        public DateTime FechaLogin { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Ip { get; set; }

        [StringLength(100)]
        public string Navegador { get; set; }

        public Persona Persona { get; set; }
    }
}