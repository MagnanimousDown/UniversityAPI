using UniversityAPI.Models;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Services.Instructors
{
    public interface IInstructorService
    {
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();

        Task<Instructor> GetInstructorByIdAsync(int id);

        Task<Instructor> AddInstructorAsync(Instructor instructor);

        Task<Instructor> UpdateInstructorAsync(InstructorPutVM instructorVM);

        Task<bool> DeleteInstructorAsync(int id);


    }
}
