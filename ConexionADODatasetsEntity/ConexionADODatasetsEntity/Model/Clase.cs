//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConexionADODatasetsEntity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clase
    {
        public int id { get; set; }
        public Nullable<int> idEstudiante { get; set; }
        public string nombreClase { get; set; }
    
        public virtual Nombres Nombres { get; set; }
    }
}
