using Dnc.Objects.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Interfaces
{
    public interface IStaffDepartmentService
    {
        Task<IEnumerable<StaffDepartment>> GetStaffDepartments();
        Task<IEnumerable<StaffDepartment>> GetStaffDepartmentsIncludeEmployees();
        Task<StaffDepartment> FindStaffDepartment(int key);
        Task<IEnumerable<StaffDepartment>> FindStaffDepartmentByLocation(string location);
        Task<IEnumerable<StaffDepartment>> GetStaffDepartmentByNameIncludeEmployees(string name);
        Task<int> AddStaffDepartment(StaffDepartment staffDepartment);
        Task<int> AddRangeStaffDepartments(IEnumerable<StaffDepartment> staffDepartments);
        Task<int> UpdateStaffDepartment(StaffDepartment staffDepartment);
        Task<int> UpdateRangeStaffDepartments(IEnumerable<StaffDepartment> staffDepartments);
        Task<int> DeleteStaffDepartment(StaffDepartment staffDepartment);
        Task<int> DeleteRangeStaffDepartments(IEnumerable<StaffDepartment> staffDepartments);
    }
}
