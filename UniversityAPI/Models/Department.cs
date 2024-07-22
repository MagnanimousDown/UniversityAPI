using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        public String DepartmentName { get; set; }

        /*
        [JsonIgnore]
        public ICollection<Instructor>? Instructors { get; set; }

        [JsonIgnore]
        public ICollection<Course>? Courses { get; set; }
        */
    }
}
