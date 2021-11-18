using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "johnhastings@kuviocreative.com",
                Country = "Canada",
                DateOfBirth = new DateTime(1980, 10, 5),
                Age = 41
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "samgalloway@kuviocreative.com",
                Country = "USA",
                DateOfBirth = new DateTime(1981, 12, 22),
                Age = 39
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "saralongway@kuviocreative.com",
                Country = "Ireland",
                DateOfBirth = new DateTime(1982, 9, 23),
                Age = 39
            });
        }
    }
}
