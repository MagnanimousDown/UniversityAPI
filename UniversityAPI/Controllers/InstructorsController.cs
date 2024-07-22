using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Services.Instructors;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {

        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorGetVM>>> GetInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            var instructorVMs = instructors.Select(i => new InstructorGetVM
            {
                InstructorID = i.InstructorID,
                LastName = i.LastName,
                FirstName = i.FirstName,
                Status = i.Status,
                HireDate = i.HireDate,
                AnnualSalary = i.AnnualSalary,
                DepartmentID = i.DepartmentID
            }).ToList();

            return Ok(instructorVMs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);

        }

        [HttpPost]
        public async Task<ActionResult<InstructorWithDepartmentVM>> PostInstructor(InstructorCreateVM instructorVM)
        {

            var instructor = new Instructor
            {
                LastName = instructorVM.LastName,
                FirstName = instructorVM.FirstName,
                Status = instructorVM.Status,
                HireDate = instructorVM.HireDate,
                AnnualSalary = instructorVM.AnnualSalary,
                DepartmentID = instructorVM.DepartmentID
            };

            var createdInstructor = await _instructorService.AddInstructorAsync(instructor);

            var response = new InstructorWithDepartmentVM
            {
                InstructorID = createdInstructor.InstructorID,
                LastName = createdInstructor.LastName,
                FirstName = createdInstructor.FirstName,
                Status = createdInstructor.Status,
                HireDate = createdInstructor.HireDate,
                AnnualSalary = createdInstructor.AnnualSalary,
                DepartmentID = createdInstructor.DepartmentID,
                DepartmentName = createdInstructor.Department.DepartmentName
            };
            
            return CreatedAtAction(nameof(GetInstructor), new { id = response.InstructorID }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, InstructorPutVM instructorVM)
        {

            if (id != instructorVM.InstructorID)
            {
                return BadRequest();
            }

            var updatedInstructor = await _instructorService.UpdateInstructorAsync(instructorVM);

            if (updatedInstructor == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var result = await _instructorService.DeleteInstructorAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
