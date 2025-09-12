using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface ITeacherService
{
    Task<TeacherReadDto> CreateTeacherAsync(TeacherCreateDto dto);
    Task<IEnumerable<TeacherReadDto>> GetAllAsync();
    Task<TeacherReadDto?> GetByIdAsync(Guid id);
    Task UpdateTeacherAsync(Guid id, TeacherUpdateDto dto);
    Task DeactivateTeacherAsync(Guid id);
    Task<IEnumerable<StudentReadDto>> GetClassStudentsAsync(Guid teacherId);
    Task<IEnumerable<ClassroomReadDto>> GetClassroomsByTeacherIdAsync(Guid teacherId);
    Task DeleteTeacherAsync(Guid id);
}
