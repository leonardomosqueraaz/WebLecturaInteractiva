using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebLecturaInteractiva.Models;

namespace WebLecturaInteractiva.Controllers
{
    public class CategoriaLecturasController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: CategoriaLecturas
        public ActionResult Index()
        {
            return View(db.CategoriaLectura.ToList());
        }

        // GET: CategoriaLecturas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var categoriaLectura = db.CategoriaLectura
                .FirstOrDefault(m => m.Id_CategoriaLectura == id);
            if (categoriaLectura == null)
            {
                return HttpNotFound();
            }

            return View(categoriaLectura);
        }

        // GET: CategoriaLecturas/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult ConvertirImagen(Guid id)
        {
            var modoLectura = db.CategoriaLectura.Where(m => m.Id_CategoriaLectura == id).FirstOrDefault();
            return File(modoLectura.ImagenCategoriaLectura, "image/jpeg");
        }
        // POST: CategoriaLecturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaLectura categoriaLectura, HttpPostedFileBase Imagen_CategoriaLectura)
        {
            using (var transacion = db.Database.BeginTransaction())
            {
                categoriaLectura.ImagenCategoriaLectura = Helper.Helper.ConvertirImagenByte(Imagen_CategoriaLectura);
                try
                {
                    if (ModelState.IsValid)
                    {
                        categoriaLectura.Id_CategoriaLectura = Guid.NewGuid();
                        db.CategoriaLectura.Add(categoriaLectura);
                        db.SaveChanges();
                        transacion.Commit();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    transacion.Rollback();
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(categoriaLectura);
                }
            }  
            return View(categoriaLectura);
        }

        // GET: CategoriaLecturas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var categoriaLectura = db.CategoriaLectura.Find(id);
            if (categoriaLectura == null)
            {
                return HttpNotFound();
            }
            return View(categoriaLectura);
        }

        // POST: CategoriaLecturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CategoriaLectura categoriaLectura)
        {
            if (id != categoriaLectura.Id_CategoriaLectura)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(categoriaLectura).State = EntityState.Modified;                   
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaLecturaExists(categoriaLectura.Id_CategoriaLectura))
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
            return View(categoriaLectura);
        }

        // GET: CategoriaLecturas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var categoriaLectura = db.CategoriaLectura
                .FirstOrDefault(m => m.Id_CategoriaLectura == id);
            if (categoriaLectura == null)
            {
                return HttpNotFound();
            }

            return View(categoriaLectura);
        }

        // POST: CategoriaLecturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var categoriaLectura = db.CategoriaLectura.Find(id);
            db.CategoriaLectura.Remove(categoriaLectura);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaLecturaExists(Guid id)
        {
            return db.CategoriaLectura.Any(e => e.Id_CategoriaLectura == id);
        }
    }
}
