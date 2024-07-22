namespace UniversityAPI.ViewModels
{
    public class StudentCreateVM
    {
        public string StudentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public List<int> CourseIDs { get; set; }
    }

    public class StudentResponseVM
    {
        public int StudentID { get; set; }
        public string StudentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public List<string> CourseNames { get; set; }
    }
}
