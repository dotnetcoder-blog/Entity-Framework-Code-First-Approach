using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services.Extensions
{
    internal static class ProjectExtensions
    {
        public static StaffProject ToStaffProject(this Project project)
        {
            if (project == null)
            {
                return null;
            }

            return new StaffProject
            {
                Id = project.Id,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                //StaffEmployees = project.Employees?.ToStaffEmployees()
            };
        }

        public static IEnumerable<StaffProject> ToStaffProjects(this IEnumerable<Project> projects)
        {
            return projects.Select(v => v.ToStaffProject());
        }

        public static Project ToProject(this StaffProject staffProject)
        {
            if (staffProject == null)
            {
                return null;
            }

            return new Project
            {
                Id = staffProject.Id,
                StartDate = staffProject.StartDate,
                EndDate = staffProject.EndDate,
                //Employees = staffProject.StaffEmployees?.ToEmployees()
            };
        }

        public static IEnumerable<Project> ToProjects(this IEnumerable<StaffProject> staffProjects)
        {
            return staffProjects.Select(v => v.ToProject());
        }
    }
}
