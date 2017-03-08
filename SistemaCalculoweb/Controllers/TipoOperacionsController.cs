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
    public class TipoOperacionsController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: TipoOperacions
        //[Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.TipoOperacion.ToList());
        }

        // GET: TipoOperacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOperacion tipoOperacion = db.TipoOperacion.Find(id);
            if (tipoOperacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoOperacion);
        }

        // GET: TipoOperacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoOperacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoOperacion,descripcion,estado,Referencia")] TipoOperacion tipoOperacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoOperacion.Add(tipoOperacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoOperacion);
        }

        // GET: TipoOperacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOperacion tipoOperacion = db.TipoOperacion.Find(id);
            if (tipoOperacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoOperacion);
        }

        // POST: TipoOperacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoOperacion,descripcion,estado,Referencia")] TipoOperacion tipoOperacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoOperacion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoOperacion);
        }

        // GET: TipoOperacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOperacion tipoOperacion = db.TipoOperacion.Find(id);
            if (tipoOperacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoOperacion);
        }

        // POST: TipoOperacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoOperacion tipoOperacion = db.TipoOperacion.Find(id);
            db.TipoOperacion.Remove(tipoOperacion);
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
