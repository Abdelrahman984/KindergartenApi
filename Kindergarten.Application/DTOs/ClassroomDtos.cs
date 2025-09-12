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
