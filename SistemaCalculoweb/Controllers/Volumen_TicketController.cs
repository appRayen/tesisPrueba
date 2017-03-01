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
    public class Volumen_TicketController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: Volumen_Ticket
        public ActionResult Index()
        {
            return View(db.Volumen_Ticket.ToList());
        }

        // GET: Volumen_Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volumen_Ticket volumen_Ticket = db.Volumen_Ticket.Find(id);
            if (volumen_Ticket == null)
            {
                return HttpNotFound();
            }
            return View(volumen_Ticket);
        }

        // GET: Volumen_Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volumen_Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sugerencia,Descripcion")] Volumen_Ticket volumen_Ticket)
        {
            if (ModelState.IsValid)
            {
                db.Volumen_Ticket.Add(volumen_Ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volumen_Ticket);
        }

        // GET: Volumen_Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volumen_Ticket volumen_Ticket = db.Volumen_Ticket.Find(id);
            if (volumen_Ticket == null)
            {
                return HttpNotFound();
            }
            return View(volumen_Ticket);
        }

        // POST: Volumen_Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sugerencia,Descripcion")] Volumen_Ticket volumen_Ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volumen_Ticket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volumen_Ticket);
        }

        // GET: Volumen_Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volumen_Ticket volumen_Ticket = db.Volumen_Ticket.Find(id);
            if (volumen_Ticket == null)
            {
                return HttpNotFound();
            }
            return View(volumen_Ticket);
        }

        // POST: Volumen_Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volumen_Ticket volumen_Ticket = db.Volumen_Ticket.Find(id);
            db.Volumen_Ticket.Remove(volumen_Ticket);
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
