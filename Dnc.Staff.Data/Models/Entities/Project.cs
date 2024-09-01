using Dnc.Staff.Data.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Data.Models.Entities
{
    [EntityTypeConfiguration(typeof(ProjectConfiguration))]
    public class Project
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

    }
}
