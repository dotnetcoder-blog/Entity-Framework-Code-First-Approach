using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Extensions
{
    internal static class DepartmentExtensions
    {
        public static StaffDepartment ToStaffDepartment(this Department department, bool basic = false)
        {
            if (department == null)
            {
                return null;
            }

            return new StaffDepartment
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location,
                StaffEmployees = basic ? null : department.Employees?.ToStaffEmployees(true)
            };
        }

        public static IEnumerable<StaffDepartment> ToStaffDepartments(this IEnumerable<Department> departments, bool basic = false)
        {
            return departments.Select(v=>v.ToStaffDepartment(basic));
        }

        public static Department ToDepartment(this StaffDepartment staffDepartment)
        {
            if (staffDepartment == null)
            {
                return null;
            }

            return new Department
            {
                Id = staffDepartment.Id,
                Name = staffDepartment.Name,
                Location = staffDepartment.Location,
                Employees = staffDepartment.StaffEmployees?.ToEmployees()
            };
        }

        public static IEnumerable<Department> ToDepartments(this IEnumerable<StaffDepartment> staffDepartments)
        {
            return staffDepartments.Select(v => v.ToDepartment());
        }
    }
}
