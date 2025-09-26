using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<IEnumerable<Teacher>> GetActiveTeachersAsync();
    Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    Task<List<Teacher>> GetBulkTeachersByIdsAsync(List<Guid> ids);
    Task UpdateBulkTeachersAsync(List<Teacher> teachers);
    Task<Teacher?> GetByIdWithSubjectAsync(Guid teacherId);

    Task<int> GetTotalCountAsync();
    Task<int> GetActiveCountAsync();
    Task<int> GetInactiveCountAsync();
    Task<int> GetWithSubjectsCountAsync();
    Task<int> GetWithoutSubjectsCountAsync();
}