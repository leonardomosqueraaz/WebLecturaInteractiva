using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebLecturaInteractiva.Models;

namespace WebLecturaInteractiva.Controllers
{
    public class PersonasController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: Personas
        public ActionResult Index()
        {       
            return View(db.Personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var personas = db.Personas     
                .FirstOrDefault(m => m.Id_Personas == id);
            if (personas == null)
            {
                return HttpNotFound();
            }

            return View(personas);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewData["Id_TipoIdentificacion"] = new SelectList(db.TipoIdentificacion, "Id_TipoIdentificacion", "Nombres_TipoIdentificacion");
            ViewData["Id_TPersona"] = new SelectList(db.TipoPersonas, "Id_TPersona", "Nombre_TPersona");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personas personas)
        {
            using (var transacion = db.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        personas.Estado_Personas = true;                                               
                        personas.FechaCreacion_Personas = DateTime.Now.Date;
                        personas.FechaActualizacion_Personas = DateTime.Now.Date;
                        db.Personas.Add(personas);
                        db.SaveChanges();
                        transacion.Commit();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["Id_TipoIdentificacion"] = new SelectList(db.TipoIdentificacion, "Id_TipoIdentificacion", "Nombres_TipoIdentificacion", personas.Id_TipoIdentificacion);
                    
                    return View(personas);
                }
                catch (Exception ex)
                {
                    transacion.Rollback();
                    throw new Exception(string.Format("Error Personas: {0}", ex.Message));
                }
            }         
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            ViewData["Id_TipoIdentificacion"] = new SelectList(db.TipoIdentificacion, "Id_TipoIdentificacion", "Nombres_TipoIdentificacion", personas.Id_TipoIdentificacion);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Personas personas)
        {
            if (id != personas.Id_Personas)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(personas).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasExists(personas.Id_Personas))
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
            ViewData["v"] = new SelectList(db.TipoIdentificacion, "Id_TipoIdentificacion", "Nombres_TipoIdentificacion", personas.Id_TipoIdentificacion);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var personas = db.Personas
                .FirstOrDefault(m => m.Id_Personas == id);
            if (personas == null)
            {
                return HttpNotFound();
            }

            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var personas = db.Personas.Find(id);
            db.Personas.Remove(personas);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasExists(Guid id)
        {
            return db.Personas.Any(e => e.Id_Personas == id);
        }
    }
}
