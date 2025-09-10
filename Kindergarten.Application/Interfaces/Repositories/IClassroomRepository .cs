using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface IClassroomRepository : IGenericRepository<Classroom>
{
    Task<Classroom?> GetWithStudentsAsync(Guid id);
    Task<IEnumerable<Student>> GetStudentsByTeacherIdAsync(Guid teacherId);
}