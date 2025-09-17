namespace Kindergarten.Domain.Entities;

public class Teacher
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FullName { get; private set; } = null!;
    public Guid? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public string PhoneNumber { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    // Relationships
    public ICollection<TeacherClassroom> TeacherClassrooms { get; private set; } = new List<TeacherClassroom>();
    public ICollection<ClassSession> ClassSessions { get; private set; } = new List<ClassSession>();

    // Constructors
    private Teacher() { }

    public Teacher(string fullName, string phoneNumber)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public Teacher(string fullName, string phoneNumber, bool isActive = false)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
    }

    // Methods
    public void UpdateInfo(string fullName, string phoneNumber, bool isActive)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
