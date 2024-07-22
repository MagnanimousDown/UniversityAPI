using UniversityAPI.Models;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Services.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseVM>> GetAllCoursesAsync();
        Task<CourseResponseVM> GetCourseByIdAsync(int id);
        Task<Course> AddCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
    }
}
