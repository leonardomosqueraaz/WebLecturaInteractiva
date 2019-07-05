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
    public class DetalleModoLecturaXLecturaController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: DetalleModoLecturaXLectura
        public ActionResult Index()
        {           
            return View(db.DetalleModoLecturaXLectura.ToList());
        }

        // GET: DetalleModoLecturaXLectura/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var detalleModoLecturaXLectura = db.DetalleModoLecturaXLectura        
                .FirstOrDefault(m => m.Id_DetalleModoLecturaXLectura == id);
            if (detalleModoLecturaXLectura == null)
            {
                return HttpNotFound();
            }

            return View(detalleModoLecturaXLectura);
        }

        // GET: DetalleModoLecturaXLectura/Create
        public ActionResult Create()
        {
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "Id_Lectura");
            ViewData["Id_ModoLectura"] = new SelectList(db.ModoLectura, "Id_ModoLectura", "Id_ModoLectura");
            return View();
        }

        // POST: DetalleModoLecturaXLectura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DetalleModoLecturaXLectura detalleModoLecturaXLectura)
        {
            if (ModelState.IsValid)
            {
                detalleModoLecturaXLectura.Id_DetalleModoLecturaXLectura = Guid.NewGuid();
                db.DetalleModoLecturaXLectura.Add(detalleModoLecturaXLectura);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "Id_Lectura", detalleModoLecturaXLectura.Id_Lectura);
            ViewData["Id_ModoLectura"] = new SelectList(db.ModoLectura, "Id_ModoLectura", "Id_ModoLectura", detalleModoLecturaXLectura.Id_ModoLectura);
            return View(detalleModoLecturaXLectura);
        }

        // GET: DetalleModoLecturaXLectura/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var detalleModoLecturaXLectura = db.DetalleModoLecturaXLectura.Find(id);
            if (detalleModoLecturaXLectura == null)
            {
                return HttpNotFound();
            }
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "Id_Lectura", detalleModoLecturaXLectura.Id_Lectura);
            ViewData["Id_ModoLectura"] = new SelectList(db.ModoLectura, "Id_ModoLectura", "Id_ModoLectura", detalleModoLecturaXLectura.Id_ModoLectura);
            return View(detalleModoLecturaXLectura);
        }

        // POST: DetalleModoLecturaXLectura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, DetalleModoLecturaXLectura detalleModoLecturaXLectura)
        {
            if (id != detalleModoLecturaXLectura.Id_DetalleModoLecturaXLectura)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(detalleModoLecturaXLectura).State = EntityState.Modified;          
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleModoLecturaXLecturaExists(detalleModoLecturaXLectura.Id_DetalleModoLecturaXLectura))
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
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "Id_Lectura", detalleModoLecturaXLectura.Id_Lectura);
            ViewData["Id_ModoLectura"] = new SelectList(db.Set<ModoLectura>(), "Id_ModoLectura", "Id_ModoLectura", detalleModoLecturaXLectura.Id_ModoLectura);
            return View(detalleModoLecturaXLectura);
        }

        // GET: DetalleModoLecturaXLectura/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var detalleModoLecturaXLectura = db.DetalleModoLecturaXLectura   
                .FirstOrDefault(m => m.Id_DetalleModoLecturaXLectura == id);
            if (detalleModoLecturaXLectura == null)
            {
                return HttpNotFound();
            }

            return View(detalleModoLecturaXLectura);
        }

        // POST: DetalleModoLecturaXLectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var detalleModoLecturaXLectura = db.DetalleModoLecturaXLectura.Find(id);
            db.DetalleModoLecturaXLectura.Remove(detalleModoLecturaXLectura);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleModoLecturaXLecturaExists(Guid id)
        {
            return db.DetalleModoLecturaXLectura.Any(e => e.Id_DetalleModoLecturaXLectura == id);
        }
    }
}
