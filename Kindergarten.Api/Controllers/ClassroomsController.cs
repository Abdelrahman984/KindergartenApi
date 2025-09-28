using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomsController : ControllerBase
{
    private readonly IClassroomService _classroomService;

    public ClassroomsController(IClassroomService classroomService)
    {
        _classroomService = classroomService;
    }

    [HttpGet]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetAll()
        => Ok(await _classroomService.GetAllAsync());

    [HttpGet("{id:guid}")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var classroom = await _classroomService.GetByIdAsync(id);
        return classroom is null ? NotFound() : Ok(classroom);
    }

    [HttpPost]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create(ClassroomCreateDto dto)
    {
        var classroom = await _classroomService.CreateClassroomAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = classroom.Id }, classroom);
    }

    [HttpPut("{id:guid}/capacity")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> UpdateCapacity(Guid id, [FromQuery] int capacity)
    {
        await _classroomService.UpdateCapacityAsync(id, capacity);
        return NoContent();
    }

    [HttpPut("{id:guid}/assign-teacher/{teacherId:guid}")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> AssignTeacher(Guid id, Guid teacherId)
    {
        await _classroomService.AssignTeacherAsync(id, teacherId);
        return NoContent();
    }

    [HttpGet("{id:guid}/students")]
    //[Authorize(Policy = "CanManageTeachers")]
    public async Task<IActionResult> GetStudents(Guid id)
        => Ok(await _classroomService.GetStudentsAsync(id));

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var stats = await _classroomService.GetOverviewAsync();
        return Ok(stats);
    }

    [HttpGet("student-counts")]
    public async Task<IActionResult> GetStudentCounts()
        => Ok(await _classroomService.GetClassroomStudentCountsAsync());

    [HttpGet("details")]
    public async Task<IActionResult> GetAllDetails(CancellationToken ct)
        => Ok(await _classroomService.GetAllClassroomDetailsAsync(ct));

    [HttpPut("{id:guid}")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ClassroomUpdateDto dto)
    {
        var updated = await _classroomService.UpdateClassroomAsync(id, dto);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    //[Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _classroomService.DeleteClassroomAsync(id);
        return NoContent();
    }
}
