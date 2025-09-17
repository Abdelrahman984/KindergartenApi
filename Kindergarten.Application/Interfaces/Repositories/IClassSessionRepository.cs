using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories
{
    public interface IClassSessionRepository
    {
        Task<IEnumerable<ClassSession>> GetAllAsync();
        Task<ClassSession> GetByIdAsync(Guid id);
        Task<IEnumerable<ClassSession>> GetByClassroomIdAsync(Guid classroomId);
        Task<IEnumerable<ClassSession>> GetByTeacherIdAsync(Guid teacherId);
        Task<IEnumerable<ClassSession>> GetBySubjectIdAsync(Guid subjectId);
        Task AddAsync(ClassSession entity);
        Task UpdateAsync(ClassSession entity);
        Task DeleteAsync(ClassSession entity);
    }
}