using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = "CanManageTeachers")]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _service.GetAllAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "CanManageTeachers")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subject = await _service.GetByIdAsync(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create([FromBody] SubjectCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPost("{subjectId}/teachers")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateTeachers(Guid subjectId, [FromBody] List<Guid> teacherIds)
        {
            await _service.UpdateSubjectTeachersAsync(subjectId, teacherIds);
            return NoContent();
        }

        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SubjectUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
