using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IAttendanceService _attendanceService;
    private readonly IParentRepository _parentRepository;
    private readonly IClassroomRepository _classroomRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IAttendanceService attendanceService, IMapper mapper, IClassroomRepository classroomRepository, IParentRepository parentRepository)
    {
        _studentRepository = studentRepository;
        _attendanceService = attendanceService;
        _mapper = mapper;
        _classroomRepository = classroomRepository;
        _parentRepository = parentRepository;
    }

    public async Task<StudentReadDto> CreateStudentAsync(StudentCreateDto dto)
    {
        // 1️⃣ هل الأب موجود برقم التليفون؟
        var parent = await _parentRepository.GetByPhoneAsync(dto.ParentPhone);

        // 2️⃣ لو مش موجود، أنشئ Parent جديد
        if (parent == null)
        {
            parent = new Parent(dto.ParentName, dto.ParentPhone, dto.ParentAddress);
            await _parentRepository.AddAsync(parent);
        }

        // 3️⃣ أنشئ الطالب
        var student = new Student(dto.FullName, dto.DateOfBirth, dto.Address);
        student.AssignParent(parent.Id);
        student.AssignClassroom(dto.ClassroomId);

        await _studentRepository.AddAsync(student);

        // 4️⃣ رجّع StudentReadDto عن طريق AutoMapper
        var studentDto = _mapper.Map<StudentReadDto>(student);

        // 5️⃣ حساب AttendanceRate (ممكن تستعمل _attendanceService بعدين)
        studentDto.AttendanceRate = 0;

        return studentDto;
    }



    public async Task<IEnumerable<StudentReadDto>> GetAllAsync(Guid? classroomId = null, string? name = null, bool? isActive = null)
    {
        var students = await _studentRepository.GetByFilterAsync(classroomId, name, isActive);
        var studentDtos = _mapper.Map<IEnumerable<StudentReadDto>>(students);
        return studentDtos;
    }

    public async Task<StudentReadDto?> GetByIdAsync(Guid id)
    {
        // Ensure related data is loaded for mapping
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null) return null;

        var studentDto = _mapper.Map<StudentReadDto>(student);
        return studentDto;
    }

    public async Task UpdateStudentAsync(Guid id, StudentUpdateDto dto)
    {
        var student = await _studentRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Student not found");

        _mapper.Map(dto, student);
        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeactivateStudentAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Student not found");

        student.Deactivate();
        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeleteStudentAsync(Guid id)
    {
        await _studentRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<StudentReadDto>> GetByClassroomIdAsync(Guid classroomId)
    {
        var students = await _studentRepository.GetByClassroomIdAsync(classroomId);
        var studentDtos = _mapper.Map<IEnumerable<StudentReadDto>>(students);
        return studentDtos;
    }

    public async Task<IEnumerable<StudentReadDto>> GetByParentIdAsync(Guid parentId)
    {
        var students = await _studentRepository.GetByParentIdAsync(parentId);
        var studentDtos = _mapper.Map<IEnumerable<StudentReadDto>>(students);
        return studentDtos;
    }

    public async Task<StudentStatsDto> GetStatsAsync()
    {
        return new StudentStatsDto
        {
            Total = await _studentRepository.GetTotalCountAsync(),
            Active = await _studentRepository.GetActiveCountAsync(),
            Inactive = await _studentRepository.GetInactiveCountAsync(),
            AverageAge = await _studentRepository.GetAverageAgeAsync()
        };
    }

}
