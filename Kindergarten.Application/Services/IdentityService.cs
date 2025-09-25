using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Kindergarten.Application.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> CreateUserAsync(string email, string phone, string fullName, string password, string role)
    {
        var user = new ApplicationUser
        {
            UserName = email ?? phone,
            Email = email,
            PhoneNumber = phone,
            FullName = fullName
        };

        var createRes = await _userManager.CreateAsync(user, password);
        if (!createRes.Succeeded)
            throw new Exception(string.Join("; ", createRes.Errors.Select(e => e.Description)));

        if (!await _roleManager.RoleExistsAsync(role))
            await _roleManager.CreateAsync(new IdentityRole(role));

        await _userManager.AddToRoleAsync(user, role);

        return user.Id;
    }

    public Guid GetUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return userIdClaim != null ? Guid.Parse(userIdClaim) : Guid.Empty;
    }

    public string? GetUserRole()
    {
        return _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.Role)?.Value;
    }

    public bool IsInRole(string role)
    {
        return _httpContextAccessor.HttpContext?.User?.IsInRole(role) ?? false;
    }
}
