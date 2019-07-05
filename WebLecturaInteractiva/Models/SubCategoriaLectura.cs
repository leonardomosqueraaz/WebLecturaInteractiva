using System;
using System.ComponentModel.DataAnnotations;

namespace WebLecturaInteractiva.Models
{
    public class SubCategoriaLectura
    {
        public SubCategoriaLectura()
        {
        }
        [Key]
        public Guid Id_SubCategoriaLectura { get; set; }
        public string NombreSubCategoriaLectura { get; set; }
        public string DecripcionSubCategoriaLectura { get; set; }
        public byte[] ImagenSubCategoriaLectura { get; set; }
        public Guid Id_CategoriaLectura { get; set; }
        public Guid Id_Lectura { get; set; }
        public virtual CategoriaLectura Categoria { get; set; }
        public virtual Lectura Lectura { get; set; }

    }
}
