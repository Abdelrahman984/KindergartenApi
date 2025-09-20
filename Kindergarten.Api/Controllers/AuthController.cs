using Kindergarten.Application.DTOs;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext _db;
    private readonly IConfiguration _config;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        AppDbContext db,
        IConfiguration config)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
        _config = config;
    }

    // ✅ Register for only Parent role
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        // 1. التحقق الأساسي
        if (string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.PhoneNumber))
            return BadRequest("يجب إدخال البريد الإلكتروني أو رقم الهاتف");

        var email = string.IsNullOrWhiteSpace(dto.Email) ? null : dto.Email!.Trim();
        var phone = string.IsNullOrWhiteSpace(dto.PhoneNumber) ? null : NormalizePhone(dto.PhoneNumber!);

        // 2. اختر username صالح
        var userName = email ?? phone;
        if (string.IsNullOrWhiteSpace(userName))
            return BadRequest("تعذر استخراج اسم مستخدم صالح من البيانات المرسلة.");

        // 3. تحقق من صحة الايميل لو موجود
        if (email != null && !IsValidEmail(email))
            return BadRequest("البريد الإلكتروني غير صحيح");

        // 4. بناء المستخدم
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            PhoneNumber = phone,
            FullName = dto.FullName?.Trim()
        };

        var createRes = await _userManager.CreateAsync(user, dto.Password);
        if (!createRes.Succeeded)
            return BadRequest(createRes.Errors);

        // 5. تأكد وجود Role Parent ثم ضيفه
        const string defaultRole = "Parent";
        if (!await _roleManager.RoleExistsAsync(defaultRole))
            await _roleManager.CreateAsync(new IdentityRole(defaultRole));

        await _userManager.AddToRoleAsync(user, defaultRole);

        // 6. ربط تلقائي بالـ Parent Entity لو موجود
        if (!string.IsNullOrWhiteSpace(phone))
        {
            var parent = await _db.Parents.FirstOrDefaultAsync(p => p.PhoneNumber == phone);
            if (parent != null)
            {
                parent.LinkApplicationUser(user.Id);
                _db.Parents.Update(parent);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();

                return Ok(new { message = "تم التسجيل وربط حساب ولي الأمر بنجاح", userId = user.Id });
            }
        }

        // 7. لو مافيش Parent مطابق في DB → ممكن تعمل واحد جديد
        var createdParent = new Parent(dto.FullName ?? user.FullName ?? "", phone ?? "", dto.Address ?? "");
        createdParent.LinkApplicationUser(user.Id);

        _db.Parents.Add(createdParent);
        await _db.SaveChangesAsync();

        return Ok(new { message = "تم التسجيل كولي أمر جديد", userId = user.Id });
    }

    // ✅ تسجيل الدخول بالبريد أو الهاتف
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        ApplicationUser? user;

        if (dto.Identifier.Contains("@"))
            user = await _userManager.FindByEmailAsync(dto.Identifier);
        else
            user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == dto.Identifier);

        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            return Unauthorized("بيانات الدخول غير صحيحة");

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    // -------------------------Helpers--------------------------
    private string GenerateJwtToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty) // اختياري
        };

        // 👇 إضافة الـ Roles
        var roles = _userManager.GetRolesAsync(user).Result; // أو await لو خليتها async
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private static string NormalizePhone(string phone)
    {
        var digits = new string(phone.Where(char.IsDigit).ToArray());
        return digits;
    }
    private static bool IsValidEmail(string email)
    {
        var attr = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
        return attr.IsValid(email);
    }
}
