namespace UniversityAPI.ViewModels
{
    public class CourseResponseVM
    {
        public int CourseID { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseUnits { get; set; }
        public string DepartmentName { get; set; }
        public string InstructorName { get; set; }
    }
}
