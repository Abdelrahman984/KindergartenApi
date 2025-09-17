using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories
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
