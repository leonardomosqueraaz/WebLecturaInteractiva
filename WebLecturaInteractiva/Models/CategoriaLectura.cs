using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebLecturaInteractiva.Models
{
    public class CategoriaLectura
    {
        public CategoriaLectura()
        {
        }
        [Key]
        public Guid Id_CategoriaLectura { get; set; }
        public string NombreCategoriaLectura { get; set; }
        public string EstrategiaCategoriaLectura { get; set; }
        public string DescripcionCategoriaLectura { get; set; }
        public byte[] ImagenCategoriaLectura { get; set; }
        public virtual ICollection<SubCategoriaLectura> SubCategorias { get; set; }
    }
}
