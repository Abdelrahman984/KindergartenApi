using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/teacher/me")]
[Authorize(Policy = "CanManageTeachers")] // 👨‍🏫 Teacher أو 👑 Admin
public class TeacherMeController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherMeController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var profile = await _teacherService.GetMyProfileAsync();
        return Ok(profile);
    }

    [HttpGet("classrooms")]
    public async Task<IActionResult> GetMyClassrooms()
    {
        var classrooms = await _teacherService.GetMyClassroomsAsync();
        return Ok(classrooms);
    }

    [HttpGet("subject")]
    public async Task<IActionResult> GetMyAssignedSubject()
    {
        var subject = await _teacherService.GetMyAssignedSubjectAsync();
        return Ok(subject);
    }

    [HttpGet("sessions")]
    public async Task<IActionResult> GetMyClassSessions()
    {
        var sessions = await _teacherService.GetMyClassSessionsAsync();
        return Ok(sessions);
    }
}
