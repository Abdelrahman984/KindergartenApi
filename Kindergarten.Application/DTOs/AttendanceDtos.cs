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
    public int PresentCount { get; set; }
    public int AbsentCount { get; set; }
    public int LateCount { get; set; }
    public int UnmarkedCount { get; set; }
}
public class AttendanceReportDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // 📌 Summary
    public int PresentTotal { get; set; }
    public int AbsentTotal { get; set; }
    public int LateTotal { get; set; }
    public int UnmarkedTotal { get; set; }

    // 📌 Breakdown
    public List<AttendanceStatsDto> Breakdown { get; set; } = new();
}

