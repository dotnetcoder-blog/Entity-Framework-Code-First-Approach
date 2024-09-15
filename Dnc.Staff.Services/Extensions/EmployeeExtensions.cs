using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Extensions
{
    public static class EmployeeExtensions
    {
        public static StaffEmployee ToStaffEmployee(this Employee employee,bool basic = false)
        {
            if (employee == null)
            {
                return null;
            }

            return new StaffEmployee
            {
                Id = employee.Id,
                Name = employee.Name,
                HireDate = employee.HireDate,
                Job = employee.Job,
                Salary = employee.Salary,
                ManagerId = employee.ManagerId ?? 0,
                StaffDepartment = basic ? null : employee.Department.ToStaffDepartment(true),
                StaffDepartmentId = employee.DepartmentId,
                StaffProjects = employee.Projects?.ToStaffProjects()
            };
        }

        public static IEnumerable<StaffEmployee> ToStaffEmployees(this IEnumerable<Employee> employees, bool basic = false)
        {
            return employees.Select(v => v.ToStaffEmployee(basic));
        }

        public static Employee ToEmployee(this StaffEmployee staffEmployee)
        {
            if (staffEmployee == null)
            {
                return null;
            }

            return new Employee
            {
                Id = staffEmployee.Id,
                Name = staffEmployee.Name,
                HireDate = staffEmployee.HireDate,
                Job = staffEmployee.Job,
                Salary = staffEmployee.Salary,
                ManagerId = staffEmployee.ManagerId,
                DepartmentId = staffEmployee.StaffDepartmentId,
                Projects = staffEmployee.StaffProjects?.ToProjects()
            };
        }

        public static IEnumerable<Employee> ToEmployees(this IEnumerable<StaffEmployee> staffEmployees)
        {
            return staffEmployees.Select(v => v.ToEmployee());
        }
    }
}
