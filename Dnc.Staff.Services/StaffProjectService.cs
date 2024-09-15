using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using Dnc.Staff.Repository.Interfaces;
using Dnc.Staff.Services.Extensions;
using Dnc.Staff.Services.Interfaces;
using Dnc.Staff.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services
{
    public class StaffProjectService(IGenericRepository<Project> projectRepository) : IStaffProjectService
    {
        private readonly IGenericRepository<Project> projectRepository = projectRepository;

        private readonly Expression<Func<Project, object>>[] includeEmployees =
            ExpressionBuilder.BuildExpressions<Project>([nameof(Project.Employees)]);


        public async Task<IEnumerable<StaffProject>> GetAllStaffProjects()
        {
            var projects = await projectRepository.GetAllAsync();
            return projects?.ToStaffProjects();
        }

        public async Task<IEnumerable<StaffProject>> GetAllStaffProjectsIncludeEmployees()
        {
            var projects = await projectRepository.GetAllIncludeAsync(includeEmployees);
            return projects?.ToStaffProjects();
        }

        public async Task<StaffProject> GetStaffProjectByKey(int key)
        {
            var project = await projectRepository.FindByKey(key);
            return project?.ToStaffProject();
        }

        public async Task<IEnumerable<StaffProject>> GetStaffProjectsByStartDate(DateOnly startDate)
        {
            var projects = await projectRepository.FindByAsync(v=>v.StartDate == startDate);
            return projects?.ToStaffProjects();
        }

        public async Task<IEnumerable<StaffProject>> GetStaffProjectsByEndDateIncludeEmployees(DateOnly endDate)
        {
            var projects = await projectRepository.GetByIncludeAsync(v => v.EndDate == endDate, includeEmployees);  
            return projects?.ToStaffProjects();
        }

        public async Task<int> CreateStaffProject(StaffProject staffProject)
        {
            return await projectRepository.AddAsync(staffProject.ToProject());    
        }

        public async Task<int> CreateStaffProjects(IEnumerable<StaffProject> staffProjects)
        {
            return await projectRepository.AddRangeAsync(staffProjects.ToProjects());
        }

        public Task<int> DeleteStaffProject(StaffProject staffProject)
        {
            return projectRepository.DeleteAsync(staffProject.ToProject());
        }

        public async Task<int> DeleteStaffProjects(IEnumerable<StaffProject> staffProjects)
        {
            return await projectRepository.DeleteRangeAsync(staffProjects.ToProjects());
        }

        public Task<int> UpdateStaffProject(StaffProject staffProject)
        {
            return projectRepository.UpdateAsync(staffProject.ToProject());
        }

        public async Task<int> UpdateStaffProjects(IEnumerable<StaffProject> staffProjects)
        {
            return await projectRepository.UpdateRangeAsync(staffProjects.ToProjects());
        }
    }
}
