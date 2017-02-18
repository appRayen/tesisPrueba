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
    public class TipoServicioBrindadoesController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: TipoServicioBrindadoes
        //[Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.TipoServicioBrindado.ToList());
        }

        // GET: TipoServicioBrindadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicioBrindado tipoServicioBrindado = db.TipoServicioBrindado.Find(id);
            if (tipoServicioBrindado == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicioBrindado);
        }

        // GET: TipoServicioBrindadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicioBrindadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoServicioBrindado,descripcion,estado")] TipoServicioBrindado tipoServicioBrindado)
        {
            if (ModelState.IsValid)
            {
                db.TipoServicioBrindado.Add(tipoServicioBrindado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoServicioBrindado);
        }

        // GET: TipoServicioBrindadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicioBrindado tipoServicioBrindado = db.TipoServicioBrindado.Find(id);
            if (tipoServicioBrindado == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicioBrindado);
        }

        // POST: TipoServicioBrindadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoServicioBrindado,descripcion,estado")] TipoServicioBrindado tipoServicioBrindado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoServicioBrindado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoServicioBrindado);
        }

        // GET: TipoServicioBrindadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicioBrindado tipoServicioBrindado = db.TipoServicioBrindado.Find(id);
            if (tipoServicioBrindado == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicioBrindado);
        }

        // POST: TipoServicioBrindadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoServicioBrindado tipoServicioBrindado = db.TipoServicioBrindado.Find(id);
            db.TipoServicioBrindado.Remove(tipoServicioBrindado);
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
