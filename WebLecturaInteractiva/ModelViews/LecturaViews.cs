using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLecturaInteractiva.Models;

namespace WebLecturaInteractiva.ModelViews
{
    public class LecturaViews
    {
        public Lectura LecturaView { get; set; }

        public Guid Id_ModoLectura { get; set; }

        public Guid Id_CategoriaLectura { get; set; }
    }
}
