using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class Respuestas
    {
        [Key]
        public Guid Id_Respuesta { get; set; }
        public string Nombre_Respuesta { get; set; }
        public string Descripcion_Respuesta { get; set; }
        public bool Estado_Respuesta { get; set; }
        public bool Correcta_Respuesta { get; set; }
        public decimal Porcentaje_Respuesta { get; set; }

        public virtual ICollection<DetallePreguntaRespuesta> DetallePreguntaRespuestas { get; set; }
    }
}