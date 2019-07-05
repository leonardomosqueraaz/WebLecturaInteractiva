using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLecturaInteractiva.Models.Account
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
        }
        [EmailAddress(ErrorMessage = "Ingrese un Email valido")]
        [Display(Name = "Correo(Opcional)")]
        public string Email { get; set; }

        [NotMapped]
        public List<TipoIdentificacion> identificacions { get; set; }

        [Required(ErrorMessage = "El No. Identificacion es requerido")]
        [Display(Name = "No. Identificacion")]
        [RegularExpression("^[0-9\\\\-_@.]{0,}$", ErrorMessage = "Caracteres incorrectos en el No. identifiación")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "La Contraseña es requerida")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener minimo {2} y maximo {1} caracteres de logintud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}
