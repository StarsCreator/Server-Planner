﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CServer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CamozziEntities : DbContext
    {
        public CamozziEntities()
            : base("name=CamozziEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
