using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Data.DesignTime
{
    public class StaffDbContextFactory : IDesignTimeDbContextFactory<StaffDbContext>
    {
        public StaffDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StaffDbContext>();
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Dnc-Staff-Database;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);
            return new StaffDbContext(optionsBuilder.Options);
        }
    }
}
