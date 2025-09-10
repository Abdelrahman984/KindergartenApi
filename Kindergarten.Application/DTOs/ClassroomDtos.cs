namespace Kindergarten.Application.DTOs;

public record ClassroomCreateDto(string Name, int Capacity);
public record ClassroomReadDto(Guid Id, string Name, int Capacity, Guid? TeacherId);
