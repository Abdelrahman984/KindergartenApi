using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IClassroomService
{
    Task<ClassroomReadDto> CreateClassroomAsync(ClassroomCreateDto dto);
    Task<IEnumerable<ClassroomReadDto>> GetAllAsync();
    Task<ClassroomReadDto?> GetByIdAsync(Guid id);
    Task AssignTeacherAsync(Guid classroomId, Guid teacherId);
    Task UpdateCapacityAsync(Guid classroomId, int newCapacity);
    Task<IEnumerable<StudentReadDto>> GetStudentsAsync(Guid classroomId);
}
