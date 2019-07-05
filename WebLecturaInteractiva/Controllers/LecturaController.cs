using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLecturaInteractiva.Models;
using System.Web;
using WebLecturaInteractiva.ModelViews;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WebLecturaInteractiva.Controllers
{
    public class LecturaController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();
        // GET: Lectura
        public ActionResult Index(SubCategoriaLectura subCategoriaLectura)
        {
            return View(db.Lectura.Where(m=>m.Id_Lectura == subCategoriaLectura.Id_Lectura).ToList());
        }

        // GET: Lectura/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var lectura = db.Lectura
                .FirstOrDefault(m => m.Id_Lectura == id);
            if (lectura == null)
            {
                return HttpNotFound();
            }

            return View(lectura);
        }

        // GET: Lectura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lectura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lectura lectura)
        {
            if (ModelState.IsValid)
            {
                lectura.Id_Lectura = Guid.NewGuid();
                db.Lectura.Add(lectura);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(lectura);
        }

        // GET: Lectura/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var lectura = db.Lectura.Find(id);
            if (lectura == null)
            {
                return HttpNotFound();
            }
            return View(lectura);
        }

        // POST: Lectura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id,Lectura lectura)
        {
            if (id != lectura.Id_Lectura)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(lectura).State = EntityState.Modified;                   
                    db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturaExists(lectura.Id_Lectura))
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lectura);
        }

        // GET: Lectura/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var lectura = db.Lectura
                .FirstOrDefault(m => m.Id_Lectura == id);
            if (lectura == null)
            {
                return HttpNotFound();
            }

            return View(lectura);
        }

        // POST: Lectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var lectura = db.Lectura.Find(id);
            db.Lectura.Remove(lectura);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturaExists(Guid id)
        {
            return db.Lectura.Any(e => e.Id_Lectura == id);
        }


        public ActionResult Crear()
        {
            ViewData["Id_ModoLectura"] = new SelectList(db.ModoLectura.ToList(), "Id_ModoLectura", "NombreModoLectura");
            ViewData["Id_CategoriaLectura"] = new SelectList(db.CategoriaLectura.ToList(), "Id_CategoriaLectura", "NombreCategoriaLectura");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(LecturaViews lectura, HttpPostedFileBase Imagen_Lectura)
        {
            using (var transacion = db.Database.BeginTransaction())
            {
                var r = Request;
                try
                {                   
                    lectura.LecturaView.ImagenLectura = Helper.Helper.ConvertirImagenByte(Imagen_Lectura);
                    if (ModelState.IsValid)
                    {
                        #region Guardar Lectura
                        lectura.LecturaView.Id_Lectura = Guid.NewGuid();
                        db.Lectura.Add(lectura.LecturaView);
                        #endregion            

                        #region Relacionar Lectura Con Categoria para Guardar
                        if (db.CategoriaLectura.Where(t => t.Id_CategoriaLectura == lectura.Id_CategoriaLectura).ToList().Count > 0)
                        {
                            SubCategoriaLectura subCategoriaLectura = new SubCategoriaLectura();

                            subCategoriaLectura.Id_Lectura = lectura.LecturaView.Id_Lectura;
                            subCategoriaLectura.Id_CategoriaLectura = lectura.Id_CategoriaLectura;
                            subCategoriaLectura.Id_SubCategoriaLectura = Guid.NewGuid();
                            subCategoriaLectura.ImagenSubCategoriaLectura = db.CategoriaLectura.Where(t => t.Id_CategoriaLectura == lectura.Id_CategoriaLectura).FirstOrDefault().ImagenCategoriaLectura;
                            db.SubCategoriaLectura.Add(subCategoriaLectura);
                        }
                        #endregion

                        #region Relacionar Lectura Con Modo para Guardar
                        if (db.ModoLectura.Where(t => t.Id_ModoLectura == lectura.Id_ModoLectura).ToList().Count > 0)
                        {
                            DetalleModoLecturaXLectura detalleModoLecturaXLectura = new DetalleModoLecturaXLectura();

                            detalleModoLecturaXLectura.Id_ModoLectura = lectura.Id_ModoLectura;
                            detalleModoLecturaXLectura.Id_Lectura = lectura.LecturaView.Id_Lectura;
                            detalleModoLecturaXLectura.Id_DetalleModoLecturaXLectura = Guid.NewGuid();

                            db.DetalleModoLecturaXLectura.Add(detalleModoLecturaXLectura);
                        }
                        #endregion

                        db.SaveChanges();
                    }
                    transacion.Commit();
                }
                catch (Exception ex)
                {
                    transacion.Rollback();
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(lectura);
                }
            }
            return View(lectura);
        }

        public ActionResult ConvertirImagen(Guid id)
        {
            var lectura = db.Lectura.Where(m => m.Id_Lectura == id).FirstOrDefault();
            return File(lectura.ImagenLectura, "image/jpeg");
        }
    }
}
