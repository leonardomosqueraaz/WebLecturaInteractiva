using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class Evaluacion
    {
        [Key]
        public Guid Id_Evaluacion { get; set; }
        public Guid Id_Personas { get; set; }
        public decimal Nota_Evaluacion { get; set; }
        public DateTime FechaInicio_Evaluacion { get; set; }
        public DateTime FechaFin_Evaluacion { get; set; }
        public DateTime FechaCreacion_Evaluacion { get; set; }

        public virtual Personas Personas { get; set; }
        public virtual ICollection<DetalleEvaluacion> DetalleEvalucions { get; set; }
    }
}
