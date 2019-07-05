using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLecturaInteractiva.Models;
using Newtonsoft.Json;
using WebLecturaInteractiva.ModelViews;
using System.Web.Mvc;
using Microsoft.Owin;

namespace WebLecturaInteractiva.Controllers
{
    public class CursosController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: Cursos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CargarConfiguracionPregunta()
        {
            ViewBag.NivelPregunta = new SelectList(db.NivelPregunta.Where(t => t.Estado_NivelPregunta == true).ToList(), "Id_NivelPregunta", "Nombre_NivelPregunta");
            ViewBag.TipoPreguntas = new SelectList(db.TipoPreguntas.Where(t => t.Estado_TipoPregunta == true).ToList(), "Id_TipoPregunta", "Nombre_TipoPregunta");
            return View();
        }

        public ActionResult Crear()
        {
            CreacionCursosViews creacionCursosViews = new CreacionCursosViews();

            creacionCursosViews.Cursos = new Cursos();           
            creacionCursosViews.Preguntas = new Preguntas();
            creacionCursosViews.CategoriaLecturas = new List<CategoriaLectura>();
            creacionCursosViews.ModoLecturas = new List<ModoLectura>();
            creacionCursosViews.Lecturas = db.Lectura.ToList();

            foreach (Lectura item in creacionCursosViews.Lecturas)
            {
                foreach (var subCategoriaItem in db.SubCategoriaLectura.Where(t => t.Id_Lectura == item.Id_Lectura).ToList())
                {
                    if (creacionCursosViews.CategoriaLecturas.Where(t => t.Id_CategoriaLectura == subCategoriaItem.Id_CategoriaLectura).ToList().Count == 0)
                        creacionCursosViews.CategoriaLecturas.Add(db.CategoriaLectura.Where(t => t.Id_CategoriaLectura == subCategoriaItem.Id_CategoriaLectura).FirstOrDefault());
                }
                foreach (var detalleModoLecuraItem in db.DetalleModoLecturaXLectura.Where(t => t.Id_Lectura == item.Id_Lectura).ToList())
                {
                    if (creacionCursosViews.ModoLecturas.Where(t => t.Id_ModoLectura == detalleModoLecuraItem.Id_ModoLectura).ToList().Count == 0  )                  
                        creacionCursosViews.ModoLecturas.Add(db.ModoLectura.Where(t => t.Id_ModoLectura == detalleModoLecuraItem.Id_ModoLectura).FirstOrDefault());
                                      
                }                
            }

            ViewBag.Id_NivelPregunta = new SelectList(db.NivelPregunta.Where(t => t.Estado_NivelPregunta == true).ToList(), "Id_NivelPregunta", "Nombre_NivelPregunta");
            ViewBag.Id_TipoPregunta = new SelectList(db.TipoPreguntas.Where(t => t.Estado_TipoPregunta == true).ToList(), "Id_TipoPregunta", "Nombre_TipoPregunta");

            //creacionCursosViews.NivelPregunta = db.NivelPregunta.Where(t => t.Estado_NivelPregunta  == true).ToList();
            //creacionCursosViews.TipoPreguntas = db.TipoPreguntas.Where(t => t.Estado_TipoPregunta == true).ToList();

            creacionCursosViews.ActividadPreguntas = new ActividadPreguntas();


            return View(creacionCursosViews);
        }

        [HttpPost]
        public async Task<JsonResult> Crear(CreacionCursosViews creacionCursosViews, string[] selectedLecturas,string SelectActividad, string SelectTipoPregunta)
        {
            Helper.Respuesta respuesta = new Helper.Respuesta();
            try
            {
                Helper.SerializeObjectAJson serializeObjectAJson = new Helper.SerializeObjectAJson(); 


                if (ModelState.IsValid)
                {                  
                    var json = await Task.Run(() => { return serializeObjectAJson.Convertir(creacionCursosViews); });

                    respuesta.DatosJson = json;
                    respuesta.Correcto = true;
                    respuesta.Mensaje = "Correcto";

                    var respuestaJson = await Task.Run(() => { return serializeObjectAJson.Convertir(respuesta); });

                    return Json(new { data = respuestaJson });
                    
                }
                else
                {
                    throw new Exception("Falatan datos");
                }
            }
            catch (Exception ex)
            {
                respuesta.DatosJson = null;
                respuesta.Correcto = false;
                respuesta.Mensaje = string.Format("Error" ,ex.Message);

                return Json(new { data = JsonConvert.SerializeObject(respuesta)});
            }

        }

        public ActionResult _ViewInformaciónCursoPartial()
        {

            return View();
        }

        [HttpPost]
        public JsonResult _ViewInformaciónCursoPartial(Cursos cursos)
        {
            cursos = new Cursos();
            var json = JsonConvert.SerializeObject(cursos);

            return Json(new { data = json });
        }

        public ActionResult _ViewLecturaCursosPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _ViewLecturaCursosPartial(string[] selectedLetura)
        {
            return PartialView(new Lectura());
        }
        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cursos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}