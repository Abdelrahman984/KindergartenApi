namespace Kindergarten.Application.DTOs;

public record TeacherCreateDto(string FullName, string Subject, string PhoneNumber);
public record TeacherUpdateDto(string FullName, string Subject, string PhoneNumber);
public record TeacherReadDto(Guid Id, string FullName, string Subject, string PhoneNumber, bool IsActive);
