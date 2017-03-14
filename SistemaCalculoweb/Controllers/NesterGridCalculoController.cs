using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaCalculoweb.Controllers
{
    public class NesterGridCalculoController : Controller
    {
        // GET: NesterGridCalculo
        public ActionResult List()
        {
            List<VistaVM> allOrder = new List<VistaVM>();

            // here MyDatabaseEntities is our data context
            
            using (CalculoEntities dc = new CalculoEntities())
            {
                var o = dc.Calculo.OrderByDescending(a => a.Id_calculo);
                foreach (var i in o)
                {
                    var od = dc.CalculoHoras.Where(a => a.Id_calculo==i.Id_calculo).ToList();
                    allOrder.Add(new VistaVM { calculoPrincipal = i, calculoDetalle = od });
                }
            }
            return View(allOrder);
        }
    }
}