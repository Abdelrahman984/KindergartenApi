namespace Kindergarten.Application.DTOs;

public record StudentCreateDto(
    string FirstName,
    string FatherName,
    string GrandpaName,
    DateTime DateOfBirth,
    string ParentPhone,
    string Address,
    Guid ClassroomId
);

public record StudentUpdateDto(
    Guid StudentId,
    string FirstName,
    string FatherName,
    string GrandpaName,
    DateTime DateOfBirth,
    string ParentPhone,
    string Address,
    Guid ClassroomId
);

public class StudentReadDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string ParentPhone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ParentFullName { get; set; } = null!;
    public string ParentAddress { get; set; } = null!;
    public bool IsActive { get; set; }
    public Guid ClassroomId { get; set; }
    public string ClassroomName { get; set; } = null!;
    public double AttendanceRate { get; set; }
}
