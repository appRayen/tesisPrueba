//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
        [DisplayName("Dispositivos")]
        public string Dispocitivo { get; set; }
        public Nullable<int> Resultado { get; set; }
        [DisplayName("Cantidad Dispositivos")]
        public Nullable<int> Cantidad_Dispocitivos { get; set; }
        [DisplayName("Requerimientos")]
        public string Volumen_Ticket { get; set; }
        [DisplayName("Cantidad Requerimientos")]
        public Nullable<int> Cantidad_Ticket { get; set; }
        [DisplayName("Tipo Operación")]
        public string Tipo_de_Operación { get; set; }
        public int IDBUSQUEDA { get; set; }
    }
}
