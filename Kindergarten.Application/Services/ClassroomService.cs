using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services;

public class ClassroomService : IClassroomService
{
    private readonly IClassroomRepository _classroomRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;

    public ClassroomService(
        IClassroomRepository classroomRepository,
        ITeacherRepository teacherRepository,
        IMapper mapper)
    {
        _classroomRepository = classroomRepository;
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task<ClassroomReadDto> CreateClassroomAsync(ClassroomCreateDto dto)
    {
        var classroom = _mapper.Map<Classroom>(dto);
        await _classroomRepository.AddAsync(classroom);
        return _mapper.Map<ClassroomReadDto>(classroom);
    }

    public async Task<IEnumerable<ClassroomReadDto>> GetAllAsync()
    {
        var classrooms = await _classroomRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClassroomReadDto>>(classrooms);
    }

    public async Task<ClassroomReadDto?> GetByIdAsync(Guid id)
    {
        var classroom = await _classroomRepository.GetByIdAsync(id);
        return _mapper.Map<ClassroomReadDto?>(classroom);
    }

    public async Task AssignTeacherAsync(Guid classroomId, Guid teacherId)
    {
        var classroom = await _classroomRepository.GetByIdAsync(classroomId)
            ?? throw new KeyNotFoundException("Classroom not found");

        var teacher = await _teacherRepository.GetByIdAsync(teacherId)
            ?? throw new KeyNotFoundException("Teacher not found");

        classroom.AssignTeacher(teacher.Id);
        await _classroomRepository.UpdateAsync(classroom);
    }

    public async Task UpdateCapacityAsync(Guid classroomId, int newCapacity)
    {
        var classroom = await _classroomRepository.GetByIdAsync(classroomId)
            ?? throw new KeyNotFoundException("Classroom not found");

        classroom.UpdateCapacity(newCapacity);
        await _classroomRepository.UpdateAsync(classroom);
    }

    public async Task<IEnumerable<StudentReadDto>> GetStudentsAsync(Guid classroomId)
    {
        var classroom = await _classroomRepository.GetWithStudentsAsync(classroomId)
            ?? throw new KeyNotFoundException("Classroom not found");

        return _mapper.Map<IEnumerable<StudentReadDto>>(classroom.Students);
    }

    public async Task<ClassroomReportDto> GetOverviewAsync()
    {
        var total = await _classroomRepository.GetTotalCountAsync();
        var avgCapacity = await _classroomRepository.GetAverageCapacityAsync();
        var withStudents = await _classroomRepository.GetWithStudentsCountAsync();
        var withoutStudents = await _classroomRepository.GetWithoutStudentsCountAsync();
        var studentCounts = await _classroomRepository.GetStudentCountsAsync();

        return new ClassroomReportDto
        {
            TotalClassrooms = total,
            AverageCapacity = avgCapacity,
            WithStudents = withStudents,
            WithoutStudents = withoutStudents,
            StudentCounts = studentCounts
        };
    }
}
