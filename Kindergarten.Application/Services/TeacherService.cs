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
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository teacherRepository, IClassroomRepository classroomRepository, IIdentityService identityService, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _classroomRepository = classroomRepository;
        _identityService = identityService;
        _mapper = mapper;
    }

    public async Task<TeacherReadDto> CreateTeacherAsync(TeacherCreateDto dto)
    {
        var userId = await _identityService.CreateUserAsync(dto.Email, dto.PhoneNumber, dto.FullName, dto.Password, "Teacher");

        var teacher = new Teacher(dto.FullName, dto.PhoneNumber, dto.IsActive)
        {
            SubjectId = dto.SubjectId
        };
        teacher.LinkApplicationUser(userId);

        if (dto.ClassroomIds != null)
        {
            foreach (var classroomId in dto.ClassroomIds)
            {
                teacher.TeacherClassrooms.Add(new TeacherClassroom(teacher.Id, classroomId));
            }
        }

        await _teacherRepository.AddAsync(teacher);
        return _mapper.Map<TeacherReadDto>(teacher);
    }

    public async Task<IEnumerable<TeacherReadDto>> GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllTeachersAsync();
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

    public async Task<IEnumerable<ClassroomReadDto>> GetClassroomsByTeacherIdAsync(Guid teacherId)
    {
        var classrooms = await _classroomRepository.FindAsync(
            c => c.TeacherClassrooms.Any(tc => tc.TeacherId == teacherId)
        );
        return _mapper.Map<IEnumerable<ClassroomReadDto>>(classrooms);
    }

    public async Task DeleteTeacherAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Teacher not found");

        await _teacherRepository.DeleteAsync(id);
    }

    public async Task<AssignedSubjectDto> GetAssignedSubjectAsync(Guid teacherId)
    {
        var teacher = await _teacherRepository.GetByIdWithSubjectAsync(teacherId);
        if (teacher == null)
            return null;

        if (teacher.SubjectId != Guid.Empty && teacher.Subject != null)
        {
            return new AssignedSubjectDto
            {
                Assigned = true,
                SubjectName = teacher.Subject.Name
            };
        }

        return new AssignedSubjectDto { Assigned = false };
    }
}
