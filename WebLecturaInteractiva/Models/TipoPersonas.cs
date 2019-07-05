using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLecturaInteractiva.Models
{
    public class TipoPersonas
    {
        [Key]
        public Guid Id_TPersona{ get; set; }
        public string Nombre_TPersona { get; set; }
        public string Descripcion_TPersona { get; set; }
        public bool Estado_Persona { get; set; }
    }
}
