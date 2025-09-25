using Microsoft.AspNetCore.Authorization;
namespace Kindergarten.Api.Authorization
{
    public class AdminOverrideHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            // If the user is in the "Admin" role, succeed all pending requirements
            if (context.User.IsInRole("Admin"))
            {
                foreach (var requirement in context.PendingRequirements.ToList())
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }

}
