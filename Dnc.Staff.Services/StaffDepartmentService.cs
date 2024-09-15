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
    public class StaffDepartmentService(IGenericRepository<Department> departmentRepository) : IStaffDepartmentService
    {
        private readonly IGenericRepository<Department> departmentRepository = departmentRepository;

        private readonly Expression<Func<Department, object>>[] includeEmployees =
            ExpressionBuilder.BuildExpressions<Department>([nameof(Department.Employees)]);

        public async Task<IEnumerable<StaffDepartment>> GetStaffDepartments()
        {
            var departments = await departmentRepository.GetAllAsync();
            return departments?.ToStaffDepartments();
        }

        public async Task<IEnumerable<StaffDepartment>> GetStaffDepartmentsIncludeEmployees()
        {
            var departments = await departmentRepository.GetAllIncludeAsync(includeEmployees);
            return departments?.ToStaffDepartments();
        }

        public async Task<StaffDepartment> FindStaffDepartment(int key)
        {
            var department = await departmentRepository.FindByKey(key);
            return department?.ToStaffDepartment();
        }

        public async Task<IEnumerable<StaffDepartment>> FindStaffDepartmentByLocation(string location)
        {
            var departments = await departmentRepository.FindByAsync(v => v.Location == location);
            return departments?.ToStaffDepartments();
        }

        public async Task<IEnumerable<StaffDepartment>> GetStaffDepartmentByNameIncludeEmployees(string name)
        {
            var departments = await departmentRepository.GetByIncludeAsync(v => v.Name == name, includeEmployees);
            return departments?.ToStaffDepartments();
        }

        public async Task<int> AddStaffDepartment(StaffDepartment staffDepartment)
        {
            return await departmentRepository.AddAsync(staffDepartment.ToDepartment());
        }

        public async Task<int> AddRangeStaffDepartments(IEnumerable<StaffDepartment> staffDepartments)
        {
            return await departmentRepository.AddRangeAsync(staffDepartments.ToDepartments());
        }

        public async Task<int> UpdateStaffDepartment(StaffDepartment staffDepartment)
        {
            return await departmentRepository.UpdateAsync(staffDepartment.ToDepartment());
        }

        public async Task<int> UpdateRangeStaffDepartments(IEnumerable<StaffDepartment> staffDepartments)
        {
            return await departmentRepository.UpdateRangeAsync(staffDepartments.ToDepartments());
        }

        public async Task<int> DeleteStaffDepartment(StaffDepartment staffDepartment)
        {
            return await departmentRepository.DeleteAsync(staffDepartment.ToDepartment());
        }

        public async Task<int> DeleteRangeStaffDepartments(IEnumerable<StaffDepartment> staffDepartments)
        {
            return await departmentRepository.DeleteRangeAsync(staffDepartments.ToDepartments());
        }
    }
}
