using Kindergarten.Domain.Entities;

namespace Kindergarten.Infrastructure.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject> GetByIdAsync(Guid id);
        Task AddAsync(Subject entity);
        Task UpdateAsync(Subject entity);
        Task DeleteAsync(Subject entity);
    }
}
