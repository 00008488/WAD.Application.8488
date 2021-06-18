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
            Database.EnsureCreated();
        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
