using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetalleLecturaVideo
    {
        [Key]
        public Guid Id_DLV { get; set; }
        public Guid Id_ModoLectura { get; set; }
        public Guid Id_LecturaVideo { get; set; }

        //public virtual ModoLectura ModoLectura { get; set; }
        //public virtual LecturaVideo LecturaVideo { get; set; }
    }
}