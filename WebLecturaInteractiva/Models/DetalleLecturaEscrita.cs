using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class DetalleLecturaEscrita
    {
        [Key]
        public Guid Id_DLE { get; set; }
        public Guid Id_ModoLectura { get; set; }
        public Guid Id_LecturaEscrita { get; set; }

    }
}