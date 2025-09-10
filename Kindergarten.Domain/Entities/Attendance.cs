namespace Kindergarten.Domain.Entities;

public class Attendance
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime Date { get; private set; }
    public bool IsPresent { get; private set; }

    // Relationships
    public Guid StudentId { get; private set; }
    public Student Student { get; private set; } = null!;

    private Attendance() { }

    public Attendance(Guid studentId, DateTime date, bool isPresent)
    {
        StudentId = studentId;
        Date = date.Date; // store only date
        IsPresent = isPresent;
    }

    public void UpdateStatus(bool isPresent) => IsPresent = isPresent;
}
