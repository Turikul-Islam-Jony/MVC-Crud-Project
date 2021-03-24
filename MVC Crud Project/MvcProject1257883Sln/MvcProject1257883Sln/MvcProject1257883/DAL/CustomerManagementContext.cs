using MvcProject1257883.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProject1257883.Context
{
    public partial class CustomerManagementContext: DbContext
    {
        public CustomerManagementContext(): base("name=CustomerManagementContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<tblUser> TblUsers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<tblRole> TblRoles { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }

    }
}