using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IClassroomService
{
    Task<ClassroomReadDto> CreateClassroomAsync(ClassroomCreateDto dto);
    Task<IEnumerable<ClassroomReadDto>> GetAllAsync();
    Task<ClassroomReadDto?> GetByIdAsync(Guid id);
    Task AssignTeacherAsync(Guid classroomId, Guid teacherId);
    Task UpdateCapacityAsync(Guid classroomId, int newCapacity);
    Task<IEnumerable<StudentReadDto>> GetStudentsAsync(Guid classroomId);
    Task<ClassroomReadDto> UpdateClassroomAsync(Guid id, ClassroomUpdateDto dto);
    Task DeleteClassroomAsync(Guid id);
    Task<ClassroomReportDto> GetOverviewAsync();
    Task<IEnumerable<ClassroomStudentCountDto>> GetClassroomStudentCountsAsync();
    Task<List<ClassroomDetailsDto>> GetAllClassroomDetailsAsync(CancellationToken ct = default);
}
