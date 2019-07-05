using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    /// <summary>
    /// Para saber que tipo de pregunta es por ejemplo si es 
    /// estilo Icfes o pregunta abierta etc.
    /// </summary>
    public class TipoPreguntas
    {
        [Key]
        public Guid Id_TipoPregunta { get; set; }
        public string Nombre_TipoPregunta { get; set; }
        public string Descripcion_TipoPregunta { get; set; }
        public bool SeleccionMultiple { get; set; }
        public bool Estado_TipoPregunta { get; set; }

        public virtual ICollection<DetallePregunta> DetallePreguntas { get; set; }
    }
}