using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProfileManagement.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // SystemAdmin, Manager, GeneralEmployee
        public string EmployeeNumber { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Remarks { get; set; }
        public string ProfileImageUrl { get; set; }
        public List<UserCompany> UserCompanies { get; set; }
    }
}
