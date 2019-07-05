using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLecturaInteractiva.Models
{
    public class ActividadPreguntas
    {
        [Key]
        public Guid Id_ActPreguntas { get; set; }

        [StringLength(50,MinimumLength = 10,ErrorMessage = "Maximo {1} y Menor a {2}")]
        public string Nombre_ActPreguntas { get; set; }

        public string Descripcion_ActPreguntas { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor ingrese una Fecha")]
        public DateTime FechaInicio_ActPreguntas { get; set; }

        [Display(Name = "Fecha final")]
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor ingrese una Fecha")]
        public DateTime FechaFinal_ActPreguntas { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DataType(DataType.Time, ErrorMessage = "Por favor ingrese una hora")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tiempo Limited")]
        public int TiempoLimite_ActPreguntas { get; set; }

        public bool Estado_ActPreguntas { get; set; }



        public virtual ICollection<DetalleActividadPreguntas> DetalleActividadPreguntas { get; set; }
    }
}
