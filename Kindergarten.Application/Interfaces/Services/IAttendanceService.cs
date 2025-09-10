using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IAttendanceService
{
    Task MarkAttendanceAsync(AttendanceCreateDto dto);
    Task<IEnumerable<AttendanceReadDto>> GetStudentAttendanceAsync(Guid studentId);
    Task<IEnumerable<AttendanceReadDto>> GetDailyAttendanceAsync(DateTime date);
    Task<AttendanceRateDto> GetStudentAttendanceRateAsync(Guid studentId, DateTime from, DateTime to);
    Task<AttendanceAggregateRateDto> GetAllStudentsAttendanceRateAsync(DateTime from, DateTime to);
    Task<AttendanceAggregateRateDto> GetTeacherStudentsAttendanceRateAsync(Guid teacherId, DateTime from, DateTime to);
    Task<AttendanceAggregateRateDto> GetParentChildrenAttendanceRateAsync(Guid parentId, DateTime from, DateTime to);
    Task<double> GetStudentAttendancePercentageAsync(Guid studentId);
}
