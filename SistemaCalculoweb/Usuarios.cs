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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        [DisplayName("Correo")]
        [Required(ErrorMessage = "El Correo es Obligatorio")]
        public string Correo { get; set; }
        [DisplayName("Nombres")]
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string ApellidoP { get; set; }
        [DisplayName("Apellido Materno")]
        public string ApellidoM { get; set; }
        [DisplayName("Rut")]
        public string Rut { get; set; }
        [DisplayName("Telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Seleccione Perfil")]
        [DisplayName("Perfil")]
        public Nullable<int> idPerfil { get; set; }
        [Required(ErrorMessage = "La constraseņa es obligatoria")]
        [DisplayName("Contraseņa")]
        public string Contrasenia { get; set; }
        [DisplayName("Confirmar Contraseņa")]
        [Compare("ConfirmPassword", ErrorMessage = "Las constraseņas no son iguales")]
        public string ConfirmPassword { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}