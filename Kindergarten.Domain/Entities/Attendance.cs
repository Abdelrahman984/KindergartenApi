using Kindergarten.Domain.Enums;

namespace Kindergarten.Domain.Entities;

public class Attendance
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid StudentId { get; private set; }
    public Student Student { get; private set; } = null!;
    public DateTime Date { get; private set; }
    public TimeSpan? ArrivalTime { get; private set; }
    public AttendanceStatus Status { get; private set; } // Unmarked, Present, Absent, Late
    public string? Notes { get; private set; }

    private Attendance() { } // for ORM

    public Attendance(Guid studentId, DateTime date, TimeSpan? arrivalTime, AttendanceStatus status, string? notes)
    {
        StudentId = studentId;
        Date = date.Date;
        ArrivalTime = arrivalTime;
        Status = status;
        Notes = notes;
    }

    public static Attendance Create(Guid studentId, DateTime date, TimeSpan? arrivalTime, AttendanceStatus status, string? notes)
        => new(studentId, date, arrivalTime, status, notes);

    public void UpdateStatus(AttendanceStatus status, string? notes, TimeSpan? arrivalTime)
    {
        Status = status;
        Notes = notes;

        ArrivalTime = status == AttendanceStatus.Present || status == AttendanceStatus.Late
            ? arrivalTime
            : null;
    }

}
