﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrameworkApp.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThesisEntities : DbContext
    {
        public ThesisEntities()
            : base("name=ThesisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TestTable> TestTable { get; set; }
        public virtual DbSet<RandomNumber> RandomNumber { get; set; }
        public virtual DbSet<RandomObject> RandomObject { get; set; }
        public virtual DbSet<Seed> Seed { get; set; }
    }
}
