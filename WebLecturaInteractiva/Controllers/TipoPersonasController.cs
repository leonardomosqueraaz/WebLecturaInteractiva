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
    public class TipoPersonasController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: TipoPersonas
        public ActionResult Index()
        {
            return View(db.TipoPersonas.ToList());
        }

        // GET: TipoPersonas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoPersonas = db.TipoPersonas
                .FirstOrDefault(m => m.Id_TPersona == id);
            if (tipoPersonas == null)
            {
                return HttpNotFound();
            }

            return View(tipoPersonas);
        }

        // GET: TipoPersonas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPersonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPersonas tipoPersonas)
        {
            if (ModelState.IsValid)
            {
                tipoPersonas.Id_TPersona = Guid.NewGuid();
                db.TipoPersonas.Add(tipoPersonas);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersonas);
        }

        // GET: TipoPersonas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoPersonas = db.TipoPersonas.FindAsync(id);
            if (tipoPersonas == null)
            {
                return HttpNotFound();
            }
            return View(tipoPersonas);
        }

        // POST: TipoPersonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, TipoPersonas tipoPersonas)
        {
            if (id != tipoPersonas.Id_TPersona)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tipoPersonas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonasExists(tipoPersonas.Id_TPersona))
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
            return View(tipoPersonas);
        }

        // GET: TipoPersonas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tipoPersonas = db.TipoPersonas
                .FirstOrDefault(m => m.Id_TPersona == id);
            if (tipoPersonas == null)
            {
                return HttpNotFound();
            }

            return View(tipoPersonas);
        }

        // POST: TipoPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var tipoPersonas = db.TipoPersonas.Find(id);
            db.TipoPersonas.Remove(tipoPersonas);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonasExists(Guid id)
        {
            return db.TipoPersonas.Any(e => e.Id_TPersona == id);
        }
    }
}
