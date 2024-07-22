using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UniversityAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        public String CourseNumber { get; set; }

        [Required]
        public String CourseName { get; set; }

        [Required]
        public String CourseDescription { get; set; }

        [Required]
        public int CourseUnits { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        //[JsonIgnore]
        //public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
