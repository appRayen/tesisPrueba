﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CalculoEntities : DbContext
    {
        public CalculoEntities()
            : base("name=CalculoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CalculoHoras> CalculoHoras { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Servicio_Descripcion> Servicio_Descripcion { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacion { get; set; }
        public virtual DbSet<Calculo> Calculo { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<TipoTicket> TipoTicket { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Volumen_Ticket> Volumen_Ticket { get; set; }
    
        public virtual ObjectResult<SelectCalculos_Result> SelectCalculos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculos_Result>("SelectCalculos");
        }
    
        public virtual ObjectResult<SelectCalculos_Result> SelectCalculo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculos_Result>("SelectCalculo");
        }
    
        public virtual ObjectResult<SelectCalculos_Result> selectCal()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculos_Result>("selectCal");
        }
    
        public virtual ObjectResult<SelectCalculosPar_Result> SelectCalculosPar(Nullable<int> id, Nullable<int> id_serivicio)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var id_serivicioParameter = id_serivicio.HasValue ?
                new ObjectParameter("id_serivicio", id_serivicio) :
                new ObjectParameter("id_serivicio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculosPar_Result>("SelectCalculosPar", idParameter, id_serivicioParameter);
        }
    
        public virtual ObjectResult<SelectCalculosPar_Result> SelectCalculoPar(Nullable<int> id, Nullable<int> id_serivicio)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var id_serivicioParameter = id_serivicio.HasValue ?
                new ObjectParameter("id_serivicio", id_serivicio) :
                new ObjectParameter("id_serivicio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculosPar_Result>("SelectCalculoPar", idParameter, id_serivicioParameter);
        }
    
        public virtual int SelectCalculosId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SelectCalculosId", idParameter);
        }
    
        public virtual int SelectGrillaId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SelectGrillaId", idParameter);
        }
    
        public virtual ObjectResult<SelectCalculosPar_Result> grillaId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculosPar_Result>("grillaId", idParameter);
        }
    }
}
