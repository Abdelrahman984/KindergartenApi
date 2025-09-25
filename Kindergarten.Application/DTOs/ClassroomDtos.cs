namespace Kindergarten.Application.DTOs;

public record ClassroomCreateDto(string Name, int Capacity);
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
