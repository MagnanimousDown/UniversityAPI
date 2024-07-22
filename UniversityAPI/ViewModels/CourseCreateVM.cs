namespace UniversityAPI.ViewModels
{
    public class CourseCreateVM
    {
        public String CourseNumber { get; set; }
        public String CourseName { get; set; }
        public String CourseDescription { get; set; }
        public int CourseUnits { get; set; }
        public int DepartmentID { get; set; }
        public int InstructorID { get; set; }

    }
}
