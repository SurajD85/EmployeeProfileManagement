namespace EmployeeProfileManagement.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; } // SystemAdmin, Manager, GeneralEmployee
        public List<UserCompany>? UserCompanies { get; set; }
        public Employee? Employee { get; set; } // Navigation property
    }
}
