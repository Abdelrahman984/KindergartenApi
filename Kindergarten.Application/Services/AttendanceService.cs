using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;
using Kindergarten.Domain.Enums;

namespace Kindergarten.Application.Services;
public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepo;
    private readonly IStudentRepository _studentRepo;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AttendanceService(
        IAttendanceRepository attendanceRepo,
        IStudentRepository studentRepo,
        IUnitOfWork uow,
        IMapper mapper)
    {
        _attendanceRepo = attendanceRepo;
        _studentRepo = studentRepo;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<AttendanceReadDto> MarkAttendanceAsync(AttendanceCreateDto dto)
    {
        var student = await _studentRepo.GetByIdAsync(dto.StudentId);
        if (student is null)
            throw new KeyNotFoundException("Student not found");

        var existing = await _attendanceRepo.GetByStudentAndDateAsync(dto.StudentId, dto.Date);

        if (existing is not null)
        {
            existing.UpdateStatus(dto.Status, dto.Notes, dto.ArrivalTime);
            await _attendanceRepo.UpdateAsync(existing);
        }
        else
        {
            existing = Attendance.Create(dto.StudentId, dto.Date, dto.ArrivalTime, dto.Status, dto.Notes);
            await _attendanceRepo.AddAsync(existing);
        }

        await _uow.SaveChangesAsync();
        return _mapper.Map<AttendanceReadDto>(existing);
    }

    public async Task<IEnumerable<AttendanceReadDto>> GetByDateAsync(DateTime date)
    {
        var records = await _attendanceRepo.GetByDateAsync(date);
        return _mapper.Map<IEnumerable<AttendanceReadDto>>(records);
    }

    public async Task<IEnumerable<AttendanceReadDto>> GetByStudentAsync(Guid studentId)
    {
        var records = await _attendanceRepo.GetByStudentAsync(studentId);
        return _mapper.Map<IEnumerable<AttendanceReadDto>>(records);
    }

    public async Task<IEnumerable<AttendanceReadDto>> GetDailyWithUnmarkedAsync(DateTime date)
    {
        var students = await _studentRepo.GetAllAsync();
        var records = await _attendanceRepo.GetByDateAsync(date);
        var recordsDict = records.ToDictionary(r => r.StudentId, r => r);

        var result = new List<AttendanceReadDto>();

        foreach (var student in students)
        {
            if (recordsDict.TryGetValue(student.Id, out var record))
            {
                result.Add(_mapper.Map<AttendanceReadDto>(record));
            }
            else
            {
                result.Add(new AttendanceReadDto
                {
                    Id = Guid.Empty,
                    StudentId = student.Id,
                    StudentName = student.FullName,
                    Date = date.Date,
                    Status = AttendanceStatus.Unmarked,
                    Notes = ""
                });
            }
        }

        return result;
    }

    // Stats methods

    // 📌 Daily Stats
    public async Task<AttendanceStatsDto> GetDailyStatsAsync(DateTime date)
    {
        var students = await _studentRepo.GetActiveStudentsAsync();
        var attendances = await _attendanceRepo.GetByDateAsync(date);

        int presentCount = 0, absentCount = 0, lateCount = 0, unmarkedCount = 0;

        foreach (var student in students)
        {
            var attendance = attendances.FirstOrDefault(a => a.StudentId == student.Id);
            if (attendance == null)
            {
                unmarkedCount++;
            }
            else
            {
                switch (attendance.Status)
                {
                    case AttendanceStatus.Present: presentCount++; break;
                    case AttendanceStatus.Absent: absentCount++; break;
                    case AttendanceStatus.Late: lateCount++; break;
                }
            }
        }

        return new AttendanceStatsDto
        {
            Date = date.Date,
            PresentCount = presentCount,
            AbsentCount = absentCount,
            LateCount = lateCount,
            UnmarkedCount = unmarkedCount,
            TotalRequired = students.Count()
        };
    }

    // 📌 Weekly Report
    public async Task<AttendanceReportDto> GetWeeklyReportAsync(DateTime anyDate)
    {
        int daysFromSaturday = ((int)anyDate.DayOfWeek + 1) % 7;
        var weekStart = anyDate.Date.AddDays(-daysFromSaturday);
        var weekEnd = weekStart.AddDays(6);

        var studentsCount = await _studentRepo.GetTotalCountAsync();
        var report = new AttendanceReportDto
        {
            StartDate = weekStart,
            EndDate = weekEnd,
            TotalRequired = studentsCount * 7 // عدد الطلاب × 7 أيام
        };

        for (int i = 0; i < 7; i++)
        {
            var date = weekStart.AddDays(i);
            var attendances = await _attendanceRepo.GetByDateAsync(date);

            var stats = new AttendanceStatsDto
            {
                Date = date,
                PresentCount = attendances.Count(a => a.Status == AttendanceStatus.Present),
                AbsentCount = attendances.Count(a => a.Status == AttendanceStatus.Absent),
                LateCount = attendances.Count(a => a.Status == AttendanceStatus.Late),
                UnmarkedCount = studentsCount - attendances.Count(),
                TotalRequired = studentsCount
            };

            report.Breakdown.Add(stats);
            report.PresentTotal += stats.PresentCount;
            report.AbsentTotal += stats.AbsentCount;
            report.LateTotal += stats.LateCount;
            report.UnmarkedTotal += stats.UnmarkedCount;
        }

        return report;
    }

    // 📌 Monthly Report
    public async Task<AttendanceReportDto> GetMonthlyReportAsync(DateTime anyDate)
    {
        var monthStart = new DateTime(anyDate.Year, anyDate.Month, 1);
        var monthEnd = monthStart.AddMonths(1).AddDays(-1);

        var studentsCount = await _studentRepo.GetTotalCountAsync();
        var report = new AttendanceReportDto
        {
            StartDate = monthStart,
            EndDate = monthEnd,
            TotalRequired = studentsCount * (monthEnd.Day - monthStart.Day + 1)
        };

        for (var date = monthStart; date <= monthEnd; date = date.AddDays(1))
        {
            var attendances = await _attendanceRepo.GetByDateAsync(date);

            var stats = new AttendanceStatsDto
            {
                Date = date,
                PresentCount = attendances.Count(a => a.Status == AttendanceStatus.Present),
                AbsentCount = attendances.Count(a => a.Status == AttendanceStatus.Absent),
                LateCount = attendances.Count(a => a.Status == AttendanceStatus.Late),
                UnmarkedCount = studentsCount - attendances.Count(),
                TotalRequired = studentsCount
            };

            report.Breakdown.Add(stats);
            report.PresentTotal += stats.PresentCount;
            report.AbsentTotal += stats.AbsentCount;
            report.LateTotal += stats.LateCount;
            report.UnmarkedTotal += stats.UnmarkedCount;
        }
        return report;
    }
    public Task<double> GetStudentAttendancePercentageAsync(Guid studentId)
        => _attendanceRepo.GetStudentAttendancePercentageAsync(studentId);

    public Task<double> GetOverallAttendancePercentageAsync()
        => _attendanceRepo.GetOverallAttendancePercentageAsync();

    public Task<AttendanceTrendDto> GetTrendsAsync(DateTime today)
        => _attendanceRepo.GetAttendanceTrendsAsync(today);

    public Task<List<StudentAttendancePercentageDto>> GetAllStudentsPercentagesAsync()
        => _attendanceRepo.GetAllStudentsAttendancePercentageAsync();
}
