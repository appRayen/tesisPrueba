using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaCalculoweb;

namespace SistemaCalculoweb.Controllers
{
    public class TipoActividadBasesController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: TipoActividadBases
        public ActionResult Index()
        {
            return View(db.TipoActividadBase.ToList());
        }

        // GET: TipoActividadBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActividadBase tipoActividadBase = db.TipoActividadBase.Find(id);
            if (tipoActividadBase == null)
            {
                return HttpNotFound();
            }
            return View(tipoActividadBase);
        }

        // GET: TipoActividadBases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoActividadBases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoActividadBase,descripcion,estado")] TipoActividadBase tipoActividadBase)
        {
            if (ModelState.IsValid)
            {
                db.TipoActividadBase.Add(tipoActividadBase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoActividadBase);
        }

        // GET: TipoActividadBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActividadBase tipoActividadBase = db.TipoActividadBase.Find(id);
            if (tipoActividadBase == null)
            {
                return HttpNotFound();
            }
            return View(tipoActividadBase);
        }

        // POST: TipoActividadBases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoActividadBase,descripcion,estado")] TipoActividadBase tipoActividadBase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoActividadBase).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoActividadBase);
        }

        // GET: TipoActividadBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActividadBase tipoActividadBase = db.TipoActividadBase.Find(id);
            if (tipoActividadBase == null)
            {
                return HttpNotFound();
            }
            return View(tipoActividadBase);
        }

        // POST: TipoActividadBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoActividadBase tipoActividadBase = db.TipoActividadBase.Find(id);
            db.TipoActividadBase.Remove(tipoActividadBase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
