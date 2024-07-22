using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPI.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }


        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }

    }
}
