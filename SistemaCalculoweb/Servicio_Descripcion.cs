//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaCalculoweb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicio_Descripcion
    {
        public Servicio_Descripcion()
        {
            this.CalculoHoras = new HashSet<CalculoHoras>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Id_Servicio { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<CalculoHoras> CalculoHoras { get; set; }
        public virtual Servicios Servicios { get; set; }
    }
}
