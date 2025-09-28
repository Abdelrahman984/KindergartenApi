// Application/Services/ReportsService.cs
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Services;

namespace Kindergarten.Application.Services;

public class ReportsService : IReportsService
{
    private readonly IStudentService studentService;
    private readonly ITeacherService teacherService;
    private readonly IClassroomService classroomService;
    private readonly IAttendanceService attendanceService;
    private readonly IFeeService feeService;

    public ReportsService(IStudentService studentService, ITeacherService teacherService, IClassroomService classroomService, IAttendanceService attendanceService, IFeeService feeService)
    {
        this.studentService = studentService;
        this.teacherService = teacherService;
        this.classroomService = classroomService;
        this.attendanceService = attendanceService;
        this.feeService = feeService;
    }

    public async Task<ReportsOverviewDto> GetOverviewAsync()
    {
        var today = DateTime.Now;
        return new ReportsOverviewDto
        {
            StudentStats = await studentService.GetStatsAsync(),
            TeacherStats = await teacherService.GetStatsAsync(),
            ClassroomStats = await classroomService.GetOverviewAsync(),
            FeeStats = await feeService.GetFeeStatsAsync(),
        };
    }
}
