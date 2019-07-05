using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class TipoIdentificacion
    {
        [Key]
        public Guid Id_TipoIdentificacion { get; set; }

        [Display(Name = "Nombre")]
        public string Nombres_TipoIdentificacion { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion_TipoIdentificacion { get; set; }

        public virtual ICollection<Personas> Personas { get; set; }
    }
}