using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLecturaInteractiva.Models;

namespace WebLecturaInteractiva.ModelViews
{
    public class CreacionCursosViews
    {
        public Cursos Cursos { get; set; }

        public ActividadPreguntas ActividadPreguntas { get; set; }

        public Preguntas Preguntas { get; set; }

        public List<TipoPreguntas> TipoPreguntas { get; set; }

        public List<NivelPregunta> NivelPregunta { get; set; }

        public List<Lectura> Lecturas { get; set; }

        public List<ModoLectura> ModoLecturas { get; set; }

        public List<CategoriaLectura> CategoriaLecturas { get; set; }

        public Guid Id_TipoPregunta { get; set; }

        public Guid Id_NivelPregunta { get; set; }

    }
}
