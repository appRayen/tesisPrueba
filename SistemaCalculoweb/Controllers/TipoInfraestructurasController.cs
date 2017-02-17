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
    public class TipoInfraestructurasController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: TipoInfraestructuras
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.TipoInfraestructura.ToList());
        }

        // GET: TipoInfraestructuras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInfraestructura tipoInfraestructura = db.TipoInfraestructura.Find(id);
            if (tipoInfraestructura == null)
            {
                return HttpNotFound();
            }
            return View(tipoInfraestructura);
        }

        // GET: TipoInfraestructuras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoInfraestructuras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoInfraesteructura,descripcion,estado")] TipoInfraestructura tipoInfraestructura)
        {
            if (ModelState.IsValid)
            {
                db.TipoInfraestructura.Add(tipoInfraestructura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoInfraestructura);
        }

        // GET: TipoInfraestructuras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInfraestructura tipoInfraestructura = db.TipoInfraestructura.Find(id);
            if (tipoInfraestructura == null)
            {
                return HttpNotFound();
            }
            return View(tipoInfraestructura);
        }

        // POST: TipoInfraestructuras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoInfraesteructura,descripcion,estado")] TipoInfraestructura tipoInfraestructura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoInfraestructura).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoInfraestructura);
        }

        // GET: TipoInfraestructuras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInfraestructura tipoInfraestructura = db.TipoInfraestructura.Find(id);
            if (tipoInfraestructura == null)
            {
                return HttpNotFound();
            }
            return View(tipoInfraestructura);
        }

        // POST: TipoInfraestructuras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoInfraestructura tipoInfraestructura = db.TipoInfraestructura.Find(id);
            db.TipoInfraestructura.Remove(tipoInfraestructura);
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
