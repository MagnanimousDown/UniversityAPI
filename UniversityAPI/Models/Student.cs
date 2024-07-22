using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public String StudentNumber { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public DateTime? GraduationDate { get; set; }

        /*
        [JsonIgnore]
        public ICollection<StudentCourse> StudentCourses { get; set; }
        */

    }
}
