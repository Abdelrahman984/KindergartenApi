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

public class TeacherStatsDto
{
    public int Total { get; set; }
    public int Active { get; set; }
    public int Inactive { get; set; }
    public int WithSubjects { get; set; }
    public int WithoutSubjects { get; set; }
}