using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProfileManagement.Models.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public User User { get; set; }
        public required string EmployeeNumber { get; set; }
        public required string Department { get; set; }
        public required string Name { get; set; }
        public required string ZipCode { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime Birthday { get; set; }
        public required string Remarks { get; set; }
        public required string ProfileImageUrl { get; set; }
    }
}
