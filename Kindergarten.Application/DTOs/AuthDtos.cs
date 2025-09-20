namespace Kindergarten.Application.DTOs;

public record RegisterDto(string FullName, string? Email, string? PhoneNumber, string Password, string? Address);
public record LoginDto(string Identifier, string Password);