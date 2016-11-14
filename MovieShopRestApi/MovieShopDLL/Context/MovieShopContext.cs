using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Context
{
    public class MovieShopContext : DbContext
    {
        public MovieShopContext() : base("MovieShopDB")
        {
            Database.SetInitializer(new MovieShopDbInitializer());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Admin");

            //modelBuilder.Entity<Address>()
            //    .HasKey(a => a.Id);

            //modelBuilder.Entity<Customer>()
            //    .HasOptional(c => c.Address)
            //    .WithRequired(a => a.Customer);

            //modelBuilder.Entity<Movie>()
            //    .HasOptional<Genre>(m => m.Genre)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
        }
    }
}
