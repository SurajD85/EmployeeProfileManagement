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
             string role
            )
        {
            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                Role = role

            }; // Hash password in production
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
