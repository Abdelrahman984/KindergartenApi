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
    private readonly IParentService _parentService;
    private readonly IClassroomRepository _classroomRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IAttendanceService attendanceService, IMapper mapper, IClassroomRepository classroomRepository, IParentService parentService)
    {
        _studentRepository = studentRepository;
        _attendanceService = attendanceService;
        _mapper = mapper;
        _classroomRepository = classroomRepository;
        _parentService = parentService;
    }

    public async Task<StudentReadDto> CreateStudentAsync(StudentCreateDto dto)
    {
        // Validate classroom
        var classroom = await _classroomRepository.GetByIdAsync(dto.ClassroomId)
            ?? throw new ArgumentException("Invalid classroom selected");

        // Check if parent exists
        var parent = await _parentService.GetByPhoneAsync(dto.ParentPhone);

        if (parent == null)
        {
            string fullFatherName = $"{dto.FatherName} {dto.GrandpaName}";
            var newParent = new ParentCreateDto(fullFatherName, dto.ParentPhone, dto.Address);

            // نخلي CreateParentAsync يرجع ParentReadDto أو Entity
            parent = await _parentService.CreateParentAsync(newParent);
        }

        // Create student
        var student = _mapper.Map<Student>(dto);
        student.AssignParent(parent.Id);
        student.AssignClassroom(classroom.Id);

        await _studentRepository.AddAsync(student);

        // Map to DTO
        var studentDto = _mapper.Map<StudentReadDto>(student);
        studentDto.ParentFullName = parent.FullName;
        studentDto.ParentPhone = parent.PhoneNumber;
        studentDto.ParentAddress = parent.Address;
        studentDto.ClassroomName = classroom.Name;

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
}
