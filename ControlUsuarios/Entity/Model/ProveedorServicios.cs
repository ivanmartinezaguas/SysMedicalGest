//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlUsuarios.Entity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProveedorServicios
    {
        public ProveedorServicios()
        {
            this.Pacientes = new HashSet<Pacientes>();
        }
    
        public int id { get; set; }
        public System.DateTime fechaInicio { get; set; }
        public System.DateTime fechafin { get; set; }
        public string codigoTipoContrato { get; set; }
        public int tipoRegimen { get; set; }
        public string nombreEps { get; set; }
        public int idTiposContrato { get; set; }
        public int idTipoProveedor { get; set; }
        public int usuarioId { get; set; }
    
        public virtual ICollection<Pacientes> Pacientes { get; set; }
        public virtual TiposContratos TiposContratos { get; set; }
        public virtual TiposProveedorServicios TiposProveedorServicios { get; set; }
    }
}