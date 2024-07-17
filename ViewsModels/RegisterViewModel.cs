using System.ComponentModel.DataAnnotations;

namespace PracticaBiblioteca.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Contrasena", ErrorMessage = "La contraseña y la confirmación de contraseña no coinciden.")]
        public string ConfirmarContrasena { get; set; }

        [Required(ErrorMessage = "El ID del rol es requerido.")]
        public int IdRol { get; set; }  // Agrega esta propiedad para el IdRol
    }
}
