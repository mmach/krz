using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using Lips.Domain.Users;
using Lips.Domain.Clothes;
using Lips.Domain.Orders;

namespace Lips.Dal.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ClotheType> ClotheTypes { get; set; }
        public DbSet<ClothesTracking> ClothesTrackings { get; set; }
        public DbSet<OrderClothe> OrderClothes { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersTracking> OrdersTrackings { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<RegisterUser> RegisterUsers { get; set; }



        public BaseContext() 
            : base("BaseContext")
        {
            SetConfiguration();  
                     
        }

        public BaseContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

    }
}
