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
    public class NivelPreguntasController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: NivelPreguntas
        public ActionResult Index()
        {
            return View(db.NivelPregunta.ToList());
        }

        // GET: NivelPreguntas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var nivelPregunta = db.NivelPregunta
                .FirstOrDefault(m => m.Id_NivelPregunta == id);
            if (nivelPregunta == null)
            {
                return HttpNotFound();
            }

            return View(nivelPregunta);
        }

        // GET: NivelPreguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NivelPregunta nivelPregunta)
        {
            if (ModelState.IsValid)
            {
                nivelPregunta.Id_NivelPregunta = Guid.NewGuid();
                db.NivelPregunta.Add(nivelPregunta);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelPregunta);
        }

        // GET: NivelPreguntas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var nivelPregunta = db.NivelPregunta.Find(id);
            if (nivelPregunta == null)
            {
                return HttpNotFound();
            }
            return View(nivelPregunta);
        }

        // POST: NivelPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, NivelPregunta nivelPregunta)
        {
            if (id != nivelPregunta.Id_NivelPregunta)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(nivelPregunta).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelPreguntaExists(nivelPregunta.Id_NivelPregunta))
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
            return View(nivelPregunta);
        }

        // GET: NivelPreguntas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var nivelPregunta = db.NivelPregunta
                .FirstOrDefault(m => m.Id_NivelPregunta == id);
            if (nivelPregunta == null)
            {
                return HttpNotFound();
            }

            return View(nivelPregunta);
        }

        // POST: NivelPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var nivelPregunta = db.NivelPregunta.Find(id);
            db.NivelPregunta.Remove(nivelPregunta);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelPreguntaExists(Guid id)
        {
            return db.NivelPregunta.Any(e => e.Id_NivelPregunta == id);
        }
    }
}
