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
    public class CalculosResultadosController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: CalculosResultados
        public ActionResult Index()
        {
            var calculosResultados = db.CalculosResultados.Include(c => c.Empresa).Include(c => c.TipoActividadBase).Include(c => c.TipoInfraestructura).Include(c => c.TipoOperacion).Include(c => c.TipoServicioBrindado).Include(c => c.TipoTicket).Include(c => c.Usuario);
            return View(calculosResultados.ToList());
        }

        // GET: CalculosResultados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculosResultados calculosResultados = db.CalculosResultados.Find(id);
            if (calculosResultados == null)
            {
                return HttpNotFound();
            }
            return View(calculosResultados);
        }

        // GET: CalculosResultados/Create
        public ActionResult Create()
        {
            ViewBag.idEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nombre");
            ViewBag.idTipoActividadBase = new SelectList(db.TipoActividadBase, "idTipoActividadBase", "descripcion");
            ViewBag.idTipoInfraestructura = new SelectList(db.TipoInfraestructura, "idTipoInfraesteructura", "descripcion");
            ViewBag.idTipoOperacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion");
            ViewBag.idTipoServicioBrindado = new SelectList(db.TipoServicioBrindado, "idTipoServicioBrindado", "descripcion");
            ViewBag.idTipoTicket = new SelectList(db.TipoTicket, "tipoTicket", "descripcion");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idTipoUsuario", "nombreUsuario");
            return View();
        }

        // POST: CalculosResultados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCalculo,resultado,cantidadPersonas,fechaCalculo,idUsuario,idTipoInfraestructura,idTipoOperacion,idTipoTicket,idTipoServicioBrindado,idTipoActividadBase,idEmpresa")] CalculosResultados calculosResultados)
        {
            if (ModelState.IsValid)
            {
                db.CalculosResultados.Add(calculosResultados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nombre", calculosResultados.idEmpresa);
            ViewBag.idTipoActividadBase = new SelectList(db.TipoActividadBase, "idTipoActividadBase", "descripcion", calculosResultados.idTipoActividadBase);
            ViewBag.idTipoInfraestructura = new SelectList(db.TipoInfraestructura, "idTipoInfraesteructura", "descripcion", calculosResultados.idTipoInfraestructura);
            ViewBag.idTipoOperacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculosResultados.idTipoOperacion);
            ViewBag.idTipoServicioBrindado = new SelectList(db.TipoServicioBrindado, "idTipoServicioBrindado", "descripcion", calculosResultados.idTipoServicioBrindado);
            ViewBag.idTipoTicket = new SelectList(db.TipoTicket, "tipoTicket", "descripcion", calculosResultados.idTipoTicket);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idTipoUsuario", "nombreUsuario", calculosResultados.idUsuario);
            ViewBag.resultado = 33;
             return View(calculosResultados);
        }

        // GET: CalculosResultados/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculosResultados calculosResultados = db.CalculosResultados.Find(id);
            if (calculosResultados == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nombre", calculosResultados.idEmpresa);
            ViewBag.idTipoActividadBase = new SelectList(db.TipoActividadBase, "idTipoActividadBase", "descripcion", calculosResultados.idTipoActividadBase);
            ViewBag.idTipoInfraestructura = new SelectList(db.TipoInfraestructura, "idTipoInfraesteructura", "descripcion", calculosResultados.idTipoInfraestructura);
            ViewBag.idTipoOperacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculosResultados.idTipoOperacion);
            ViewBag.idTipoServicioBrindado = new SelectList(db.TipoServicioBrindado, "idTipoServicioBrindado", "descripcion", calculosResultados.idTipoServicioBrindado);
            ViewBag.idTipoTicket = new SelectList(db.TipoTicket, "tipoTicket", "descripcion", calculosResultados.idTipoTicket);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idTipoUsuario", "nombreUsuario", calculosResultados.idUsuario);
            return View(calculosResultados);
        }
        public ActionResult GeneratePDF()
        {
            return new Rotativa.MVC.ActionAsPdf("Create");
        }
        public ActionResult ProcesoCalculo(string idTipoActividadBase, string TipoInfraestructura, string TipoOperacion, string TipoServicioBrindado, string TipoTicket,string cantP)
        {
            Random rm = new Random();
            CalculosResultados calculosResultados = new CalculosResultados();
            calculosResultados.resultado = rm.Next(1,100);
            calculosResultados.idTipoActividadBase = int.Parse(idTipoActividadBase.ToString());
            calculosResultados.idTipoInfraestructura = int.Parse(TipoInfraestructura.ToString());
            calculosResultados.idTipoOperacion = int.Parse(TipoOperacion.ToString()); 
            calculosResultados.idTipoServicioBrindado = int.Parse(TipoServicioBrindado.ToString());
            calculosResultados.idTipoTicket = int.Parse(TipoTicket.ToString()); 
            ViewBag.idEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nombre", calculosResultados.idEmpresa);
            ViewBag.idTipoActividadBase = new SelectList(db.TipoActividadBase, "idTipoActividadBase", "descripcion", calculosResultados.idTipoActividadBase);
            ViewBag.idTipoInfraestructura = new SelectList(db.TipoInfraestructura, "idTipoInfraesteructura", "descripcion", calculosResultados.idTipoInfraestructura);
            ViewBag.idTipoOperacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculosResultados.idTipoOperacion);
            ViewBag.idTipoServicioBrindado = new SelectList(db.TipoServicioBrindado, "idTipoServicioBrindado", "descripcion", calculosResultados.idTipoServicioBrindado);
            ViewBag.idTipoTicket = new SelectList(db.TipoTicket, "tipoTicket", "descripcion", calculosResultados.idTipoTicket);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idTipoUsuario", "nombreUsuario", calculosResultados.idUsuario);
            ViewBag.resultado = calculosResultados.resultado;
            ViewData["Resultado"] = calculosResultados.resultado;
            return View("Create", calculosResultados);
        }
        // POST: CalculosResultados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCalculo,resultado,cantidadPersonas,fechaCalculo,idUsuario,idTipoInfraestructura,idTipoOperacion,idTipoTicket,idTipoServicioBrindado,idTipoActividadBase,idEmpresa")] CalculosResultados calculosResultados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculosResultados).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpresa = new SelectList(db.Empresa, "IdEmpresa", "Nombre", calculosResultados.idEmpresa);
            ViewBag.idTipoActividadBase = new SelectList(db.TipoActividadBase, "idTipoActividadBase", "descripcion", calculosResultados.idTipoActividadBase);
            ViewBag.idTipoInfraestructura = new SelectList(db.TipoInfraestructura, "idTipoInfraesteructura", "descripcion", calculosResultados.idTipoInfraestructura);
            ViewBag.idTipoOperacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculosResultados.idTipoOperacion);
            ViewBag.idTipoServicioBrindado = new SelectList(db.TipoServicioBrindado, "idTipoServicioBrindado", "descripcion", calculosResultados.idTipoServicioBrindado);
            ViewBag.idTipoTicket = new SelectList(db.TipoTicket, "tipoTicket", "descripcion", calculosResultados.idTipoTicket);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idTipoUsuario", "nombreUsuario", calculosResultados.idUsuario);
            return View(calculosResultados);
        }

        // GET: CalculosResultados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculosResultados calculosResultados = db.CalculosResultados.Find(id);
            if (calculosResultados == null)
            {
                return HttpNotFound();
            }
            return View(calculosResultados);
        }

        // POST: CalculosResultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalculosResultados calculosResultados = db.CalculosResultados.Find(id);
            db.CalculosResultados.Remove(calculosResultados);
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
