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
    public class SubCategoriaLecturaController : Controller
    {
        private WebLecturaInteractivaContext db = new WebLecturaInteractivaContext();

        // GET: SubCategoriaLectura
        public ActionResult Index(CategoriaLectura categoriaLectura)
        {
            var wLIContext = db.SubCategoriaLectura.Where(m=>m.Id_CategoriaLectura == categoriaLectura.Id_CategoriaLectura);
            ViewData[Helper.Helper.VariablesVD.VDCategoriaLectura.ToString()] = db.CategoriaLectura.Find(categoriaLectura.Id_CategoriaLectura);
            if (wLIContext == null)
            {
                return HttpNotFound();
            }
            return View(wLIContext.ToList());
        }

        // GET: SubCategoriaLectura/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var subCategoriaLectura = db.SubCategoriaLectura          
                .FirstOrDefault(m => m.Id_SubCategoriaLectura == id);
            if (subCategoriaLectura == null)
            {
                return HttpNotFound();
            }

            return View(subCategoriaLectura);
        }

        // GET: SubCategoriaLectura/Create
        public ActionResult Create()
        {
            ViewData["Id_CategoriaLectura"] = new SelectList(db.CategoriaLectura, "Id_CategoriaLectura", "NombreCategoriaLectura");
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "TituloLectura");
            return View();
        }

        // POST: SubCategoriaLectura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategoriaLectura subCategoriaLectura)
        {
            if (ModelState.IsValid)
            {
                subCategoriaLectura.Id_SubCategoriaLectura = Guid.NewGuid();
                db.SubCategoriaLectura.Add(subCategoriaLectura);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_CategoriaLectura"] = new SelectList(db.CategoriaLectura, "Id_CategoriaLectura", "NombreCategoriaLectura");
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "TituloLectura");
            return View(subCategoriaLectura);
        }

        // GET: SubCategoriaLectura/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var subCategoriaLectura = db.SubCategoriaLectura.Find(id);
            if (subCategoriaLectura == null)
            {
                return HttpNotFound();
            }
            ViewData["Id_CategoriaLectura"] = new SelectList(db.CategoriaLectura, "Id_CategoriaLectura", "NombreCategoriaLectura");
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "TituloLectura");
            return View(subCategoriaLectura);
        }

        // POST: SubCategoriaLectura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, SubCategoriaLectura subCategoriaLectura)
        {
            if (id != subCategoriaLectura.Id_SubCategoriaLectura)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(subCategoriaLectura).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoriaLecturaExists(subCategoriaLectura.Id_SubCategoriaLectura))
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
            ViewData["Id_CategoriaLectura"] = new SelectList(db.CategoriaLectura, "Id_CategoriaLectura", "NombreCategoriaLectura");
            ViewData["Id_Lectura"] = new SelectList(db.Lectura, "Id_Lectura", "TituloLectura");
            return View(subCategoriaLectura);
        }

        // GET: SubCategoriaLectura/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var subCategoriaLectura = db.SubCategoriaLectura
                .Include(s => s.Categoria)
                .Include(s => s.Lectura)
                .FirstOrDefault(m => m.Id_SubCategoriaLectura == id);
            if (subCategoriaLectura == null)
            {
                return HttpNotFound();
            }

            return View(subCategoriaLectura);
        }

        // POST: SubCategoriaLectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var subCategoriaLectura = db.SubCategoriaLectura.Find(id);
            db.SubCategoriaLectura.Remove(subCategoriaLectura);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoriaLecturaExists(Guid id)
        {
            return db.SubCategoriaLectura.Any(e => e.Id_SubCategoriaLectura == id);
        }
    }
}
