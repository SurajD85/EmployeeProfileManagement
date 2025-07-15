using EmployeeProfileManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProfileManagement.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(string email, string password, string role, int? companyId = null);
    }
}
