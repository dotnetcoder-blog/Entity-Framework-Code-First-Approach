using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Objects.Staff
{
    public class StaffEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public int StaffDepartmentId { get; set; }
        public StaffDepartment StaffDepartment { get; set; }
        public StaffEmployee Manager { get; set; }
        public IEnumerable<StaffProject> StaffProjects { get; set; }
    }
}
