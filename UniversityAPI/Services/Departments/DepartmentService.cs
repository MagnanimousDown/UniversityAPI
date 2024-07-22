using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentGetVM>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentGetVM
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName,
                })
                .ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
