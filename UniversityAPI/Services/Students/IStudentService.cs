using UniversityAPI.ViewModels;
using UniversityAPI.Models;

namespace UniversityAPI.Services.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseVM>> GetAllStudentsAsync();
        Task<StudentResponseVM> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(StudentCreateVM studentVM);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);

    }
}
