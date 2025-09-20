namespace Kindergarten.Application.DTOs;

public record TeacherCreateDto(
    string FullName,
    Guid? SubjectId,
    string? PhoneNumber,
    bool IsActive,
    IEnumerable<Guid>? ClassroomIds,
    string Email,
    string Password
);
public record TeacherUpdateDto(string FullName, Guid? SubjectId, string PhoneNumber, bool IsActive, IEnumerable<Guid>? ClassroomIds);
public record TeacherReadDto(Guid Id, string FullName, Guid SubjectId, string SubjectName, string PhoneNumber, bool IsActive);
