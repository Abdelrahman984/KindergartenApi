using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _service.GetAllAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subject = await _service.GetByIdAsync(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SubjectUpdateDto dto)
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
