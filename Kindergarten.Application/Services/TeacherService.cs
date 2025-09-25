using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    private readonly IClassSessionRepository _classSessionRepository;

    public TeacherService(
        IUnitOfWork unitOfWork,
        IIdentityService identityService,
        IMapper mapper,
        IClassSessionRepository classSessionRepository)
    {
        _unitOfWork = unitOfWork;
        _identityService = identityService;
        _mapper = mapper;
        _classSessionRepository = classSessionRepository;
    }

    public async Task<TeacherReadDto> CreateTeacherAsync(TeacherCreateDto dto)
    {
        var userId = await _identityService.CreateUserAsync(
            dto.Email, dto.PhoneNumber, dto.FullName, dto.Password, "Teacher");

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

        await _unitOfWork.Repository<Teacher>().AddAsync(teacher);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TeacherReadDto>(teacher);
    }

    public async Task<IEnumerable<TeacherReadDto>> GetAllAsync()
    {
        var teachers = await _unitOfWork.Repository<Teacher>().GetAllAsync();
        return _mapper.Map<IEnumerable<TeacherReadDto>>(teachers);
    }

    public async Task<TeacherReadDto?> GetByIdAsync(Guid id)
    {
        var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(id);
        return _mapper.Map<TeacherReadDto?>(teacher);
    }

    public async Task UpdateTeacherAsync(Guid id, TeacherUpdateDto dto)
    {
        var repo = _unitOfWork.Repository<Teacher>();
        var teacher = await repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Teacher not found");

        _mapper.Map(dto, teacher);
        await repo.UpdateAsync(teacher);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeactivateTeacherAsync(Guid id)
    {
        var repo = _unitOfWork.Repository<Teacher>();
        var teacher = await repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Teacher not found");

        teacher.Deactivate();
        await repo.UpdateAsync(teacher);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<StudentReadDto>> GetClassStudentsAsync(Guid teacherId)
    {
        var classrooms = await _unitOfWork.Repository<Classroom>()
            .FindAsync(c => c.TeacherClassrooms.Any(tc => tc.TeacherId == teacherId));

        var classroomIds = classrooms.Select(c => c.Id).ToList();

        var students = await _unitOfWork.Repository<Student>()
            .FindAsync(s => s.ClassroomId.HasValue && classroomIds.Contains(s.ClassroomId.Value));

        return _mapper.Map<IEnumerable<StudentReadDto>>(students);
    }

    public async Task<IEnumerable<ClassroomReadDto>> GetClassroomsByTeacherIdAsync(Guid teacherId)
    {
        var classrooms = await _unitOfWork.Repository<Classroom>()
            .FindAsync(c => c.TeacherClassrooms.Any(tc => tc.TeacherId == teacherId));

        return _mapper.Map<IEnumerable<ClassroomReadDto>>(classrooms);
    }

    public async Task DeleteTeacherAsync(Guid id)
    {
        var repo = _unitOfWork.Repository<Teacher>();
        var teacher = await repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Teacher not found");

        await repo.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<AssignedSubjectDto> GetAssignedSubjectAsync(Guid teacherId)
    {
        var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(teacherId);
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
    // ME
    public async Task<TeacherReadDto?> GetMyProfileAsync()
    {
        var userId = _identityService.GetUserId();
        var teacher = await _unitOfWork.Repository<Teacher>()
            .FindAsync(t => t.ApplicationUserId == userId.ToString());

        return _mapper.Map<TeacherReadDto?>(teacher.FirstOrDefault());
    }

    public async Task<IEnumerable<TeacherClassroomReadDto>> GetMyClassroomsAsync()
    {
        var userId = _identityService.GetUserId();
        var teacher = (await _unitOfWork.Repository<Teacher>()
            .FindAsync(t => t.ApplicationUserId == userId.ToString()))
            .FirstOrDefault();

        if (teacher == null) return Enumerable.Empty<TeacherClassroomReadDto>();

        // ✅ نجيب الفصول مع الطلاب
        var classrooms = await _unitOfWork.Repository<Classroom>()
            .FindAsync(c => c.TeacherClassrooms.Any(tc => tc.TeacherId == teacher.Id),
                       include: q => q.Include(c => c.Students));

        return _mapper.Map<IEnumerable<TeacherClassroomReadDto>>(classrooms);
    }


    public async Task<AssignedSubjectDto> GetMyAssignedSubjectAsync()
    {
        var userId = _identityService.GetUserId();
        var teacher = (await _unitOfWork.Repository<Teacher>()
            .FindAsync(t => t.ApplicationUserId == userId.ToString())).FirstOrDefault();

        if (teacher == null)
            return new AssignedSubjectDto { Assigned = false };

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

    public async Task<IEnumerable<ClassSessionReadDto>> GetMyClassSessionsAsync()
    {
        var userId = _identityService.GetUserId();
        var teacher = (await _unitOfWork.Repository<Teacher>()
            .FindAsync(t => t.ApplicationUserId == userId.ToString())).FirstOrDefault();

        if (teacher == null) return Enumerable.Empty<ClassSessionReadDto>();

        var sessions = await _classSessionRepository.GetByTeacherIdAsync(teacher.Id);

        return _mapper.Map<IEnumerable<ClassSessionReadDto>>(sessions);
    }
}
