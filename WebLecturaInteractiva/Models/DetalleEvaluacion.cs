using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetalleEvaluacion
    {
        [Key]
        public Guid Id_DEvalucion { get; set; }
        public Guid Id_Evaluacion { get; set; }
        public Guid Id_DCursos { get; set; }

        public virtual Evaluacion Evaluacion { get; set; }
        public virtual DetalleCursos DetalleCursos { get; set; }
    }
}