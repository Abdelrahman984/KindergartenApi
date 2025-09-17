using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services
{
    public class ClassSessionService : IClassSessionService
    {
        private readonly IClassSessionRepository _repository;
        private readonly IMapper _mapper;

        public ClassSessionService(IClassSessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassSessionReadDto>> GetAllAsync()
        {
            var sessions = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClassSessionReadDto>>(sessions);
        }

        public async Task<ClassSessionReadDto> GetByIdAsync(Guid id)
        {
            var session = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClassSessionReadDto>(session);
        }

        public async Task<ClassSessionReadDto> CreateAsync(ClassSessionCreateDto dto)
        {
            var session = _mapper.Map<ClassSession>(dto);
            await _repository.AddAsync(session);
            return _mapper.Map<ClassSessionReadDto>(session);
        }

        public async Task<ClassSessionReadDto> UpdateAsync(ClassSessionUpdateDto dto)
        {
            var session = await _repository.GetByIdAsync(dto.Id);
            if (session == null) return null;

            _mapper.Map(dto, session);
            await _repository.UpdateAsync(session);

            return _mapper.Map<ClassSessionReadDto>(session);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var session = await _repository.GetByIdAsync(id);
            if (session == null) return false;

            await _repository.DeleteAsync(session);
            return true;
        }

        public async Task<IEnumerable<ClassSessionReadDto>> GetByClassroomIdAsync(Guid classroomId)
        {
            var sessions = await _repository.GetByClassroomIdAsync(classroomId);
            return _mapper.Map<IEnumerable<ClassSessionReadDto>>(sessions);
        }

        public async Task<IEnumerable<ClassSessionReadDto>> GetByTeacherIdAsync(Guid teacherId)
        {
            var sessions = await _repository.GetByTeacherIdAsync(teacherId);
            return _mapper.Map<IEnumerable<ClassSessionReadDto>>(sessions);
        }

        public async Task<IEnumerable<ClassSessionReadDto>> GetBySubjectIdAsync(Guid subjectId)
        {
            var sessions = await _repository.GetBySubjectIdAsync(subjectId);
            return _mapper.Map<IEnumerable<ClassSessionReadDto>>(sessions);
        }
    }
}
