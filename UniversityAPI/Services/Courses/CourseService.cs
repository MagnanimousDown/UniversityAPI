using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseResponseVM>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructor)
                .Select(c => new CourseResponseVM
                {
                    CourseID = c.CourseID,
                    CourseNumber = c.CourseNumber,
                    CourseName = c.CourseName,
                    CourseDescription = c.CourseDescription,
                    CourseUnits = c.CourseUnits,
                    DepartmentName = c.Department.DepartmentName,
                    InstructorName = c.Instructor.FirstName + " " + c.Instructor.LastName
                }).ToListAsync();
        }

        public async Task<CourseResponseVM> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.CourseID == id);

            if (course == null)
            {
                return null;
            }

            return new CourseResponseVM
            {
                CourseID = course.CourseID,
                CourseNumber = course.CourseNumber,
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                CourseUnits = course.CourseUnits,
                DepartmentName = course.Department.DepartmentName,
                InstructorName = course.Instructor.FirstName + " " + course.Instructor.LastName
            };

        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(course.CourseID);
            if (existingCourse == null)
            {
                return null;
            }

            existingCourse.CourseNumber = course.CourseNumber;
            existingCourse.CourseName = course.CourseName;
            existingCourse.CourseDescription = course.CourseDescription;
            existingCourse.CourseUnits = course.CourseUnits;
            existingCourse.DepartmentID = course.DepartmentID;
            existingCourse.InstructorID = course.InstructorID;

            _context.Entry(existingCourse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingCourse;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if(course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
