using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetallesGrado
    {
        [Key]
        public Guid Id_DGrado { get; set; }
        public Guid Id_Grado { get; set; }
        public Guid Id_TipoGrado { get; set; }

        public virtual Grados Grados { get; set; }
        public virtual TipoGrado TipoGrado { get; set; }
    }
}