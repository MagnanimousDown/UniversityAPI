using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Models;
using UniversityAPI.ViewModels;

namespace UniversityAPI.Services.Instructors
{
    public class InstructorService : IInstructorService
    {
        private readonly ApplicationDbContext _context;

        public InstructorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors
                .Include(i => i.Department)
                .FirstOrDefaultAsync(i => i.InstructorID == id);
        }

        public async Task<Instructor> AddInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();


            _context.Entry(instructor).Reference(i => i.Department).Load();
            return instructor;
        }

        public async Task<Instructor> UpdateInstructorAsync(InstructorPutVM instructorVM)
        {
            var instructor = await _context.Instructors.FindAsync(instructorVM.InstructorID);

            if (instructor == null)
            {
                return null;
            }

            instructor.LastName = instructorVM.LastName;
            instructor.FirstName = instructorVM.FirstName;
            instructor.Status = instructorVM.Status;
            instructor.HireDate = instructorVM.HireDate;
            instructor.AnnualSalary = instructorVM.AnnualSalary;
            instructor.DepartmentID = instructorVM.DepartmentID;

            _context.Entry(instructor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return instructor;
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return false;
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync(); 
            return true;
        }

    }
}
