using System;
using System.ComponentModel.DataAnnotations;

namespace WebLecturaInteractiva.Models
{
    public class DetalleModoLecturaXLectura
    {
        public DetalleModoLecturaXLectura()
        {
        }
        [Key]
        public Guid Id_DetalleModoLecturaXLectura { get; set; }
        public Guid Id_Lectura { get; set; }
        public Guid Id_ModoLectura { get; set; }

        public virtual Lectura Lectura { get; set; }
        public virtual ModoLectura ModoLectura { get; set; }
    }
}
