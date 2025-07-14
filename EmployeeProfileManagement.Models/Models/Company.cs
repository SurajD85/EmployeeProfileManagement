using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProfileManagement.Models.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string HomePageUrl { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string Remarks { get; set; }
        public string ImageUrl { get; set; }
        public List<UserCompany> UserCompanies { get; set; }
    }
}
