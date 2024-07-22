using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UniversityAPI.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String Status { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public decimal AnnualSalary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        /*
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; }
        */

    }
}
