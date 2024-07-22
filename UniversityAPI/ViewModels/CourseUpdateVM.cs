namespace UniversityAPI.ViewModels
{
    public class CourseUpdateVM
    {
        public int CourseID { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseUnits { get; set; }
        public int DepartmentID { get; set; }
        public int InstructorID { get; set; }
    }
}
