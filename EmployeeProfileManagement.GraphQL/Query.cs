using EmployeeProfileManagement.Data;
using EmployeeProfileManagement.Models.Models;
using HotChocolate;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmployeeProfileManagement.GraphQL
{
    public class Query
    {
        [Authorize(Roles = new[] { "SystemAdmin" })]
        [GraphQLName("getUsers")]
        public IQueryable<User> GetUsers([Service] ApplicationDbContext context) => context.Users;
        
        [Authorize]
        public async Task<Employee> GetProfile([Service] ApplicationDbContext context, ClaimsPrincipal claimsPrincipal)
        {
            var userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            return await context.Employees.FirstOrDefaultAsync(e => e.UserId == userId);
        }

        [Authorize(Roles = new[] { "SystemAdmin", "Manager" })]
        public IQueryable<User> GetCompanyUsers([Service] ApplicationDbContext context, ClaimsPrincipal claimsPrincipal)
        {
            var userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user.Role == "SystemAdmin") return context.Users;
            return context.UserCompanies
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.User);
        }

        [Authorize]
        [GraphQLName("getCompanies")]
        public IQueryable<Company> GetCompanies([Service] ApplicationDbContext context, ClaimsPrincipal claimsPrincipal)
        {
            var userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user.Role == "SystemAdmin") return context.Companies;
            return context.UserCompanies
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Company);
        }


        //[GraphQLName("getCompanies")]
        //public IQueryable<Company> GetCompanies([Service] ApplicationDbContext context) => context.Companies;
    }
}
