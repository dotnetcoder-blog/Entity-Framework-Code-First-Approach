using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using Dnc.Staff.Repository.Interfaces;
using Dnc.Staff.Services.Extensions;
using Dnc.Staff.Services.Interfaces;
using Dnc.Staff.Services.Utilities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Services
{
    public class StaffEmployeeService(IGenericRepository<Employee> employeeRepository) : IStaffEmployeeService
    {
        private readonly IGenericRepository<Employee> employeeRepository = employeeRepository;

        private readonly Expression<Func<Employee, object>>[] includeProjects =
            ExpressionBuilder.BuildExpressions<Employee>([nameof(Employee.Projects)]);

        private readonly Expression<Func<Employee, object>>[] includeDepartmentAndProjects =
            ExpressionBuilder.BuildExpressions<Employee>([nameof(Employee.Department), nameof(Employee.Projects)]);


        public async Task<IEnumerable<StaffEmployee>> GetAllStaffEmployees()
        {
            var employees = await employeeRepository.GetAllAsync();
            return employees?.ToStaffEmployees();
        }
        public async Task<IEnumerable<StaffEmployee>> GetAllEmployeesIncludeDepartmentAndProjects()
        {
            var employees = await employeeRepository.GetAllIncludeAsync(includeDepartmentAndProjects);
            return employees?.ToStaffEmployees();
        }
        public async Task<StaffEmployee> GetStaffEmployeeByKey(int key)
        {
            var employee = await employeeRepository.FindByKey(key);
            return employee?.ToStaffEmployee();
        }
        public async Task<StaffEmployee> GetStaffEmployeeByKeyIncludeProjects(int key)
        {
            var employees = await employeeRepository.GetByIncludeAsync(v => v.Id == key, includeProjects);
            var employee = employees?.SingleOrDefault();
            return employee?.ToStaffEmployee();
        }
        public async Task<StaffEmployee> GetStaffEmployeeByKeyIncludeDepartmentAndProjects(int key)
        {
            var employees = await employeeRepository.GetByIncludeAsync(v => v.Id == key, includeDepartmentAndProjects);
            var employee = employees?.SingleOrDefault();
            return employee?.ToStaffEmployee();
        }
        public async Task<IEnumerable<StaffEmployee>> GetStaffEmployeesByJob(string job)
        {
            var employees = await employeeRepository.FindByAsync(v => v.Job == job);
            return employees?.ToStaffEmployees();
        }
        public async Task<IEnumerable<StaffEmployee>> GetStaffEmployeesByNameIncludeDepartmentAndProjects(string name)
        {
            var employees = await employeeRepository.GetByIncludeAsync(v => v.Name == name, includeDepartmentAndProjects);
            return employees?.ToStaffEmployees();
        }
        public async Task<int> AddStaffEmployee(StaffEmployee staffEmployee)
        {
            return await employeeRepository.AddAsync(staffEmployee.ToEmployee());
        }
        public async Task<int> AddRangeStaffEmployees(IEnumerable<StaffEmployee> staffEmployees)
        {
            return await employeeRepository.AddRangeAsync(staffEmployees.ToEmployees());
        }
        public async Task<int> UpdateStaffEmployee(StaffEmployee staffEmployee)
        {
            return await employeeRepository.UpdateAsync(staffEmployee.ToEmployee());
        }
        public async Task<int> UpdateRangeStaffEmployees(IEnumerable<StaffEmployee> staffEmployees)
        {
            return await employeeRepository.UpdateRangeAsync(staffEmployees.ToEmployees());
        }
        public async Task<int> DeleteStaffEmployee(StaffEmployee staffEmployee)
        {
            return await employeeRepository.DeleteAsync(staffEmployee.ToEmployee());
        }
        public async Task<int> DeleteRangeStaffEmployees(IEnumerable<StaffEmployee> staffEmployees)
        {
            return await employeeRepository.DeleteRangeAsync(staffEmployees.ToEmployees());
        }
    }
}
