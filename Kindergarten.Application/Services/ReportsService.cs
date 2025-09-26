// Application/Services/ReportsService.cs
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;

namespace Kindergarten.Application.Services;

public class ReportsService : IReportsService
{
    private readonly IStudentService _studentService;
    private readonly ITeacherService _teacherService;
    private readonly IClassroomService _classroomService;

    public ReportsService(IStudentService studentService, ITeacherService teacherService, IClassroomService classroomService)
    {
        _studentService = studentService;
        _teacherService = teacherService;
        _classroomService = classroomService;
    }

    public async Task<ReportsOverviewDto> GetOverviewAsync()
    {
        return new ReportsOverviewDto
        {
            StudentStats = await _studentService.GetStatsAsync(),
            TeacherStats = await _teacherService.GetStatsAsync(),
            ClassroomStats = await _classroomService.GetOverviewAsync()
        };
    }
}
