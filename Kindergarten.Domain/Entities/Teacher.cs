namespace Kindergarten.Domain.Entities;

public class Teacher
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FullName { get; private set; } = null!;
    public string Subject { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    // Relationships
    public ICollection<Classroom> Classrooms { get; private set; } = new List<Classroom>();

    // Constructors
    private Teacher() { }

    public Teacher(string fullName, string subject, string phoneNumber)
    {
        FullName = fullName;
        Subject = subject;
        PhoneNumber = phoneNumber;
    }

    // Methods
    public void UpdateInfo(string fullName, string subject, string phoneNumber)
    {
        FullName = fullName;
        Subject = subject;
        PhoneNumber = phoneNumber;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
