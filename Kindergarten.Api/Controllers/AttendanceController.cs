using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<IActionResult> Mark(AttendanceCreateDto dto)
    {
        await _attendanceService.MarkAttendanceAsync(dto);
        return Ok();
    }

    [HttpGet("student/{studentId:guid}")]
    public async Task<IActionResult> GetStudentAttendance(Guid studentId)
        => Ok(await _attendanceService.GetStudentAttendanceAsync(studentId));

    [HttpGet("date/{date}")]
    public async Task<IActionResult> GetDailyAttendance(DateTime date)
        => Ok(await _attendanceService.GetDailyAttendanceAsync(date));

    [HttpGet("rate")]
    public async Task<IActionResult> GetAllStudentsRate([FromQuery] DateTime from, [FromQuery] DateTime to)
        => Ok(await _attendanceService.GetAllStudentsAttendanceRateAsync(from, to));

    [HttpGet("rate/student/{studentId:guid}")]
    public async Task<IActionResult> GetStudentRate(Guid studentId, [FromQuery] DateTime from, [FromQuery] DateTime to)
        => Ok(await _attendanceService.GetStudentAttendanceRateAsync(studentId, from, to));

    [HttpGet("rate/teacher/{teacherId:guid}")]
    public async Task<IActionResult> GetTeacherStudentsRate(Guid teacherId, [FromQuery] DateTime from, [FromQuery] DateTime to)
        => Ok(await _attendanceService.GetTeacherStudentsAttendanceRateAsync(teacherId, from, to));

    [HttpGet("rate/parent/{parentId:guid}")]
    public async Task<IActionResult> GetParentChildrenRate(Guid parentId, [FromQuery] DateTime from, [FromQuery] DateTime to)
        => Ok(await _attendanceService.GetParentChildrenAttendanceRateAsync(parentId, from, to));
}
