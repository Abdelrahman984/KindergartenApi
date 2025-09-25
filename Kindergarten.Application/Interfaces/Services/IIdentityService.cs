namespace Kindergarten.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<string> CreateUserAsync(string email, string phone, string fullName, string password, string role);
        // 🔹 Get current logged-in user's Id (from JWT Claims)
        Guid GetUserId();

        // 🔹 Get current logged-in user's Role
        string? GetUserRole();

        // 🔹 Check if current user is in specific role
        bool IsInRole(string role);
    }

}
