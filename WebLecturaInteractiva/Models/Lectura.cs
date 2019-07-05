using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebLecturaInteractiva.Models
{
    public class Lectura
    {
        public Lectura()
        {
        }
        [Key]
        public Guid Id_Lectura { get; set; }
        public string TituloLectura { get; set; }
        public string DescripcionLectura { get; set; }
        public byte[] ImagenLectura { get; set; }

        public virtual ICollection<SubCategoriaLectura> SubCategorias { get; set; }
        public virtual ICollection<DetalleModoLecturaXLectura> DetalleModoLecturaXLecturas { get; set; }
        public virtual ICollection<DetallePreguntaLectura> DetallePreguntaLectura { get; set; }

    }
}
