using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IAttendanceService _attendanceService;

    public StudentsController(IStudentService studentService, IAttendanceService attendanceService)
    {
        _studentService = studentService;
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Guid? classroomId, [FromQuery] string? name, [FromQuery] bool? isActive)
        => Ok(await _studentService.GetAllAsync(classroomId, name, isActive));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _studentService.GetByIdAsync(id);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentCreateDto dto)
    {
        var student = await _studentService.CreateStudentAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, StudentUpdateDto dto)
    {
        await _studentService.UpdateStudentAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        await _studentService.DeactivateStudentAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}/hard")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _studentService.DeleteStudentAsync(id);
        return NoContent();
    }

    [HttpGet("by-classroom/{classroomId:guid}")]
    public async Task<IActionResult> GetByClassroom(Guid classroomId)
        => Ok(await _studentService.GetByClassroomIdAsync(classroomId));

    [HttpGet("by-parent/{parentId:guid}")]
    public async Task<IActionResult> GetByParent(Guid parentId)
        => Ok(await _studentService.GetByParentIdAsync(parentId));

    [HttpGet("attendance/{id:guid}")]
    public async Task<IActionResult> GetAttendance(Guid id)
        => Ok(await _attendanceService.GetStudentAttendanceAsync(id));
}
