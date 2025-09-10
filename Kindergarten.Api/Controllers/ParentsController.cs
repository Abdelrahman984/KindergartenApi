using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParentsController : ControllerBase
{
    private readonly IParentService _parentService;
    private readonly IStudentService _studentService;

    public ParentsController(IParentService parentService, IStudentService studentService)
    {
        _parentService = parentService;
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _parentService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var parent = await _parentService.GetByIdAsync(id);
        return parent is null ? NotFound() : Ok(parent);
    }
    // Get parent by phone number
    [HttpGet("by-phone")]
    public async Task<IActionResult> GetByPhoneNumber([FromQuery] string phoneNumber)
    {
        var parent = await _parentService.GetByPhoneAsync(phoneNumber);
        return parent is null ? NotFound() : Ok(parent);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParentCreateDto dto)
    {
        var parent = await _parentService.CreateParentAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = parent.Id }, parent);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, ParentUpdateDto dto)
    {
        await _parentService.UpdateInfoAsync(id, dto);
        return NoContent();
    }

    [HttpGet("{id:guid}/students")]
    public async Task<IActionResult> GetStudents(Guid id)
        => Ok(await _studentService.GetByParentIdAsync(id));

    [HttpGet("{id:guid}/with-childs")]
    public async Task<IActionResult> GetParentWithChilds(Guid id)
        => Ok(await _parentService.GetWithChildrenAsync(id));
}
