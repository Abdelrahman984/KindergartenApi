using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _teacherService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        return teacher is null ? NotFound() : Ok(teacher);
    }

    [HttpGet("{teacherId:guid}/students")]
    public async Task<IActionResult> GetTeacherStudents(Guid teacherId)
    {
        var students = await _teacherService.GetClassStudentsAsync(teacherId);
        return Ok(students);
    }

    [HttpGet("{teacherId:guid}/classrooms")]
    public async Task<IActionResult> GetTeacherClassrooms(Guid teacherId)
    {
        var classrooms = await _teacherService.GetClassroomsByTeacherIdAsync(teacherId);
        return Ok(classrooms);
    }

    [HttpGet("{teacherId:guid}/assigned-subject")]
    public async Task<IActionResult> GetTeacherAssignedSubject(Guid teacherId)
    {
        var result = await _teacherService.GetAssignedSubjectAsync(teacherId);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeacherCreateDto dto)
    {
        var teacher = await _teacherService.CreateTeacherAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, TeacherUpdateDto dto)
    {
        await _teacherService.UpdateTeacherAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        await _teacherService.DeactivateTeacherAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTeacher(Guid id)
    {
        await _teacherService.DeleteTeacherAsync(id);
        return NoContent();
    }
}
