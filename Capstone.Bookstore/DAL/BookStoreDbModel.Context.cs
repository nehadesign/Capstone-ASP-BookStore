﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capstone.Bookstore.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbBookStoreEntities : DbContext
    {
        public dbBookStoreEntities()
            : base("name=dbBookStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Tbl_Cart> Tbl_Cart { get; set; }
        public DbSet<Tbl_CartStatus> Tbl_CartStatus { get; set; }
        public DbSet<Tbl_Category> Tbl_Category { get; set; }
        public DbSet<Tbl_MemberRole> Tbl_MemberRole { get; set; }
        public DbSet<Tbl_Members> Tbl_Members { get; set; }
        public DbSet<Tbl_Product> Tbl_Product { get; set; }
        public DbSet<Tbl_Roles> Tbl_Roles { get; set; }
        public DbSet<Tbl_SlideImage> Tbl_SlideImage { get; set; }
        public DbSet<Tbl_ShippingDetails> Tbl_ShippingDetails { get; set; }
    }
}