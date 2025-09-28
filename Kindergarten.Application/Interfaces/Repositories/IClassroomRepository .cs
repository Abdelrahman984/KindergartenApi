using Kindergarten.Application.DTOs;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface IClassroomRepository : IGenericRepository<Classroom>
{
    Task<Classroom?> GetWithStudentsAsync(Guid id);
    Task<IEnumerable<Student>> GetStudentsByTeacherIdAsync(Guid teacherId);
    Task UpdateClassroomAsync(Classroom classroom);
    Task DeleteAsync(Guid id);
    Task<int> GetTotalCountAsync();
    Task<double> GetAverageCapacityAsync();
    Task<int> GetWithStudentsCountAsync();
    Task<int> GetWithoutStudentsCountAsync();
    Task<IEnumerable<ClassroomStudentCountDto>> GetStudentCountsAsync();
    Task<List<Classroom>> GetAllWithRelationsAsync(CancellationToken ct = default);
}