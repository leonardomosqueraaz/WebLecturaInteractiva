using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetallePreguntaRespuesta
    {
        [Key]
        public Guid Id_DPR { get; set; }
        public Guid Id_Respuesta { get; set; }
        public Guid Id_DPregunta { get; set; }

        public virtual Respuestas Respuestas { get; set; }
        public virtual DetallePregunta DetallePregunta { get; set; }
    }
}