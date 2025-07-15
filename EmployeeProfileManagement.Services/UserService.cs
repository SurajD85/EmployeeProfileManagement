using EmployeeProfileManagement.Data;
using EmployeeProfileManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeProfileManagement.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public async Task<Employee> UpdateProfileAsync(int userId, Employee profileDetails)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == userId);
            if (employee == null)
            {
                employee = new Employee
                {
                    UserId = userId,
                    EmployeeNumber = profileDetails.EmployeeNumber,
                    Department = profileDetails.Department,
                    Name = profileDetails.Name,
                    ZipCode = profileDetails.ZipCode,
                    Address = profileDetails.Address,
                    PhoneNumber = profileDetails.PhoneNumber,
                    Birthday = profileDetails.Birthday,
                    Remarks = profileDetails.Remarks,
                    ProfileImageUrl = profileDetails.ProfileImageUrl
                };
                _context.Employees.Add(employee);
            }
            else
            {
                employee.EmployeeNumber = profileDetails.EmployeeNumber;
                employee.Department = profileDetails.Department;
                employee.Name = profileDetails.Name;
                employee.ZipCode = profileDetails.ZipCode;
                employee.Address = profileDetails.Address;
                employee.PhoneNumber = profileDetails.PhoneNumber;
                employee.Birthday = profileDetails.Birthday;
                employee.Remarks = profileDetails.Remarks;
                employee.ProfileImageUrl = profileDetails.ProfileImageUrl;
            }
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                //if (user == null || !(password ==user.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
