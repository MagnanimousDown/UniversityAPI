using UniversityAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses {  get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instructor>()
                .Property(i => i.AnnualSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany()
                .HasForeignKey(i => i.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
