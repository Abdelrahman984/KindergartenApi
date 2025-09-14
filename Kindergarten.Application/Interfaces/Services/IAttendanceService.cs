using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IAttendanceService
{
    Task<AttendanceReadDto> MarkAttendanceAsync(AttendanceCreateDto dto);
    Task<IEnumerable<AttendanceReadDto>> GetByDateAsync(DateTime date);
    Task<IEnumerable<AttendanceReadDto>> GetByStudentAsync(Guid studentId);
    Task<IEnumerable<AttendanceReadDto>> GetDailyWithUnmarkedAsync(DateTime date);

    Task<AttendanceReportDto> GetWeeklyReportAsync(DateTime anyDate);
    Task<AttendanceReportDto> GetMonthlyReportAsync(DateTime anyDate);

    // Stats methods
    Task<AttendanceStatsDto> GetDailyStatsAsync(DateTime date);
    Task<double> GetStudentAttendancePercentageAsync(Guid studentId);
    Task<double> GetOverallAttendancePercentageAsync();
    Task<AttendanceTrendDto> GetTrendsAsync(DateTime today);
    Task<List<StudentAttendancePercentageDto>> GetAllStudentsPercentagesAsync();
}
