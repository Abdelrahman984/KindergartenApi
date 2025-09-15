using Kindergarten.Domain.Enums;

namespace Kindergarten.Application.DTOs;

public record AttendanceCreateDto(Guid StudentId, DateTime Date, TimeSpan? ArrivalTime, AttendanceStatus Status, string? Notes);
public record AttendanceReadDto(Guid Id, Guid StudentId, string StudentName, DateTime Date, AttendanceStatus Status, string? Notes, TimeSpan? ArrivalTime, string? ClassroomName, Guid? ClassroomId)
{
    public AttendanceReadDto()
        : this(Guid.Empty, Guid.Empty, string.Empty, DateTime.MinValue, default, null, null, null, null) { }
}

public class StudentAttendancePercentageDto
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public double Percentage { get; set; }
}

public class AttendanceTrendDto
{
    public double TodayPercentage { get; set; }
    public double ThisWeekPercentage { get; set; }
    public double ThisMonthPercentage { get; set; }
}

public class AttendanceStatsDto
{
    public DateTime Date { get; set; }

    // Counts
    public int PresentCount { get; set; }
    public int AbsentCount { get; set; }
    public int LateCount { get; set; }
    public int UnmarkedCount { get; set; }

    // Total Required (كل الطلاب)
    public int TotalRequired { get; set; }

    // نسبة مئوية محسوبة (للاستخدام في UI لو حبيت)
    public double PresentPercentage => TotalRequired == 0 ? 0 : (double)PresentCount / TotalRequired * 100;
    public double AbsentPercentage => TotalRequired == 0 ? 0 : (double)AbsentCount / TotalRequired * 100;
    public double LatePercentage => TotalRequired == 0 ? 0 : (double)LateCount / TotalRequired * 100;
    public double UnmarkedPercentage => TotalRequired == 0 ? 0 : (double)UnmarkedCount / TotalRequired * 100;
}

public class AttendanceReportDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // 📌 Summary Totals
    public int PresentTotal { get; set; }
    public int AbsentTotal { get; set; }
    public int LateTotal { get; set; }
    public int UnmarkedTotal { get; set; }
    public int TotalRequired { get; set; }

    // 📌 Breakdown (Day by Day)
    public List<AttendanceStatsDto> Breakdown { get; set; } = new();
}


