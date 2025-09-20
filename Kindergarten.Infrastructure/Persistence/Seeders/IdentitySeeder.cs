using Kindergarten.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Kindergarten.Infrastructure.Persistence.Seeders;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // 🔹 1. Seed Roles 
        string[] roles = ["Admin", "Teacher", "Parent"];
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // 🔹 2. Seed Admin User 
        var adminEmail = "admin@kg.com";
        var adminPhoneNumber = "01000000000";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                PhoneNumber = adminPhoneNumber,
                EmailConfirmed = true,
                FullName = "System Admin"
            };
            await userManager.CreateAsync(adminUser, "Admin@123");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // 🔹 3. Seed Parent Users (مربوطين بـ Parents) 
        var parents = new[]
        {
            new { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Email = "ahmed.parent@kg.com", Phone = "01012345678" },
            new { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Email = "bakry.parent@kg.com", Phone = "01098765432" },
            new { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Email = "hossam.parent@kg.com", Phone = "0103334444" },
            new { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Email = "tarek.parent@kg.com", Phone = "0104445555" },
            new { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Email = "khaled.parent@kg.com", Phone = "0106667777" },
            new { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Email = "omar.parent@kg.com", Phone = "0108889999" }
        };

        foreach (var parent in parents)
        {
            var parentEntity = await dbContext.Parents.FindAsync(parent.Id);
            if (parentEntity == null) continue;

            var user = await userManager.FindByEmailAsync(parent.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = parent.Email,
                    Email = parent.Email,
                    PhoneNumber = parent.Phone,
                    EmailConfirmed = true,
                    FullName = parentEntity.FullName,
                };
                await userManager.CreateAsync(user, "Parent@123");
                await userManager.AddToRoleAsync(user, "Parent");
            }

            // 🔗 ربط Parent ↔ User
            if (parentEntity.ApplicationUserId == null)
            {
                parentEntity.LinkApplicationUser(user.Id);
                dbContext.Parents.Update(parentEntity);
            }
        }

        // 🔹 4. Seed Teacher Users (مربوطين بـ Teachers) 
        var teachers = new[]
        {
            new { Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111111"), Email = "fatma.teacher@kg.com", Phone = "0105551234" },
            new { Id = Guid.Parse("aaaa2222-2222-2222-2222-222222222222"), Email = "amany.teacher@kg.com", Phone = "0107779999" },
            new { Id = Guid.Parse("aaaa3333-3333-3333-3333-333333333333"), Email = "aisha.teacher@kg.com", Phone = "0102226666" },
            new { Id = Guid.Parse("aaaa4444-4444-4444-4444-444444444444"), Email = "amira.teacher@kg.com", Phone = "0108881111" },
            new { Id = Guid.Parse("aaaa5555-5555-5555-5555-555555555555"), Email = "hala.teacher@kg.com", Phone = "0109992222" },
            new { Id = Guid.Parse("aaaa6666-6666-6666-6666-666666666666"), Email = "khadija.teacher@kg.com", Phone = "0103335555" },
            new { Id = Guid.Parse("aaaa7777-7777-7777-7777-777777777777"), Email = "mona.teacher@kg.com", Phone = "0104446666" },
            new { Id = Guid.Parse("aaaa8888-8888-8888-8888-888888888888"), Email = "souad.teacher@kg.com", Phone = "0101113333" },
            new { Id = Guid.Parse("aaaa9999-9999-9999-9999-999999999999"), Email = "jamila.teacher@kg.com", Phone = "0106668888" },
            new { Id = Guid.Parse("aaaabbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), Email = "rana.teacher@kg.com", Phone = "0100007777" }
        };

        foreach (var teacher in teachers)
        {
            var teacherEntity = await dbContext.Teachers.FindAsync(teacher.Id);
            if (teacherEntity == null) continue;

            var user = await userManager.FindByEmailAsync(teacher.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = teacher.Email,
                    Email = teacher.Email,
                    PhoneNumber = teacher.Phone,
                    EmailConfirmed = true,
                    FullName = teacherEntity.FullName,
                };
                await userManager.CreateAsync(user, "Teacher@123");
                await userManager.AddToRoleAsync(user, "Teacher");
            }

            // 🔗 ربط Teacher ↔ User
            if (teacherEntity.ApplicationUserId == null)
            {
                teacherEntity.LinkApplicationUser(user.Id);
                dbContext.Teachers.Update(teacherEntity);
            }
        }

        await dbContext.SaveChangesAsync();
    }
}
