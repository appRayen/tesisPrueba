using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaCalculoweb;

namespace SistemaCalculoweb.Controllers
{
    public class CalculoHorasController : Controller
    {
        private CalculoEntities db = new CalculoEntities();

        // GET: CalculoHoras
        public int CalculosResultados(int id)
        {
            Random rd = new Random();
            return rd.Next(1, 100); 
        }
        public ActionResult Pdf()
        {
            return new Rotativa.MVC.ActionAsPdf("Reporte");
        }
        public ActionResult Reporte(string id, string servicio)
        {
            ViewBag.Id_Servicio = new SelectList(db.Servicios, "Id", "Decripcion");
            ViewBag.ID = new SelectList(db.CalculoHoras, "Id_calculo", "Id_calculo");
            if (id !=null && id!="" && servicio!=null && servicio!="")
            {
                return View("Reporte",(db.SelectCalculosPar(int.Parse(id.ToString()), int.Parse(servicio.ToString()))));
            }
            else
            {
                return View(db.SelectCalculosPar(0,0));
            }
        }
        public ActionResult ProcesoGuardado(List<String> values)
        {
            //guardar el registro en la tabla calculo y obteren el ID
            Calculo cal = new Calculo();
            cal.fecha = DateTime.Now;
            db.Calculo.Add(cal);
            db.SaveChanges();
            int IdCalculo = cal.Id_calculo;
            //con el Id de Calculo actualizamos la otroa tabla de resultados
            CalculoHoras calho = new CalculoHoras();
            //por medio de un foreach recorremos la lista y la guardamos en la tabla
            foreach (string g in values)
            {

                string[] infoFila = g.Split(',');
                if (infoFila[0].ToString().Trim() != "Tipo Servicio")
                {
                    calho.Id_servicio = int.Parse(infoFila[0].ToString());
                    calho.Id_Servicio_Descripcion = int.Parse(infoFila[1].ToString());
                    calho.cantidad_Servicio = int.Parse(infoFila[2].ToString());
                    calho.Id_Volumen_Ticket = int.Parse(infoFila[3].ToString());
                    calho.Cantidad_Volumen_Ticket = int.Parse(infoFila[4].ToString());
                    calho.Id_Tipo_Operacion = int.Parse(infoFila[5].ToString());
                    calho.Resultado = int.Parse(infoFila[6].ToString());
                    calho.Id_calculo = IdCalculo;
                    db.CalculoHoras.Add(calho);
                    db.SaveChanges();
                }
                
            }
            return RedirectToAction("Index", "CalculoHoras");
        }
        public ActionResult Index()
        {
            return View(db.selectCal());
        }
        public JsonResult LlenarServicio(int id)
        {
            ViewBag.Servicios = new SelectList(db.Servicio_Descripcion.Where(i => i.Id_Servicio == id).ToList(), "id", "Descripcion");
            return Json(new SelectList(db.Servicio_Descripcion.Where(i => i.Id_Servicio == id).ToList(), "id", "Descripcion"));
        }
        public int ProcesoCalculo(int id)
        {
            Random rd = new Random();
            return rd.Next(1, 100);
        }
    // GET: CalculoHoras/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculoHoras calculoHoras = db.CalculoHoras.Find(id);
            if (calculoHoras == null)
            {
                return HttpNotFound();
            }
            return View(calculoHoras);
        }

        // GET: CalculoHoras/Create
        public ActionResult Create()
        {
            ViewBag.Id_Servicio_Descripcion = new SelectList(db.Servicio_Descripcion, "Id", "Descripcion");
            ViewBag.Id_Tipo_Operacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion");
            ViewBag.Id_Volumen_Ticket = new SelectList(db.Volumen_Ticket, "Id", "Sugerencia");
            ViewBag.Id_servicios = new SelectList(db.Servicios, "Id", "decripcion");
            return View();
        }
    
        // POST: CalculoHoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Servicio_Descripcion,cantidad_Servicio,Id_Tipo_Operacion,Id_Volumen_Ticket,Cantidad_Volumen_Ticket,Resultado")] CalculoHoras calculoHoras)
        {
            if (ModelState.IsValid)
            {
                db.CalculoHoras.Add(calculoHoras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Servicio_Descripcion = new SelectList(db.Servicio_Descripcion, "Id", "Descripcion", calculoHoras.Id_Servicio_Descripcion);
            ViewBag.Id_Tipo_Operacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculoHoras.Id_Tipo_Operacion);
            ViewBag.Id_Volumen_Ticket = new SelectList(db.Volumen_Ticket, "Id", "Sugerencia", calculoHoras.Id_Volumen_Ticket);
            ViewBag.Id_Volumen = new SelectList(db.Servicios, "Id", "Sugerencia", calculoHoras.Id_servicio);
            return View(calculoHoras);
        }

        // GET: CalculoHoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculoHoras calculoHoras = db.CalculoHoras.Find(id);
            if (calculoHoras == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Servicio_Descripcion = new SelectList(db.Servicio_Descripcion, "Id", "Descripcion", calculoHoras.Id_Servicio_Descripcion);
            ViewBag.Id_Tipo_Operacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculoHoras.Id_Tipo_Operacion);
            ViewBag.Id_Volumen_Ticket = new SelectList(db.Volumen_Ticket, "Id", "Sugerencia", calculoHoras.Id_Volumen_Ticket);
            ViewBag.Id_servicio = new SelectList(db.Servicios, "Id", "decripcion",calculoHoras.Id_servicio);
            ViewBag.Id_calculo = new SelectList(db.Calculo, "Id", "decripcion", calculoHoras.Id_calculo);
            return View(calculoHoras);
        }

        // POST: CalculoHoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Servicio_Descripcion,cantidad_Servicio,Id_Tipo_Operacion,Id_Volumen_Ticket,Cantidad_Volumen_Ticket,Resultado,Id_servicios,Id_calculo")] CalculoHoras calculoHoras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculoHoras).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Servicio_Descripcion = new SelectList(db.Servicio_Descripcion, "Id", "Descripcion", calculoHoras.Id_Servicio_Descripcion);
            ViewBag.Id_Tipo_Operacion = new SelectList(db.TipoOperacion, "idTipoOperacion", "descripcion", calculoHoras.Id_Tipo_Operacion);
            ViewBag.Id_Volumen_Ticket = new SelectList(db.Volumen_Ticket, "Id", "Sugerencia", calculoHoras.Id_Volumen_Ticket);
            ViewBag.Id_servicios = new SelectList(db.Servicios, "Id", "decripcion", calculoHoras.Id_servicio);
            return View(calculoHoras);
        }

        // GET: CalculoHoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculoHoras calculoHoras = db.CalculoHoras.Find(id);
            if (calculoHoras == null)
            {
                return HttpNotFound();
            }
            return View(calculoHoras);
        }

        // POST: CalculoHoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalculoHoras calculoHoras = db.CalculoHoras.Find(id);
            db.CalculoHoras.Remove(calculoHoras);
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
