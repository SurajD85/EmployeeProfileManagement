using EmployeeProfileManagement.Data;
using EmployeeProfileManagement.Models.Models;

namespace EmployeeProfileManagement.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(string email, string password, string role, int? companyId = null)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), // Fully qualify the method call
                Role = role
            };

            _context.Users.Add(user);
            if (companyId.HasValue)
            {
                _context.UserCompanies.Add(new UserCompany { User = user, CompanyId = companyId.Value });
            }
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
