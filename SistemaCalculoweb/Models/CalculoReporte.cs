using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCalculoweb.Models
{
    public class CalculoReporte
    {
        public string servicio { get; set; }
        public string dispositivo { get; set; }
        public string cantDispositivo { get; set; }
        public string requerimiento { get; set; }
        public string cantRequerimiento { get; set; }
        public string resutado { get; set; }
        public string tipoOperacion { get; set; }
        public string id { get; set; }
    }
}