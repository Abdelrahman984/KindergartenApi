using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(policy: "CanManageTeachers")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    // POST: api/attendance
    [HttpPost]
    public async Task<ActionResult<AttendanceReadDto>> MarkAttendance([FromBody] AttendanceCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _attendanceService.MarkAttendanceAsync(dto);
        return Ok(result);
        // أو CreatedAtAction لو عندك GetById
    }

    // GET: api/attendance/by-date/2025-09-11
    [HttpGet("by-date/{date}")]
    public async Task<ActionResult<IEnumerable<AttendanceReadDto>>> GetByDate(DateTime date)
    {
        var result = await _attendanceService.GetByDateAsync(date);
        return Ok(result);
    }

    // GET: api/attendance/student/{studentId}
    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<IEnumerable<AttendanceReadDto>>> GetByStudent(Guid studentId)
    {
        var result = await _attendanceService.GetByStudentAsync(studentId);
        return Ok(result);
    }

    // GET: api/attendance/daily/full?date=2025-09-14
    [HttpGet("daily/full")]
    public async Task<ActionResult<IEnumerable<AttendanceReadDto>>> GetDailyWithUnmarked([FromQuery] DateTime? date)
    {
        var targetDate = date?.Date ?? DateTime.Today;
        var result = await _attendanceService.GetDailyWithUnmarkedAsync(targetDate);
        return Ok(result);
    }

    // --- Stats ---
    [HttpGet("daily/stats")]
    public async Task<ActionResult<AttendanceStatsDto>> GetDailyStats([FromQuery] DateTime? date)
    {
        var targetDate = date?.Date ?? DateTime.Today;
        return Ok(await _attendanceService.GetDailyStatsAsync(targetDate));
    }

    [HttpGet("student/{studentId}/percentage")]
    public async Task<ActionResult<double>> GetStudentPercentage(Guid studentId)
        => Ok(await _attendanceService.GetStudentAttendancePercentageAsync(studentId));

    [HttpGet("students/percentages")]
    public async Task<ActionResult<List<StudentAttendancePercentageDto>>> GetAllStudentsPercentages()
        => Ok(await _attendanceService.GetAllStudentsPercentagesAsync());

    [HttpGet("overall")]
    public async Task<ActionResult<double>> GetOverallPercentage()
        => Ok(await _attendanceService.GetOverallAttendancePercentageAsync());

    [HttpGet("trends")]
    public async Task<ActionResult<AttendanceTrendDto>> GetTrends([FromQuery] DateTime? today)
    {
        var targetDate = today?.Date ?? DateTime.Today;
        return Ok(await _attendanceService.GetTrendsAsync(targetDate));
    }

    [HttpGet("weekly/report")]
    public async Task<IActionResult> GetWeeklyReport([FromQuery] DateTime date)
    {
        var report = await _attendanceService.GetWeeklyReportAsync(date);
        return Ok(report);
    }

    [HttpGet("monthly/report")]
    public async Task<IActionResult> GetMonthlyReport([FromQuery] DateTime date)
    {
        var report = await _attendanceService.GetMonthlyReportAsync(date);
        return Ok(report);
    }


}
