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
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class TipoOperacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoOperacion()
        {
            this.CalculoHoras = new HashSet<CalculoHoras>();
        }
    
        public int idTipoOperacion { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        public short estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalculoHoras> CalculoHoras { get; set; }
    }
}
