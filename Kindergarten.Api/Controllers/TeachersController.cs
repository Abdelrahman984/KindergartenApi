using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Policy = "AdminOnly")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    // 🔹 Create Teacher
    [HttpPost]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateDto dto)
    {
        var teacher = await _teacherService.CreateTeacherAsync(dto);
        return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
    }

    // 🔹 Get all Teachers
    [HttpGet]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetAllTeachers()
    {
        var teachers = await _teacherService.GetAllAsync();
        return Ok(teachers);
    }

    // 🔹 Get Teacher by Id
    [HttpGet("{id:guid}")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetTeacherById(Guid id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        if (teacher == null)
            return NotFound();
        return Ok(teacher);
    }

    // 🔹 Update Teacher
    [HttpPut("{id:guid}")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> UpdateTeacher(Guid id, [FromBody] TeacherUpdateDto dto)
    {
        await _teacherService.UpdateTeacherAsync(id, dto);
        return NoContent();
    }

    // 🔹 Deactivate Teacher
    [HttpPatch("{id:guid}/deactivate")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> DeactivateTeacher(Guid id)
    {
        await _teacherService.DeactivateTeacherAsync(id);
        return NoContent();
    }

    // 🔹 Delete Teacher
    [HttpDelete("{id:guid}")]
    //[Authorize(Policy = "AdminOnly")] // 🛑 الحذف حساس → أدمن فقط
    public async Task<IActionResult> DeleteTeacher(Guid id)
    {
        await _teacherService.DeleteTeacherAsync(id);
        return NoContent();
    }

    // 🔹 Get students in Teacher's Classrooms
    [HttpGet("{id:guid}/students")]
    //[Authorize(Policy = "CanManageTeachers")] // 👨‍🏫 Teacher أو 👑 Admin
    public async Task<IActionResult> GetClassStudents(Guid id)
    {
        var students = await _teacherService.GetClassStudentsAsync(id);
        return Ok(students);
    }

    // 🔹 Get Classrooms for Teacher
    [HttpGet("{id:guid}/classrooms")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetClassrooms(Guid id)
    {
        var classrooms = await _teacherService.GetClassroomsByTeacherIdAsync(id);
        return Ok(classrooms);
    }

    // 🔹 Get Assigned Subject
    [HttpGet("{id:guid}/subject")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetAssignedSubject(Guid id)
    {
        var subject = await _teacherService.GetAssignedSubjectAsync(id);
        return Ok(subject);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var stats = await _teacherService.GetStatsAsync();
        return Ok(stats);
    }
}
