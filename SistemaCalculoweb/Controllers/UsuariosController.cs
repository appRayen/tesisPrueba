using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SistemaCalculoweb;

namespace SistemaCalculoweb.Controllers
{
    public class UsuariosController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: Usuarios
        public ActionResult recuperarpws(Usuarios usuarios)
        {
            if (usuarios.Correo != null && usuarios.Correo != "")
            {
                List<Usuarios> us = db.Usuarios.Where(i => i.Correo == usuarios.Correo).ToList();
                    GMailer.GmailUsername = "sacp.noreply@gmail.com";
                    GMailer.GmailPassword = "sacpnoreply$";

                    GMailer mailer = new GMailer();
                    mailer.ToEmail = us[0].Correo.ToString();
                    mailer.Subject = "Recuperacion de contraseña";
                    mailer.Body = "Su contraseña es <br>" + us[0].Contrasenia.ToString();
                    mailer.IsHtml = true;
                    mailer.Send();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(); 
            }
            
        }
        public ActionResult LogOff()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login(Usuarios usuarios)
        {
            if (usuarios.Correo != null && usuarios.Correo != "" && usuarios.Contrasenia != null && usuarios.Contrasenia != "")
            {
                List<Usuarios> us = db.Usuarios.Where(i => i.Correo == usuarios.Correo && usuarios.Contrasenia == i.Contrasenia).ToList();
                if (us.Count > 0)
               {
                    Session["Usuario"] = us[0].Nombre + " " + us[0].ApellidoP;
                    return RedirectToAction("Index", "Home");
                }
               else
               {
                    ViewBag.Error = "nombre de usuario o contraseña incorrecta";
                    return View();
                }
                 
            }
            else
            {
                return View();
            }

        }
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Perfil);
            return View(usuarios.ToList());
        }
        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idPerfil = new SelectList(db.Perfil, "IdPerfil", "Descripcion");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Correo,Nombre,ApellidoP,ApellidoM,Rut,Telefono,Contrasenia,idPerfil")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPerfil = new SelectList(db.Perfil, "IdPerfil", "Descripcion", usuarios.idPerfil);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPerfil = new SelectList(db.Perfil, "IdPerfil", "Descripcion", usuarios.idPerfil);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Correo,Nombre,ApellidoP,ApellidoM,Rut,Telefono,Contrasenia,idPerfil")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPerfil = new SelectList(db.Perfil, "IdPerfil", "Descripcion", usuarios.idPerfil);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
