using CodeFirst.Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.Repository
{
    public class CodeFirstDataContext : DbContext
    {
        public CodeFirstDataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<UsersRole> UserRoles { get; set; }
        public DbSet<UsersInfo> UsersInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bills> PrintBills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}