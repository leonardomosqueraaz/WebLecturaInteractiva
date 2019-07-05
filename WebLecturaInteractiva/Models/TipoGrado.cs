using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class TipoGrado
    {
        [Key]
        public Guid Id_TipoGrado { get; set; }
        public int Numero_TipoGrado { get; set; }
        public string Nombre_TipoGrado { get; set; }
        public bool Estado_TipoGrado { get; set; }

        public virtual ICollection<DetallesGrado> DetallesGrados { get; set; }
    }
}