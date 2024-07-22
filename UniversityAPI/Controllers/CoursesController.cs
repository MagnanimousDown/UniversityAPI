using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Services.Courses;
using UniversityAPI.Services.Instructors;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponseVM>>> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();

            /*
            var _courses = courses.Select(c => new Course
            {
                CourseID = c.CourseID,
                CourseNumber = c.CourseNumber,
                CourseName = c.CourseName,
                CourseDescription = c.CourseDescription,
                CourseUnits = c.CourseUnits,
                DepartmentID = c.DepartmentID,
                InstructorID = c.InstructorID
            });
            */
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponseVM>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseResponseVM>> PostCourse(CourseCreateVM courseVM)
        {
            var course = new Course
            {
                CourseNumber = courseVM.CourseNumber,
                CourseName = courseVM.CourseName,
                CourseDescription = courseVM.CourseDescription,
                CourseUnits = courseVM.CourseUnits,
                DepartmentID = courseVM.DepartmentID,
                InstructorID = courseVM.InstructorID
            };


            var createdCourse = await _courseService.AddCourseAsync(course);
            var courseResponse = await _courseService.GetCourseByIdAsync(createdCourse.CourseID);
            
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.CourseID }, courseResponse);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseResponseVM>> PutCourse(int id, CourseUpdateVM courseVM)
        {
            if (id != courseVM.CourseID)
            {
                return BadRequest();
            }

            var course = new Course
            {
                CourseID = courseVM.CourseID,
                CourseNumber = courseVM.CourseNumber,
                CourseName = courseVM.CourseName,
                CourseDescription = courseVM.CourseDescription,
                CourseUnits = courseVM.CourseUnits,
                DepartmentID = courseVM.DepartmentID,
                InstructorID = courseVM.InstructorID
            };

            var updatedCourse = await _courseService.UpdateCourseAsync(course);

            if (updatedCourse == null)
            {
                return NotFound();
            }

            var courseResponse = await _courseService.GetCourseByIdAsync(updatedCourse.CourseID);
            return Ok(courseResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
