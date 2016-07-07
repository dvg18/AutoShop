using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class AutoShopContext : DbContext
    {
        public AutoShopContext() : base("AutoShopEntities") { }

        public DbSet<Services> Services { get; set; }
        public DbSet<Actia> Action { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Contact> Contact { get; set; }


    }
}