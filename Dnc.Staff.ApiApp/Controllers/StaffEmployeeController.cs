using Dnc.Objects.Staff;
using Dnc.Staff.Data.Models.Entities;
using Dnc.Staff.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dnc.Staff.ApiApp.Controllers
{
    [Route("api/staffEmployees")]
    [ApiController]
    public class StaffEmployeeController(IStaffEmployeeService staffEmployeeService) : ControllerBase
    {
        private readonly IStaffEmployeeService staffEmployeeService = staffEmployeeService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffEmployee>>> GetAllStaffEmployees()
        {
            return Ok(await staffEmployeeService.GetAllStaffEmployees());
        }

        [HttpGet("with-department-and-projects")]
        public async Task<ActionResult<IEnumerable<StaffEmployee>>> GetAllEmployeesIncludeDepartmentAndProjects()
        {
            return Ok(await staffEmployeeService.GetAllEmployeesIncludeDepartmentAndProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffEmployee>> GetStaffEmployeeByKey(int id)
        {
            var employee =  await staffEmployeeService.GetStaffEmployeeByKey(id);
            if (employee == null) 
            {
                return NotFound();
            }

            return Ok(employee);   
        }

        [HttpGet("{id}/with-projects")]
        public async Task<ActionResult<StaffEmployee>> GetStaffEmployeeByKeyIncludeProjects(int id)
        {
            var employee = await staffEmployeeService.GetStaffEmployeeByKeyIncludeProjects(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("{id}/with-department-and-projects")]
        public async Task<ActionResult<StaffEmployee>> GetStaffEmployeeByKeyIncludeDepartmentAndProjects(int id)
        {
            var employee = await staffEmployeeService.GetStaffEmployeeByKeyIncludeDepartmentAndProjects(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("by-job/{job}")]
        public async Task<ActionResult<IEnumerable<StaffEmployee>>> GetStaffEmployeesByJob(string job)
        {
            var employees = await staffEmployeeService.GetStaffEmployeesByJob(job);
            if (!employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpGet("by-name/{name}/with-department-and-projects")]
        public async Task<ActionResult<IEnumerable<StaffEmployee>>> GetStaffEmployeesByNameIncludeDepartmentAndProjects(string name)
        {
            var employees = await staffEmployeeService.GetStaffEmployeesByNameIncludeDepartmentAndProjects(name);
            if (!employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStaffEmployee(StaffEmployee staffEmployee)
        {
            var effected = await staffEmployeeService.AddStaffEmployee(staffEmployee);

            if(effected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("range")]
        public async Task<ActionResult> CreateStaffEmployees(IEnumerable<StaffEmployee> staffEmployees)
        {
            var effected = await staffEmployeeService.AddRangeStaffEmployees(staffEmployees);

            if (effected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStaffEmployee(StaffEmployee staffEmployee)
        {
            var effected =  await staffEmployeeService.UpdateStaffEmployee(staffEmployee);

            if (effected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("range")]
        public async Task<ActionResult> UpdateStaffEmployees(IEnumerable<StaffEmployee> staffEmployees)
        {
            var effected =  await staffEmployeeService.UpdateRangeStaffEmployees(staffEmployees);

            if (effected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStaffEmployee(StaffEmployee staffEmployee)
        {
            var effected = await staffEmployeeService.DeleteStaffEmployee(staffEmployee);

            if (effected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("range")]
        public async Task<ActionResult> DeleteStaffEmployees(IEnumerable<StaffEmployee> staffEmployees)
        {
            var effected =  await staffEmployeeService.DeleteRangeStaffEmployees(staffEmployees);

            if (effected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
