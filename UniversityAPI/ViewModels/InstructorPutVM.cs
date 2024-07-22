namespace UniversityAPI.ViewModels
{
    public class InstructorPutVM
    {
        public int InstructorID { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Status { get; set; }
        public DateTime HireDate { get; set; }
        public decimal AnnualSalary { get; set; }

        public int DepartmentID { get; set; }

    }
}
