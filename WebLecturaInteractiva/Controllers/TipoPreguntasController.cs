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
    public class TipoPreguntasController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: TipoPreguntas
        public ActionResult Index()
        {
            return View(db.TipoPreguntas.ToList());
        }

        // GET: TipoPreguntas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoPreguntas = db.TipoPreguntas
                .FirstOrDefault(m => m.Id_TipoPregunta == id);
            if (tipoPreguntas == null)
            {
                return HttpNotFound();
            }

            return View(tipoPreguntas);
        }

        // GET: TipoPreguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPreguntas tipoPreguntas)
        {
            if (ModelState.IsValid)
            {
                tipoPreguntas.Id_TipoPregunta = Guid.NewGuid();
                db.TipoPreguntas.Add(tipoPreguntas);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPreguntas);
        }

        // GET: TipoPreguntas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoPreguntas = db.TipoPreguntas.Find(id);
            if (tipoPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(tipoPreguntas);
        }

        // POST: TipoPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, TipoPreguntas tipoPreguntas)
        {
            if (id != tipoPreguntas.Id_TipoPregunta)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tipoPreguntas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPreguntasExists(tipoPreguntas.Id_TipoPregunta))
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
            return View(tipoPreguntas);
        }

        // GET: TipoPreguntas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoPreguntas = db.TipoPreguntas
                .FirstOrDefault(m => m.Id_TipoPregunta == id);
            if (tipoPreguntas == null)
            {
                return HttpNotFound();
            }

            return View(tipoPreguntas);
        }

        // POST: TipoPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var tipoPreguntas = db.TipoPreguntas.Find(id);
            db.TipoPreguntas.Remove(tipoPreguntas);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPreguntasExists(Guid id)
        {
            return db.TipoPreguntas.Any(e => e.Id_TipoPregunta == id);
        }
    }
}
