﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GestorFutbolEntities : DbContext
    {
        public GestorFutbolEntities()
            : base("name=GestorFutbolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<Torneo_Equipo> Torneo_Equipo { get; set; }
        public virtual DbSet<Torneo_Partido> Torneo_Partido { get; set; }
    }
}
