﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnockAndCheckHF.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KnockAndCheckDBEntities : DbContext
    {
        public KnockAndCheckDBEntities()
            : base("name=KnockAndCheckDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Checkup> Checkups { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
    }
}