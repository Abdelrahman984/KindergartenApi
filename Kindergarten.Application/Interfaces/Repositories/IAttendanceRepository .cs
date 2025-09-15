using Kindergarten.Application.DTOs;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface IAttendanceRepository : IGenericRepository<Attendance>
{
    Task<Attendance?> GetByStudentAndDateAsync(Guid studentId, DateTime date);
    Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date);
    Task<IEnumerable<Attendance>> GetByStudentAsync(Guid studentId);
    // إحصائيات
    Task<double> GetStudentAttendancePercentageAsync(Guid studentId);
    Task<double> GetOverallAttendancePercentageAsync();
    Task<AttendanceTrendDto> GetAttendanceTrendsAsync(DateTime today);
    Task<List<StudentAttendancePercentageDto>> GetAllStudentsAttendancePercentageAsync();
}
