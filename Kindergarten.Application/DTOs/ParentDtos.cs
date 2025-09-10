namespace Kindergarten.Application.DTOs;

public record ParentCreateDto(string FullName, string PhoneNumber, string Address);
public record ParentUpdateDto(string FullName, string PhoneNumber, string Address);
public record ParentReadDto(Guid Id, string FullName, string PhoneNumber, string Address, IReadOnlyList<StudentReadDto> Childrens);
