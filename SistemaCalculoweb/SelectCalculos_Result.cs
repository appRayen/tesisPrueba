//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaCalculoweb
{
    using System;
    using System.ComponentModel;

    public partial class SelectCalculos_Result
    {
        public Nullable<int> ID { get; set; }
        public string Servicio { get; set; }
        public string Dispocitivo { get; set; }
        public Nullable<int> Resultado { get; set; }
        [DisplayName("Cantidad Dispocitivos")]
        public Nullable<int> Cantidad_Dispocitivos { get; set; }
        [DisplayName("Volumen de Ticket")]
        public string Volumen_Ticket { get; set; }
        [DisplayName("Cantidad Ticket")]
        public Nullable<int> Cantidad_Ticket { get; set; }
        [DisplayName("Tipo Operación")]
        public string Tipo_de_Operación { get; set; }
        public int IDBUSQUEDA { get; set; }
    }
}
