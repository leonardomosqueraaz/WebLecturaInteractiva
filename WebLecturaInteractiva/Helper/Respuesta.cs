
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLecturaInteractiva.Helper
{
    public class Respuesta
    {
        public bool Correcto { get; set; }

        public string DatosJson { get; set; }

        public string Mensaje { get; set; }

    }

    public class SerializeObjectAJson
    {
        public string Convertir(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
