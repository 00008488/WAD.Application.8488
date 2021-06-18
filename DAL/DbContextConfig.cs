using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbContextConfig : DbContext
    {
        public DbContextConfig(DbContextOptions<DbContextConfig> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Department>().HasData(
                new Department { 
                    Id = "sv56745",
                    Name = "HR"
                },
                new Department
                {
                    Id = "32r4t5g",
                    Name = "Accounting"
                },
                new Department
                {
                    Id = "876tyhr",
                    Name = "Marketing"
                },
                new Department
                {
                    Id = "j5r6tgw",
                    Name = "IT"
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = "56hytrg",
                    Name = "Jack Daniels",
                    DepartmentId = "sv56745",
                    Dob = DateTime.Now
                },
                new Employee
                {
                    Id = "324tr34ef",
                    Name = "Admin",
                    DepartmentId = "j5r6tgw",
                    Dob = DateTime.Now
                }
            );
        }

    }
}
