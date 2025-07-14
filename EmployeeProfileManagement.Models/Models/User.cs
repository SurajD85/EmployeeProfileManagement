using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProfileManagement.Models.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; } // SystemAdmin, Manager, GeneralEmployee

        public required string EmployeeNumber { get; set; }
        public required string Department { get; set; }
        public required string Name { get; set; }
        public required string ZipCode { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime Birthday { get; set; }
        public required string Remarks { get; set; }
        public required string ProfileImageUrl { get; set; }
        public List<UserCompany> UserCompanies { get; set; }
    }
}
