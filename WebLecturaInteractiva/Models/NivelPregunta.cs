using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class NivelPregunta
    {
        [Key]
        public Guid Id_NivelPregunta { get; set; }
        public string Nombre_NivelPregunta { get; set; }
        public string Descripcion_NivelPregunta { get; set; }
        public bool Estado_NivelPregunta { get; set; }

        public virtual ICollection<DetallePregunta> DetallePreguntas { get; set; }
    }
}