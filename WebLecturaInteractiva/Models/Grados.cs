using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class Grados
    {
        [Key]
        public Guid Id_Grado { get; set; }
        public Guid Numero_Grado { get; set; }
        public string Nombre_Grado { get; set; }
        public bool Estado_Grado { get; set; }

        public virtual ICollection<DetallesGrado> DetallesGrados { get; set; }
    }
}