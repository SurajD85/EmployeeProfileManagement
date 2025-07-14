using EmployeeProfileManagement.Data;
using EmployeeProfileManagement.Models.Models;
using HotChocolate;

namespace EmployeeProfileManagement.GraphQL
{
    public class Mutation
    {
        public async Task<User> CreateUser(
             [Service] ApplicationDbContext context,
             string email,
             string passwordHash,
             string role,
             string employeeNumber,
             string department,
             string name,
             string zipCode,
             string address,
             string phoneNumber,
             DateTime birthday,
             string remarks,
             string profileImageUrl)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                Role = role,
                EmployeeNumber = employeeNumber,
                Department = department,
                Name = name,
                ZipCode = zipCode,
                Address = address,
                PhoneNumber = phoneNumber,
                Birthday = birthday,
                Remarks = remarks,
                ProfileImageUrl = profileImageUrl
            }; // Hash password in production
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
