using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<IEnumerable<Teacher>> GetActiveTeachersAsync();
    Task<IEnumerable<Teacher>> GetAllTeachersAsync();
}