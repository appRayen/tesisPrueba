using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalculoweb
{
   public class VistaVM
    {
        public Calculo calculoPrincipal { get; set; }
        public List<CalculoHoras> calculoDetalle { get; set; }
    }
}
