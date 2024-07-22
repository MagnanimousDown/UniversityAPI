using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Services.Departments;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentGetVM>>> GetDepartments()
        {
            return Ok(await _departmentService.GetAllDepartmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(DepartmentCreateVM departmentVM)
        {

            var department = new Department
            {
                DepartmentName = departmentVM.DepartmentName
            };

            var createdDepartment = await _departmentService.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = createdDepartment.DepartmentID }, createdDepartment);

        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentPutVM departmentVM)
        {
            if (id != departmentVM.DepartmentID)
            {
                return BadRequest();
            }

            var department = new Department
            {
                DepartmentID = id,
                DepartmentName = departmentVM.DepartmentName
            };

            var updatedDepartment = await _departmentService.UpdateDepartmentAsync(department);
            if (updatedDepartment == null)
            {
                return NotFound();
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
