//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaCalculoweb
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoInfraestructura
    {
        public TipoInfraestructura()
        {
            this.CalculosResultados = new HashSet<CalculosResultados>();
        }
    
        public int idTipoInfraesteructura { get; set; }
        public string descripcion { get; set; }
        public Nullable<short> estado { get; set; }
    
        public virtual ICollection<CalculosResultados> CalculosResultados { get; set; }
    }
}
