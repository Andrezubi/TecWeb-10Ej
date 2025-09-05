
using System.ComponentModel.DataAnnotations;
namespace Tarea10Ej.Models
{
    public class Usuario
    {
        [Required(ErrorMessage ="Nombre es requerido")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "E-mail es requerido")]
        [EmailAddress(ErrorMessage = "E-mail no valido")]
        public string Correo { get; set; }
    }
}
