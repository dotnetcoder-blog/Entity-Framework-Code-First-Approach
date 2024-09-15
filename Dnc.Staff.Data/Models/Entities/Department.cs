using Dnc.Staff.Data.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dnc.Staff.Data.Models.Entities
{
    [EntityTypeConfiguration(typeof(DepartmentConfiguration))]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
