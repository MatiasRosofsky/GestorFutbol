//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorFutbol.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Torneo_Equipo
    {
        public int ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Torneo_ID { get; set; }
    
        public virtual Equipo Equipo { get; set; }
        public virtual Torneo Torneo { get; set; }
    }
}
