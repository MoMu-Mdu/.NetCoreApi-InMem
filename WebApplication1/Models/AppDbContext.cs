using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person() { Id = 1, GivenName = "Peter", FamilyName = "Casey", Age = 61, Address = "LondonDerry" },
                new Person() { Id = 2, GivenName = "Liadh", FamilyName = "Riada", Age = 51, Address = "Dublin" },
                new Person() { Id = 3, GivenName = "Michael", FamilyName = "Higgins", Age = 77, Address = "Limerick" });
        }
    }
}
