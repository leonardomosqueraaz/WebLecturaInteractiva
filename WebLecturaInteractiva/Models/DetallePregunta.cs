using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetallePregunta
    {
        [Key]
        public Guid Id_DPregunta { get; set; }
        public Guid Id_TipoPregunta { get; set; }
        public Guid Id_Preguntas { get; set; }
        public Guid Id_NivelPregunta { get; set; }

        public virtual TipoPreguntas TipoPreguntas { get; set; }
        public virtual Preguntas Preguntas { get; set; }
        public virtual NivelPregunta NivelPregunta { get; set; }
        //public virtual ICollection<DetallePreguntaLectura> DetallePreguntaLecturas { get; set; }
        public virtual ICollection<DetallePreguntaRespuesta> DetallePreguntaRespuestas { get; set; }
    }
}