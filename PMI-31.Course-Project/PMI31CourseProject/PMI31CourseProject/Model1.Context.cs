﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMI31CourseProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Course_ProjectEntities1 : DbContext
    {
        public Course_ProjectEntities1()
            : base("name=Course_ProjectEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<Graduates_image> Graduates_image { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Lecturer_image> Lecturer_image { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}