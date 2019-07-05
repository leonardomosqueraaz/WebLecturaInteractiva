using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class LecturaEscrita
    {
        [Key]
        public Guid Id_LecturaEscrita { get; set; }
        public string Nombre_LecturaEscrita { get; set; }
        public string Descripcion_LecturaEscrita { get; set; }
        public byte[] Imagen_LecturaEscrita { get; set; }
        public string URL_LecturaEscrita { get; set; }
        public bool Estado_LecturaEscrita { get; set; }
        public Guid Id_SubCategoria { get; set; }

        //public virtual SubCategoriaLectura SubCategoriaLectura { get; set; }
        //public virtual ICollection<DetallePreguntaLectura> DetallePreguntaLecturas { get; set; }
    }
}