using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Objects.Staff
{
    public class StaffDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<StaffEmployee> StaffEmployees { get; set; }
    }
}
