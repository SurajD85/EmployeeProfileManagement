using EmployeeProfileManagement.Data.Data;
using EmployeeProfileManagement.Models.Models;
using HotChocolate;

namespace EmployeeProfileManagement.GraphQL
{
    public class Query
    {
        public IQueryable<User> GetUsers([Service] ApplicationDbContext context) => context.Users;
        public IQueryable<Company> GetCompanies([Service] ApplicationDbContext context) => context.Companies;
    }
}
