namespace Kindergarten.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<string> CreateUserAsync(string email, string phone, string fullName, string password, string role);
    }

}
