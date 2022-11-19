using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage ="Debe ingresar un codigo")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una clave")]
        public string Clave { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Rol")]
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
