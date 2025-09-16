using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectReadDto>> GetAllAsync();
        Task<SubjectReadDto> GetByIdAsync(Guid id);
        Task<SubjectReadDto> CreateAsync(SubjectCreateDto dto);
        Task<SubjectReadDto> UpdateAsync(SubjectUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
