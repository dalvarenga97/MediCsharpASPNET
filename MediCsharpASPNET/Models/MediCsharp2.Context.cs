﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediCsharpASPNET.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MediCsharp2Entities1 : DbContext
    {
        public MediCsharp2Entities1()
            : base("name=MediCsharp2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Reposo> Reposo { get; set; }
    }
}