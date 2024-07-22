using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.ViewModels;
using UniversityAPI.Services.Students;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;


        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseVM>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseVM>> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentCreateVM studentVM)
        {
            var createdStudent = await _studentService.AddStudentAsync(studentVM);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentID }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            var updatedStudent = await _studentService.UpdateStudentAsync(student);
            if (updatedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
