using UniversityAPI.Models;
using UniversityAPI.ViewModels;
using UniversityAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace UniversityAPI.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentResponseVM>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();
            var studentCourses = await _context.StudentCourses.Include(sc => sc.Course).ToListAsync();

            var studentResponse = students.Select(s => new StudentResponseVM
            {
                StudentID = s.StudentID,
                StudentNumber = s.StudentNumber,
                LastName = s.LastName,
                FirstName = s.FirstName,
                EnrollmentDate = s.EnrollmentDate,
                GraduationDate = s.GraduationDate,
                CourseNames = studentCourses.Where(sc => sc.StudentID == s.StudentID)
                                            .Select(sc => sc.Course.CourseName)
                                            .ToList()
            }).ToList();
        
            return studentResponse;
        }

        public async Task<StudentResponseVM> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            var studentCourses = await _context.StudentCourses
                                                .Include(sc => sc.Course)
                                                .Where(sc => sc.StudentID == id)
                                                .ToListAsync();

            var studentResponse = new StudentResponseVM
            {
                StudentID = student.StudentID,
                StudentNumber = student.StudentNumber,
                LastName = student.LastName,
                FirstName = student.FirstName,
                EnrollmentDate = student.EnrollmentDate,
                GraduationDate = student.GraduationDate,
                CourseNames = studentCourses.Select(sc => sc.Course.CourseName).ToList()
            };

            return studentResponse;
        }

        public async Task<Student> AddStudentAsync(StudentCreateVM studentVM)
        {
            var student = new Student
            {
                StudentNumber = studentVM.StudentNumber,
                LastName = studentVM.LastName,
                FirstName = studentVM.FirstName,
                EnrollmentDate = studentVM.EnrollmentDate,
                GraduationDate = studentVM.GraduationDate
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var studentCourses = studentVM.CourseIDs.Select(courseID => new StudentCourse
            {
                StudentID = student.StudentID,
                CourseID = courseID
            }).ToList();

            _context.StudentCourses.AddRange(studentCourses);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.StudentID);
            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.StudentNumber = student.StudentNumber;
            existingStudent.LastName = student.LastName;
            existingStudent.FirstName = student.FirstName;
            existingStudent.EnrollmentDate = student.EnrollmentDate;
            existingStudent.GraduationDate = student.GraduationDate;

            _context.Entry(existingStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            var studentCourses = await _context.StudentCourses.Where(sc => sc.StudentID == id).ToListAsync();
            _context.StudentCourses.RemoveRange(studentCourses);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
