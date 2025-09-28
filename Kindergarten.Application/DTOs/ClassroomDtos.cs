namespace Kindergarten.Application.DTOs;

public record ClassroomCreateDto(string Name, int Capacity);
public record ClassroomUpdateDto(string Name, int Capacity);

public record ClassroomReadDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Capacity { get; init; }

    public ClassroomReadDto() { }

    public ClassroomReadDto(Guid id, string name, int capacity)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
    }
}
public class TeacherClassroomReadDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int StudentsCount { get; set; }

    public List<StudentReadDto> Students { get; set; } = new();
}

public class ClassroomReportDto
{
    public int TotalClassrooms { get; set; }
    public double AverageCapacity { get; set; }
    public int WithStudents { get; set; }
    public int WithoutStudents { get; set; }
    public IEnumerable<ClassroomStudentCountDto> StudentCounts { get; set; } = new List<ClassroomStudentCountDto>();
}

public class ClassroomStudentCountDto
{
    public Guid ClassroomId { get; set; }
    public string ClassroomName { get; set; } = null!;
    public int ClassroomCapacity { get; set; }
    public int StudentCount { get; set; }

}
public class ClassroomDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int StudentsCount { get; set; }
    public List<Guid> TeacherIds { get; set; } = new();
    public List<string> TeacherNames { get; set; } = new();
}