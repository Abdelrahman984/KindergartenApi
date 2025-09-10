using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IParentService
{
    Task<ParentReadDto> CreateParentAsync(ParentCreateDto dto);
    Task<IEnumerable<ParentReadDto>> GetAllAsync();
    Task<ParentReadDto?> GetByIdAsync(Guid id);
    Task UpdateInfoAsync(Guid id, ParentUpdateDto dto);
    Task<ParentReadDto?> GetByPhoneAsync(string phoneNumber);
    Task<ParentReadDto?> GetWithChildrenAsync(Guid parentId);
}
