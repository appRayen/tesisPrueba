﻿using System;
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
    public class ServiciosController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            return View(db.Servicios.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Decripcion,Referencia")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Decripcion,Referencia")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
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
