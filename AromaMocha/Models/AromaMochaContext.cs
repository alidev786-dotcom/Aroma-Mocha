using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace AromaMocha.Models
{
    public class AromaMochaContext: DbContext
    {
        public AromaMochaContext() : base("name=AromaMochaConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AromaMochaContext>());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CafeTable> CafeTables { get; set; }  
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}