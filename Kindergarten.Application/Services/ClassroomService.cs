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
    public async Task<IEnumerable<ClassroomStudentCountDto>> GetClassroomStudentCountsAsync()
    {
        var studentCounts = await _classroomRepository.GetStudentCountsAsync();
        return studentCounts;
    }
    public async Task<List<ClassroomDetailsDto>> GetAllClassroomDetailsAsync(CancellationToken ct = default)
    {
        var classrooms = await _classroomRepository.GetAllWithRelationsAsync(ct);
        return _mapper.Map<List<ClassroomDetailsDto>>(classrooms);
    }

    public async Task<ClassroomReadDto> UpdateClassroomAsync(Guid id, ClassroomUpdateDto dto)
    {
        var classroom = await _classroomRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Classroom not found");

        classroom.UpdateInfo(dto.Name, dto.Capacity);

        await _classroomRepository.UpdateClassroomAsync(classroom);

        return _mapper.Map<ClassroomReadDto>(classroom);
    }

    public async Task DeleteClassroomAsync(Guid id)
    {
        var classroom = await _classroomRepository.GetByIdAsync(id);
        if (classroom == null)
            throw new KeyNotFoundException("Classroom not found");

        await _classroomRepository.DeleteAsync(id);
    }
}
