using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetalleEstudianteGrado
    {
        [Key]
        public Guid Id_DEstudianteGrado { get; set; }
        public Guid Id_Personas { get; set; }
        public Guid Id_DGrado { get; set; }

        public virtual Personas Personas { get; set; }
        public virtual DetallesGrado DetallesGrado { get; set; }
    }
}