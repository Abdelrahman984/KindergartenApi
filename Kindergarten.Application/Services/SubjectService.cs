using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Repositories;

namespace Kindergarten.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectReadDto>> GetAllAsync()
        {
            var subjects = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectReadDto>>(subjects);
        }

        public async Task<SubjectReadDto> GetByIdAsync(Guid id)
        {
            var subject = await _repository.GetByIdAsync(id);
            return _mapper.Map<SubjectReadDto>(subject);
        }

        public async Task<SubjectReadDto> CreateAsync(SubjectCreateDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            await _repository.AddAsync(subject);
            return _mapper.Map<SubjectReadDto>(subject);
        }

        public async Task<SubjectReadDto> UpdateAsync(SubjectUpdateDto dto)
        {
            var subject = await _repository.GetByIdAsync(dto.Id);
            if (subject == null) return null;

            _mapper.Map(dto, subject);
            await _repository.UpdateAsync(subject);

            return _mapper.Map<SubjectReadDto>(subject);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var subject = await _repository.GetByIdAsync(id);
            if (subject == null) return false;

            await _repository.DeleteAsync(subject);
            return true;
        }
    }
}
