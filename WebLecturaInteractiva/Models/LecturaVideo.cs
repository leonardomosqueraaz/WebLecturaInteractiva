using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class LecturaVideo
    {
        [Key]
        public Guid Id_LecturaVideo { get; set; }
        public string Nombre_LecturaVideo { get; set; }
        public string Descripcion_LecturaVideo { get; set; }
        public byte[] Imagen_LecturaVideo { get; set; }
        public string URL_LecturaVideo { get; set; }
        public bool Estado_LecturaVideo { get; set; }
        public Guid Id_SubCategoria { get; set; }

        //public virtual SubCategoriaLectura SubCategoriaLectura { get; set; }
        //public virtual ICollection<DetallePreguntaLectura> DetallePreguntaLecturas { get; set; }
        //public virtual ICollection<DetalleLecturaVideo> DetalleLecturaVideos { get; set; }
    }
}