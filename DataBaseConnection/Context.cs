using System;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Search-path för däär filen ligger med olika filmer och information angående filmerna.
        {
            optionsBuilder
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server=.\SQLExpress;" +
                @"database=DataLagringProjektArbete;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Test/ändrig för tables innehåll.
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                Firstname = "Alan",
                Lastname = "Weik",
                Age = 12,
                Email = "AlanWeik@gmail.com"
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "Lord of the rings ",
                Genre = "Fantasy",
                ImageURL = (@"..\..\..\SeedData\MovieGenre.csv")
                
        });

            modelBuilder.Entity<Rental>().HasData(new Rental
            {
                Id = 1,
                Date = DateTime.Now,
            });
        }
    }
}
