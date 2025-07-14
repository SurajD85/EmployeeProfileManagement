using EmployeeProfileManagement.Data;
using EmployeeProfileManagement.Models.Models;
using HotChocolate;

namespace EmployeeProfileManagement.GraphQL
{
    public class Query
    {
        [GraphQLName("getUsers")]
        public IQueryable<User> GetUsers([Service] ApplicationDbContext context) => context.Users;

        [GraphQLName("getCompanies")]
        public IQueryable<Company> GetCompanies([Service] ApplicationDbContext context) => context.Companies;
    }
}
