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
    public class Servicio_DescripcionController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: Servicio_Descripcion
        public ActionResult Index()
        {
            var servicio_Descripcion = db.Servicio_Descripcion.Include(s => s.Servicios);
            return View(servicio_Descripcion.ToList());
        }

        // GET: Servicio_Descripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio_Descripcion servicio_Descripcion = db.Servicio_Descripcion.Find(id);
            if (servicio_Descripcion == null)
            {
                return HttpNotFound();
            }
            return View(servicio_Descripcion);
        }

        // GET: Servicio_Descripcion/Create
        public ActionResult Create()
        {
            ViewBag.Id_Servicio = new SelectList(db.Servicios, "Id", "Decripcion","Referencia");
            return View();
        }

        // POST: Servicio_Descripcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Servicio,Descripcion,Referencia,HH")] Servicio_Descripcion servicio_Descripcion)
        {
            if (ModelState.IsValid)
            {
                db.Servicio_Descripcion.Add(servicio_Descripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Servicio = new SelectList(db.Servicios, "Id", "Decripcion", "Referencia", servicio_Descripcion.Id_Servicio);
            return View(servicio_Descripcion);
        }

        // GET: Servicio_Descripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio_Descripcion servicio_Descripcion = db.Servicio_Descripcion.Find(id);
            if (servicio_Descripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Servicio = new SelectList(db.Servicios, "Id", "Decripcion", servicio_Descripcion.Id_Servicio);
            return View(servicio_Descripcion);
        }

        // POST: Servicio_Descripcion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Servicio,Descripcion,Referencia,HH")] Servicio_Descripcion servicio_Descripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio_Descripcion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Servicio = new SelectList(db.Servicios, "Id", "Decripcion", servicio_Descripcion.Id_Servicio);
            return View(servicio_Descripcion);
        }

        // GET: Servicio_Descripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio_Descripcion servicio_Descripcion = db.Servicio_Descripcion.Find(id);
            if (servicio_Descripcion == null)
            {
                return HttpNotFound();
            }
            return View(servicio_Descripcion);
        }

        // POST: Servicio_Descripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio_Descripcion servicio_Descripcion = db.Servicio_Descripcion.Find(id);
            db.Servicio_Descripcion.Remove(servicio_Descripcion);
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
