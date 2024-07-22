using UniversityAPI.Models;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentGetVM>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int id);

    }
}
