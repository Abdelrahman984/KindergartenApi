using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories
{
    public interface IClassSessionRepository
    {
        Task<IEnumerable<ClassSession>> GetAllAsync();
        Task<ClassSession> GetByIdAsync(Guid id);
        Task AddAsync(ClassSession entity);
        Task UpdateAsync(ClassSession entity);
        Task DeleteAsync(ClassSession entity);
    }

}