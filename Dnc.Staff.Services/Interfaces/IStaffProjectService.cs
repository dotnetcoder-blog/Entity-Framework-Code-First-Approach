using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Interfaces
{
    public interface IStaffProjectService
    {
        Task<IEnumerable<StaffProject>> GetAllStaffProjects();
        Task<IEnumerable<StaffProject>> GetAllStaffProjectsIncludeEmployees();
        Task<StaffProject> GetStaffProjectByKey(int key);
        Task<IEnumerable<StaffProject>> GetStaffProjectsByStartDate(DateOnly startDate);
        Task<IEnumerable<StaffProject>> GetStaffProjectsByEndDateIncludeEmployees(DateOnly endDate);
        Task<int> CreateStaffProject(StaffProject staffProject);
        Task<int> CreateStaffProjects(IEnumerable<StaffProject> staffProjects);
        Task<int> UpdateStaffProject(StaffProject staffProject);
        Task<int> UpdateStaffProjects(IEnumerable<StaffProject> staffProjects);
        Task<int> DeleteStaffProject(StaffProject staffProject);
        Task<int> DeleteStaffProjects(IEnumerable<StaffProject> staffProjects);
    }
}
