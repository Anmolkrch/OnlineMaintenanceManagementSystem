﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quiz.Core.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeMGMTEntities : DbContext
    {
        public EmployeeMGMTEntities()
            : base("name=EmployeeMGMTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<ServiceRequestStatu> ServiceRequestStatus { get; set; }
        public virtual DbSet<tblEngineer> tblEngineers { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductMaintenance> tblProductMaintenances { get; set; }
        public virtual DbSet<tblProductType> tblProductTypes { get; set; }
        public virtual DbSet<tblSpairPart> tblSpairParts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    
        public virtual int spGetUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spGetUsers");
        }
    }
}
