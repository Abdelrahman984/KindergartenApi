namespace Kindergarten.Application.DTOs;

public record TeacherCreateDto(string FullName, string Subject, string PhoneNumber, bool IsActive, IEnumerable<Guid> ClassroomIds);
public record TeacherUpdateDto(string FullName, string Subject, string PhoneNumber, bool IsActive, IEnumerable<Guid> ClassroomIds);
public record TeacherReadDto(Guid Id, string FullName, string Subject, string PhoneNumber, bool IsActive);
