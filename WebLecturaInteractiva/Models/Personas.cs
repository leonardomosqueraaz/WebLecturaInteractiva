using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLecturaInteractiva.Models
{
    public class Personas
    {
        [Key]
        public Guid Id_Personas { get; set; }

        public Guid Id_TPersona { get; set; }

        [Display(Name = "Tipo documento")]
        [Required(ErrorMessage = "Ingrese {0}")]
        public Guid Id_TipoIdentificacion { get; set; }

        [Display(Name = "Numero documento")]
        [Required(ErrorMessage = "Ingrese {0}")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Maximo {1} y Menor a {2}")]
        [DataType(DataType.Text)]
        public string Identificacion_Personas { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Ingrese {0}")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Maximo {1} y Menor a {2}")]
        [DataType(DataType.Text)]
        public string Nombre_Personas { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Ingrese {0}")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Maximo {1} y Menor a {2}")]
        [DataType(DataType.Text)]
        public string Apellido_Personas { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Ingrese {0}")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Maximo {1} y Menor a {2}")]
        [DataType(DataType.EmailAddress)]
        public string Correo_Personas { get; set; }

        [Display(Name = "Estado")]
        public bool Estado_Personas { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion_Personas { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime FechaActualizacion_Personas { get; set; }

        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual TipoPersonas TipoPersonas { get; set; }
    }
}
