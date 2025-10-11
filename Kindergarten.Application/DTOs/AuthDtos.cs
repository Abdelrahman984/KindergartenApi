namespace Kindergarten.Application.DTOs;

public record RegisterDto(string FullName, string? Email, string? PhoneNumber, string Password, string? Address);
public record LoginDto(string Identifier, string Password);

// DTO returned after successful login
public record UserDto(string Id, string Name, string Role);
public record LoginResponseDto(string Token, UserDto User);
