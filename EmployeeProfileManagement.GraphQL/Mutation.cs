using EmployeeProfileManagement.Data;
using EmployeeProfileManagement.Models.Models;
using EmployeeProfileManagement.Services;
using HotChocolate;
using HotChocolate.Authorization;
using System.Security.Claims;

namespace EmployeeProfileManagement.GraphQL
{
    public class Mutation
    {

        [Authorize(Roles = new[] { "SystemAdmin" })]
        public async Task<User> CreateUser([Service] IUserService userService, CreateUserInput input)
        {
            return await userService.RegisterUserAsync(input.Email, input.Password, input.Role);
        }

        //public async Task<string> Login([Service] IUserService userService, string email, string password)
        //{
        //    return await userService.LoginAsync(email, password);
        //}

        public async Task<LoginResponse> Login([Service] IUserService userService, string email, string password)
        {
            var token = await userService.LoginAsync(email, password);
            return new LoginResponse { Token = token };
        }

        [Authorize]
        public async Task<Employee> UpdateProfile([Service] IUserService userService, Employee profileDetails, ClaimsPrincipal claimsPrincipal)
        {
            var userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            return await userService.UpdateProfileAsync(userId, profileDetails);
        }

        //[Authorize(Roles = new[] { "SystemAdmin", "Manager" })]
        //public async Task<Invitation> CreateInvitation([Service] IInvitationService invitationService, string invitedEmail, string role, int invitedByUserId, int companyId)
        //{
        //    return await invitationService.CreateInvitationAsync(invitedEmail, role, invitedByUserId, companyId);
        //}

        //[Authorize(Roles = new[] { "SystemAdmin", "Manager" })]
        //public async Task<Invitation> CancelInvitation([Service] IInvitationService invitationService, int invitationId)
        //{
        //    return await invitationService.CancelInvitationAsync(invitationId);
        //}

        //public async Task<User> AcceptInvitation([Service] IInvitationService invitationService, string token, string password, Employee profileDetails)
        //{
        //    var user = await invitationService.AcceptInvitationAsync(token, password, profileDetails);
        //    await userService.UpdateProfileAsync(user.Id, profileDetails);
        //    return user;
        //}

      
    }
}
