using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class Cursos
    {
        [Key]
        public Guid Id_Cursos { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el {0}")]
        [Display(Name = "Nombre")]
        public string Nombre_Cursos { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [Display(Name = "descripción")]
        public string Descripcion_Cursos { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor ingrese una Fecha")]
        public DateTime? FechaInicio_Cursos { get; set; }

        [Display(Name = "Fecha final")]
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor ingrese una Fecha")]
        public DateTime FechaFin_Cursos { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DataType(DataType.Time, ErrorMessage = "Por favor ingrese una hora")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tiempo Limited")]
        public DateTime TiempoLimite { get; set; }

        [Display(Name = "Hora de inicio")]
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DataType(DataType.Time, ErrorMessage = "Por favor ingrese una hora")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicio_Cursos { get; set; }

        [Display(Name = "Hora final")]
        [Required(ErrorMessage = "Por favor ingrese la {0}")]
        [DataType(DataType.Time, ErrorMessage = "Por favor ingrese una hora")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime HoraFin_Cursos { get; set; }

        public virtual ICollection<DetalleCursos> DetalleCursos { get; set; }


        //public Cursos()
        //{
        //    if (this.FechaFin_Cursos == DateTime.MinValue || this.FechaFin_Cursos == DateTime.MaxValue)
        //    {
        //        throw new Exception("Erro en la fecha");
        //    }
        //}
    }
}