using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Domain.Enums;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class AttendanceRepository(AppDbContext context) : GenericRepository<Attendance>(context), IAttendanceRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Attendance?> GetByStudentAndDateAsync(Guid studentId, DateTime date)
    {
        return await _context.Attendances
            .Include(a => a.Student)
                .ThenInclude(s => s.Classroom)
            .FirstOrDefaultAsync(a => a.StudentId == studentId && a.Date == date.Date);
    }

    public async Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date)
    {
        return await _context.Attendances
            .Include(a => a.Student)
                .ThenInclude(s => s.Classroom)
            .Where(a => a.Date == date.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Attendance>> GetByStudentAsync(Guid studentId)
    {
        return await _context.Attendances
            .Include(a => a.Student)
                .ThenInclude(s => s.Classroom)
            .Where(a => a.StudentId == studentId)
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    // --- إحصائيات ---
    public async Task<AttendanceStatsDto> GetDailyStatsAsync(DateTime date)
    {
        var students = await _context.Students.ToListAsync();

        var attendancesToday = await _context.Attendances
            .Where(a => a.Date == date.Date)
            .ToListAsync();

        int presentCount = 0;
        int absentCount = 0;
        int lateCount = 0;
        int unmarkedCount = 0;

        foreach (var student in students)
        {
            var attendance = attendancesToday.FirstOrDefault(a => a.StudentId == student.Id);
            if (attendance == null)
            {
                unmarkedCount++;
            }
            else
            {
                switch (attendance.Status)
                {
                    case AttendanceStatus.Present:
                        presentCount++;
                        break;
                    case AttendanceStatus.Absent:
                        absentCount++;
                        break;
                    case AttendanceStatus.Late:
                        lateCount++;
                        break;
                }
            }
        }

        return new AttendanceStatsDto
        {
            Date = date.Date,
            PresentCount = presentCount,
            AbsentCount = absentCount,
            LateCount = lateCount,
            UnmarkedCount = unmarkedCount
        };
    }

    public async Task<double> GetStudentAttendancePercentageAsync(Guid studentId)
    {
        var records = await _context.Attendances
            .Where(a => a.StudentId == studentId)
            .ToListAsync();

        if (!records.Any()) return 0;

        var attended = records.Count(a => a.Status == AttendanceStatus.Present || a.Status == AttendanceStatus.Late);
        return (double)attended / records.Count * 100;
    }

    public async Task<double> GetOverallAttendancePercentageAsync()
    {
        var records = await _context.Attendances.ToListAsync();
        if (!records.Any()) return 0;

        var attended = records.Count(a => a.Status == AttendanceStatus.Present || a.Status == AttendanceStatus.Late);
        return (double)attended / records.Count * 100;
    }

    public async Task<AttendanceTrendDto> GetAttendanceTrendsAsync(DateTime today)
    {
        var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
        var startOfMonth = new DateTime(today.Year, today.Month, 1);

        var todayPercentage = await GetPercentageByRange(today, today);
        var weekPercentage = await GetPercentageByRange(startOfWeek, today);
        var monthPercentage = await GetPercentageByRange(startOfMonth, today);

        return new AttendanceTrendDto
        {
            TodayPercentage = todayPercentage,
            ThisWeekPercentage = weekPercentage,
            ThisMonthPercentage = monthPercentage
        };
    }

    public async Task<List<StudentAttendancePercentageDto>> GetAllStudentsAttendancePercentageAsync()
    {
        var students = await _context.Students
            .Include(s => s.Attendances)
            .ToListAsync();

        return students.Select(s =>
        {
            var total = s.Attendances.Count;
            var attended = s.Attendances.Count(a => a.Status == AttendanceStatus.Present || a.Status == AttendanceStatus.Late);
            var percentage = total == 0 ? 0 : (double)attended / total * 100;

            return new StudentAttendancePercentageDto
            {
                StudentId = s.Id,
                StudentName = s.FullName,
                Percentage = percentage
            };
        }).ToList();
    }

    // --- Helper ---
    private async Task<double> GetPercentageByRange(DateTime start, DateTime end)
    {
        var records = await _context.Attendances
            .Where(a => a.Date >= start.Date && a.Date <= end.Date)
            .ToListAsync();

        if (!records.Any()) return 0;

        var attended = records.Count(a => a.Status == AttendanceStatus.Present || a.Status == AttendanceStatus.Late);
        return (double)attended / records.Count * 100;
    }
}
