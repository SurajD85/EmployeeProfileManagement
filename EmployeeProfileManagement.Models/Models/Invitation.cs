using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProfileManagement.Models.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public string InvitedEmail { get; set; }
        public string InvitedRole { get; set; }
        public int InvitedByUserId { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; } // Pending, Completed, Canceled
        public string Token { get; set; }
    }
}
