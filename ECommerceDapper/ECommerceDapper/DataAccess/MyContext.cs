using ECommerceDapper.Domain.Entities;
using ECommerceDapper.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base(@"Data Source=DESKTOP-VNMLSV1\LESSON;Initial Catalog=ECommerceDapperDb;User ID=omer;Password=11804;")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());

            modelBuilder.Entity<Order>()
                .HasOptional<Product>(p => p.Product)
                .WithMany()
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>()
                .HasOptional<User>(p => p.User)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}
