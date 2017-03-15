using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCalculoweb.Models;

namespace SistemaCalculoweb
{
   public class VistaVM
    {
        public Calculo calculoPrincipal { get; set; }
        public List<CalculoReporte> calculoDetalle { get; set; }
    }
}
