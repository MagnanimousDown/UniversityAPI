namespace UniversityAPI.ViewModels
{
    public class InstructorWithDepartmentVM
    {
        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }
        public DateTime HireDate { get; set; }
        public decimal AnnualSalary { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

    }
}
