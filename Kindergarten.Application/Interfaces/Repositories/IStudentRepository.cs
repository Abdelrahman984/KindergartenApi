using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetActiveStudentsAsync();
        Task<IEnumerable<Student>> GetByFilterAsync(Guid? classroomId, string? name, bool? isActive);
        Task<IEnumerable<Student>> GetByClassroomIdAsync(Guid classroomId);
        Task<IEnumerable<Student>> GetByParentIdAsync(Guid parentId);

        // Statistics
        Task<int> GetTotalCountAsync();
        Task<int> GetActiveCountAsync();
        Task<int> GetInactiveCountAsync();
        Task<double> GetAverageAgeAsync();
    }
}
