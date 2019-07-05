using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetalleCursos
    {
        [Key]
        public Guid Id_DCursos { get; set; }
        public Guid Id_Cursos { get; set; }
        public Guid Id_Grado { get; set; }
        public Guid Id_Personas { get; set; }

        public virtual Cursos Cursos { get; set; }
        public virtual Grados Grados { get; set; }
        public virtual Personas Personas { get; set; }
        public virtual ICollection<DetalleEvaluacion> DetalleEvalucion { get; set; }
    }
}