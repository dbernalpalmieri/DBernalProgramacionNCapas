//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroExterior { get; set; }
        public int IdColonia { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Colonia Colonia { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}