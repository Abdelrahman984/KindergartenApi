using Microsoft.AspNetCore.Identity;

namespace Kindergarten.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; } = null!;
    public override string? PhoneNumber { get; set; }

    public Teacher? Teacher { get; set; }
    public Parent? Parent { get; set; }
}
