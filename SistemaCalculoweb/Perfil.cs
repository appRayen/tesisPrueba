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
    
    public partial class Perfil
    {
        public Perfil()
        {
            this.Usuario = new HashSet<Usuario>();
        }
    
        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }
        public short estado { get; set; }
        public string contraseña { get; set; }
    
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
