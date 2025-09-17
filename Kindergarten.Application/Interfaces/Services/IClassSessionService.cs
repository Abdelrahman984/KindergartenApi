using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services
{
    public interface IClassSessionService
    {
        Task<IEnumerable<ClassSessionReadDto>> GetAllAsync();
        Task<ClassSessionReadDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ClassSessionReadDto>> GetByClassroomIdAsync(Guid classroomId);
        Task<IEnumerable<ClassSessionReadDto>> GetByTeacherIdAsync(Guid teacherId);
        Task<IEnumerable<ClassSessionReadDto>> GetBySubjectIdAsync(Guid subjectId);
        Task<ClassSessionReadDto> CreateAsync(ClassSessionCreateDto dto);
        Task<ClassSessionReadDto> UpdateAsync(ClassSessionUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
