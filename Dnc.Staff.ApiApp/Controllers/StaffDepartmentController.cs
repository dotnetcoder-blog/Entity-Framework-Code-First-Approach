using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using Dnc.Staff.Repository.Interfaces;
using Dnc.Staff.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dnc.Staff.ApiApp.Controllers
{
    [Route("api/staffDepartment")]
    [ApiController]
    public class StaffDepartmentController(IStaffDepartmentService staffDepartmentRepository) : ControllerBase
    {
        private readonly IStaffDepartmentService staffDepartmentRepository = staffDepartmentRepository;

        [HttpGet("all")]
        public async Task<IEnumerable<StaffDepartment>> GetAllStaffDepartments()
        {
            return await staffDepartmentRepository.GetStaffDepartments();
        }

        [HttpGet("all/with-employees")]
        public async Task<IEnumerable<StaffDepartment>> GetStaffDepartmentsIncludeEmployees()
        {
            return await staffDepartmentRepository.GetStaffDepartmentsIncludeEmployees();
        }

        [HttpGet("{departmentId}")]
        public async Task<StaffDepartment> GetStaffDepartmentByKey(int departmentId)
        {
            return await staffDepartmentRepository.FindStaffDepartment(departmentId);
        }

        [HttpGet("by-location/{location}")]
        public async Task<IEnumerable<StaffDepartment>> FindStaffDepartmentByLocation(string location)
        {
            return await staffDepartmentRepository.FindStaffDepartmentByLocation(location);
        }

        [HttpGet("by-name/{name}/with-employees")]
        public async Task<IEnumerable<StaffDepartment>> GetStaffDepartmentByNameIncludeEmployees(string name)
        {
            return await staffDepartmentRepository.GetStaffDepartmentByNameIncludeEmployees(name);
        }

        [HttpPost]
        public async Task<int> CreateStaffDepartment([FromBody] StaffDepartment staffDepartment)
        {
            return await staffDepartmentRepository.AddStaffDepartment(staffDepartment);
        }

        [HttpPost("range")]
        public async Task<int> CreateStaffDepartments(IEnumerable<StaffDepartment> staffDepartments)
        {
            return await staffDepartmentRepository.AddRangeStaffDepartments(staffDepartments);
        }

        [HttpPut]
        public async Task<int> UpdateStaffDepartment(StaffDepartment staffDepartment)
        {
            return await staffDepartmentRepository.UpdateStaffDepartment(staffDepartment);
        }

        [HttpPut("range")]
        public async Task<int> UpdateStaffDepartments(IEnumerable<StaffDepartment> staffDepartments)
        {
            return await staffDepartmentRepository.UpdateRangeStaffDepartments(staffDepartments);
        }

        [HttpDelete]
        public async Task<int> DeleteStaffDepartment(StaffDepartment staffDepartment)
        {
            return await staffDepartmentRepository.DeleteStaffDepartment(staffDepartment);
        }

        [HttpDelete("range")]
        public async Task<int> DeleteStaffDepartments(IEnumerable<StaffDepartment> staffDepartments)
        {
            return await staffDepartmentRepository.DeleteRangeStaffDepartments(staffDepartments);
        }
    }
}
