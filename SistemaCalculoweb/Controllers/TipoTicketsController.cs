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
    public class TipoTicketsController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: TipoTickets
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.TipoTicket.ToList());
        }

        // GET: TipoTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTicket tipoTicket = db.TipoTicket.Find(id);
            if (tipoTicket == null)
            {
                return HttpNotFound();
            }
            return View(tipoTicket);
        }

        // GET: TipoTickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTickets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoTicket,descripcion,estado")] TipoTicket tipoTicket)
        {
            if (ModelState.IsValid)
            {
                db.TipoTicket.Add(tipoTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTicket);
        }

        // GET: TipoTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTicket tipoTicket = db.TipoTicket.Find(id);
            if (tipoTicket == null)
            {
                return HttpNotFound();
            }
            return View(tipoTicket);
        }

        // POST: TipoTickets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoTicket,descripcion,estado")] TipoTicket tipoTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTicket);
        }

        // GET: TipoTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTicket tipoTicket = db.TipoTicket.Find(id);
            if (tipoTicket == null)
            {
                return HttpNotFound();
            }
            return View(tipoTicket);
        }

        // POST: TipoTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTicket tipoTicket = db.TipoTicket.Find(id);
            db.TipoTicket.Remove(tipoTicket);
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
