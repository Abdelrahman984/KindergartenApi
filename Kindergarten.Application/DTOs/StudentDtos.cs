namespace Kindergarten.Application.DTOs;

public record StudentCreateDto(
    string FullName,
    DateTime DateOfBirth,
    string Address,
    Guid ClassroomId,
    string ParentName,
    string ParentPhone,
    string ParentAddress
);

public record StudentUpdateDto(
    Guid StudentId,
    string FullName,
    DateTime DateOfBirth,
    string Address,
    Guid ClassroomId,
    string ParentName,
    string ParentPhone,
    string ParentAddress
);

public class StudentReadDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
    public bool IsActive { get; set; }
    public Guid ClassroomId { get; set; }
    public string ClassroomName { get; set; } = null!;
    public double AttendanceRate { get; set; }
    public string ParentName { get; set; } = null!;
    public string ParentPhone { get; set; } = null!;
    public string ParentAddress { get; set; } = null!;
}

public class StudentStatsDto
{
    public int Total { get; set; }
    public int Active { get; set; }
    public int Inactive { get; set; }
    public double AverageAge { get; set; }
}