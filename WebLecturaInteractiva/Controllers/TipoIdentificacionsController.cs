using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebLecturaInteractiva.Models;

namespace WebLecturaInteractiva.Controllers
{
    public class TipoIdentificacionsController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();
        // GET: TipoIdentificacions
        public ActionResult Index()
        {
            return View(db.TipoIdentificacion.ToList());
        }

        // GET: TipoIdentificacions/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoIdentificacion = db.TipoIdentificacion
                .FirstOrDefault(m => m.Id_TipoIdentificacion == id);
            if (tipoIdentificacion == null)
            {
                return HttpNotFound();
            }

            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoIdentificacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoIdentificacion tipoIdentificacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoIdentificacion.Add(tipoIdentificacion);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoIdentificacion = db.TipoIdentificacion.Find(id);
            if (tipoIdentificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoIdentificacion);
        }

        // POST: TipoIdentificacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, TipoIdentificacion tipoIdentificacion)
        {
            if (id != tipoIdentificacion.Id_TipoIdentificacion)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tipoIdentificacion).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIdentificacionExists(tipoIdentificacion.Id_TipoIdentificacion))
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
            return View(tipoIdentificacion);
        }

        // GET: TipoIdentificacions/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoIdentificacion = db.TipoIdentificacion
                .FirstOrDefault(m => m.Id_TipoIdentificacion == id);
            if (tipoIdentificacion == null)
            {
                return HttpNotFound();
            }

            return View(tipoIdentificacion);
        }

        // POST: TipoIdentificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var tipoIdentificacion = db.TipoIdentificacion.Find(id);
            db.TipoIdentificacion.Remove(tipoIdentificacion);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIdentificacionExists(Guid id)
        {
            return db.TipoIdentificacion.Any(e => e.Id_TipoIdentificacion == id);
        }
    }
}
