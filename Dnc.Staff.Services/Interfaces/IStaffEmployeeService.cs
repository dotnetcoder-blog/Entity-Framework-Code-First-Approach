using Dnc.Objects.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Interfaces
{
    public interface IStaffEmployeeService
    {
        Task<IEnumerable<StaffEmployee>> GetAllStaffEmployees();
        Task<IEnumerable<StaffEmployee>> GetAllEmployeesIncludeDepartmentAndProjects();
        Task<StaffEmployee> GetStaffEmployeeByKey(int key);
        Task<StaffEmployee> GetStaffEmployeeByKeyIncludeProjects(int key);
        Task<StaffEmployee> GetStaffEmployeeByKeyIncludeDepartmentAndProjects(int key);
        Task<IEnumerable<StaffEmployee>> GetStaffEmployeesByJob(string job);
        Task<IEnumerable<StaffEmployee>> GetStaffEmployeesByNameIncludeDepartmentAndProjects(string name);
        Task<int> AddStaffEmployee(StaffEmployee staffEmployee);
        Task<int> AddRangeStaffEmployees(IEnumerable<StaffEmployee> staffEmployees);
        Task<int> UpdateStaffEmployee(StaffEmployee staffEmployee);
        Task<int> UpdateRangeStaffEmployees(IEnumerable<StaffEmployee> staffEmployees);
        Task<int> DeleteStaffEmployee(StaffEmployee staffEmployee);
        Task<int> DeleteRangeStaffEmployees(IEnumerable<StaffEmployee> staffEmployees);
    }
}
