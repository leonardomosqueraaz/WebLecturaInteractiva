using System;
using System.ComponentModel.DataAnnotations;

namespace WebLecturaInteractiva.Models.Account
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }
        [Display(Name = "No. Identificacion")]
        [Required(ErrorMessage = "El No. Identificacion es requerido")]
        [RegularExpression("^[0-9\\\\-_@.]{0,}$", ErrorMessage = "Caracteres incorrectos en el No. identifiación")]
        public string Identificacion_Estudiante { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "¿Recordar Contraseña?")]
        public bool RememberMe { get; set; }
    }
}
