using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetallePreguntaLectura
    {
        [Key]
        public Guid Id_DPL { get; set; }
        public Guid Id_DCursos { get; set; }
        public Guid Id_DActPreguntas { get; set; }
        public Guid Id_Lectura { get; set; }

        public virtual DetalleCursos DetalleCursos { get; set; }
        public virtual DetalleActividadPreguntas DetalleActividadPreguntas { get; set; }
        public virtual Lectura Lectura { get; set; }
        //public virtual LecturaVideo LecturaVideo { get; set; }

    }
}