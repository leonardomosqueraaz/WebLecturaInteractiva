using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class Preguntas
    {
        [Key]
        public Guid Id_Preguntas { get; set; }
        public string Nombre_Pregunta { get; set; }
        public string Descripcion_Pregunta { get; set; }
        public bool Estado_Pregunta { get; set; }
        public DateTime FechaCreacion_Pregunta { get; set; }

        public virtual ICollection<DetallePregunta> DetallePreguntas { get; set; }
    }
}