using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLecturaInteractiva.Models
{
    public class ModoLectura
    {
        [Key]
        public Guid Id_ModoLectura { get; set; }
        public string NombreModoLectura { get; set; }
        public string DescripcionModoLectura { get; set; }
        public byte[] ImagenModoLectura { get; set; }
        public string UrlSourse { get; set; }

        public virtual ICollection<DetalleModoLecturaXLectura> DetalleModoLecturaXLecturas { get; set; }
    }
}