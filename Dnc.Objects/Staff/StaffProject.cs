using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Objects.Staff
{
    public class StaffProject
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public IEnumerable<StaffEmployee> StaffEmployees { get; set; }
    }
}
