using Dnc.Staff.Data.Models.Configuration;
using Dnc.Staff.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Data
{
    public class StaffDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Project> Projects => Set<Project>();

        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());
            new DepartmentConfiguration().Configure(modelBuilder.Entity<Department>());
            new ProjectConfiguration().Configure(modelBuilder.Entity<Project>());
        }
    }
}
