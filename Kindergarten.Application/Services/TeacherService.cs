using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IClassroomRepository _classroomRepository;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository teacherRepository, IClassroomRepository classroomRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _classroomRepository = classroomRepository;
        _mapper = mapper;
    }

    public async Task<TeacherReadDto> CreateTeacherAsync(TeacherCreateDto dto)
    {
        var teacher = _mapper.Map<Teacher>(dto);
        await _teacherRepository.AddAsync(teacher);
        return _mapper.Map<TeacherReadDto>(teacher);
    }

    public async Task<IEnumerable<TeacherReadDto>> GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TeacherReadDto>>(teachers);
    }

    public async Task<TeacherReadDto?> GetByIdAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        return _mapper.Map<TeacherReadDto?>(teacher);
    }

    public async Task UpdateTeacherAsync(Guid id, TeacherUpdateDto dto)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Teacher not found");

        _mapper.Map(dto, teacher);
        await _teacherRepository.UpdateAsync(teacher);
    }

    public async Task DeactivateTeacherAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Teacher not found");

        teacher.Deactivate();
        await _teacherRepository.UpdateAsync(teacher);
    }

    public async Task<IEnumerable<StudentReadDto>> GetClassStudentsAsync(Guid teacherId)
    {
        var students = await _classroomRepository.GetStudentsByTeacherIdAsync(teacherId);
        return _mapper.Map<IEnumerable<StudentReadDto>>(students);
    }
}
