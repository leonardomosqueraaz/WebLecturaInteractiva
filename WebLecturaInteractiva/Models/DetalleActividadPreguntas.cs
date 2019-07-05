using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLecturaInteractiva.Models
{
    public class DetalleActividadPreguntas
    {
        [Key]
        public Guid Id_DActPreguntas { get; set; }
        public Guid Id_DPregunta { get; set; }
        public Guid Id_ActPreguntas { get; set; }

        public virtual DetallePregunta DetallePregunta { get; set; }
        public virtual ActividadPreguntas ActividadPreguntas { get; set; }
        public virtual ICollection<DetallePreguntaLectura> DetallePreguntaLectura { get; set; }

    }
}
