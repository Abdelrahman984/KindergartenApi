using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassSessionController : ControllerBase
    {
        private readonly IClassSessionService _service;

        public ClassSessionController(IClassSessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _service.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var session = await _service.GetByIdAsync(id);
            if (session == null) return NotFound();
            return Ok(session);
        }

        [HttpGet("ByClassroom/{classroomId}")]
        public async Task<IActionResult> GetByClassroomId(Guid classroomId)
        {
            var sessions = await _service.GetByClassroomIdAsync(classroomId);
            return Ok(sessions);
        }

        [HttpGet("ByTeacher/{teacherId}")]
        public async Task<IActionResult> GetByTeacherId(Guid teacherId)
        {
            var sessions = await _service.GetByTeacherIdAsync(teacherId);
            return Ok(sessions);
        }

        [HttpGet("BySubject/{subjectId}")]
        public async Task<IActionResult> GetBySubjectId(Guid subjectId)
        {
            var sessions = await _service.GetBySubjectIdAsync(subjectId);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClassSessionCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClassSessionUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
