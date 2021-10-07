using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementAsp.Models
{
    public class ManagementDBContext : DbContext
    {
        public ManagementDBContext() : base("QuanLyDBConnectionString")
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }

        public DbSet<Transaction> transactions { get; set; }
    }
}