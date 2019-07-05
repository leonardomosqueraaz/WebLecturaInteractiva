using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebLecturaInteractiva.Helper
{
    public class Helper
    {
        //public static List<WebLecturaInteractivaRole> roles = new List<WebLecturaInteractivaRole>() {
        //    new WebLecturaInteractivaRole { Name = "administrador" },
        //    new WebLecturaInteractivaRole { Name = "estudiante" },
        //    new WebLecturaInteractivaRole { Name = "docente" }
        //};

        public enum VariablesVD 
        {
            VDSubCategoria,
            Title,
            VDCategoriaLectura
        }
        /// <summary>
        /// Este metodo convierte una imagen de tipo file a un array Byte
        /// </summary>
        /// <param name="Imagen_Data"> recibe un parametro de tipo IFormFile</param>
        /// <returns>Array de Byte</returns>
        public static byte[] ConvertirImagenByte(HttpPostedFileBase Imagen_Data)
        {
            byte[] imagenData = null;
            try
            {
                if (Imagen_Data != null && Imagen_Data.ContentLength > 0)
                {
                    using (var binaryMenu = new BinaryReader(Imagen_Data.InputStream))
                    {
                        imagenData = binaryMenu.ReadBytes(Convert.ToInt32(Imagen_Data.ContentLength));
                    }                   
                }
                else
                {
                    throw new Exception("Por favor Selecciones una Imagen");
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return imagenData;
        }
    }
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script)
        {
            this.Content = script;
            this.ContentType = "application/javascript";
        }
    }
}
