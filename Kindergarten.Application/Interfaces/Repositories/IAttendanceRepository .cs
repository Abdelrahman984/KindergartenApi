using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface IAttendanceRepository : IGenericRepository<Attendance>
{
    Task<IEnumerable<Attendance>> GetByStudentAsync(Guid studentId);
    Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date);
    Task<IEnumerable<Attendance>> GetByStudentAndRangeAsync(Guid studentId, DateTime fromDate, DateTime toDate);
    Task<IEnumerable<Attendance>> GetByRangeAsync(DateTime fromDate, DateTime toDate);
    Task<IEnumerable<Attendance>> GetByStudentsAndRangeAsync(IEnumerable<Guid> studentIds, DateTime fromDate, DateTime toDate);
}
