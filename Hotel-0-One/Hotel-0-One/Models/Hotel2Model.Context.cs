﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_0_One.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hotel2Entities : DbContext
    {
        public Hotel2Entities()
            : base("name=Hotel2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ListaHabitaciones> ListaHabitaciones { get; set; }
        public virtual DbSet<ListaServicios> ListaServicios { get; set; }
        public virtual DbSet<ListaUsuario> ListaUsuario { get; set; }
        public virtual DbSet<RegistroDeUsuarios> RegistroDeUsuarios { get; set; }
        public virtual DbSet<Reservaciones> Reservaciones { get; set; }
    }
}