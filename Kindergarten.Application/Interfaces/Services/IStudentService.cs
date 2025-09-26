using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IStudentService
{
    Task<StudentReadDto> CreateStudentAsync(StudentCreateDto dto);
    Task<IEnumerable<StudentReadDto>> GetAllAsync(Guid? classroomId = null, string? name = null, bool? isActive = null);
    Task<StudentReadDto?> GetByIdAsync(Guid id);
    Task UpdateStudentAsync(Guid id, StudentUpdateDto dto);
    Task DeactivateStudentAsync(Guid id);
    Task DeleteStudentAsync(Guid id);
    Task<IEnumerable<StudentReadDto>> GetByClassroomIdAsync(Guid classroomId);
    Task<IEnumerable<StudentReadDto>> GetByParentIdAsync(Guid parentId);

    // Statistics
    Task<StudentStatsDto> GetStatsAsync();
}
