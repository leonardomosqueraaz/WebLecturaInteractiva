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
    public class ModoLecturasController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: ModoLecturas
        public ActionResult Index()
        {
            return View(db.ModoLectura.ToList());
        }

        // GET: ModoLecturas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var modoLectura = db.ModoLectura
                .FirstOrDefault(m => m.Id_ModoLectura == id);
            if (modoLectura == null)
            {
                return HttpNotFound();
            }

            return View(modoLectura);
        }

        // GET: ModoLecturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModoLecturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModoLectura modoLectura, HttpPostedFileBase Imagen_ModoLectura)
        {
            using (var transacion = db.Database.BeginTransaction())
            {
                modoLectura.ImagenModoLectura = Helper.Helper.ConvertirImagenByte(Imagen_ModoLectura);
                try
                {
                    if (ModelState.IsValid)
                    {
                        modoLectura.Id_ModoLectura = Guid.NewGuid();
                        db.ModoLectura.Add(modoLectura);
                        db.SaveChanges();
                        transacion.Commit();
                        return RedirectToAction(nameof(Index));
                    }               
                }
                catch (Exception ex)
                {
                    transacion.Rollback();
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(modoLectura);
                }
            }

            return View(modoLectura);
        }

        public ActionResult ConvertirImagen(Guid id)
        {
            var modoLectura = db.ModoLectura.Where(m => m.Id_ModoLectura == id).FirstOrDefault();
            return File(modoLectura.ImagenModoLectura, "image/jpeg");
        }

        // GET: ModoLecturas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var modoLectura = db.ModoLectura.Find(id);
            if (modoLectura == null)
            {
                return HttpNotFound();
            }
            return View(modoLectura);
        }

        // POST: ModoLecturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ModoLectura modoLectura)
        {
            if (id != modoLectura.Id_ModoLectura)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(modoLectura).State = EntityState.Modified;                   
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModoLecturaExists(modoLectura.Id_ModoLectura))
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
            return View(modoLectura);
        }

        // GET: ModoLecturas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var modoLectura = db.ModoLectura
                .FirstOrDefault(m => m.Id_ModoLectura == id);
            if (modoLectura == null)
            {
                return HttpNotFound();
            }

            return View(modoLectura);
        }

        // POST: ModoLecturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var modoLectura = db.ModoLectura.Find(id);
            db.ModoLectura.Remove(modoLectura);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ModoLecturaExists(Guid id)
        {
            return db.ModoLectura.Any(e => e.Id_ModoLectura == id);
        }
    }
}
