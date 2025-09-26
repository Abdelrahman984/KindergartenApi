using System.ComponentModel.DataAnnotations;

namespace Kindergarten.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    [Required]
    public string FullName { get; private set; } = null!;
    public DateTime DateOfBirth { get; private set; }
    public int Age { get; private set; }
    public string Address { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    // Relationships
    public Guid? ParentId { get; private set; }
    public Parent? Parent { get; private set; }
    public Guid? ClassroomId { get; private set; }
    public Classroom? Classroom { get; private set; }
    public ICollection<Attendance> Attendances { get; private set; } = new List<Attendance>();
    public ICollection<Fee> Fees { get; private set; } = new List<Fee>();


    // ctor for ORM
    protected Student() { }

    public Student(string fullName, DateTime dob, string address)
    {
        FullName = fullName;
        DateOfBirth = dob;
        Address = address;
    }
    // For seeding only
    public Student(Guid id, string fullName, DateTime dob, string address)
    {
        Id = id;
        FullName = fullName;
        DateOfBirth = dob;
        Address = address;
    }


    public void Deactivate() => IsActive = false;
    public void UpdateInfo(string fullName, DateTime dob, string address)
    {
        FullName = fullName;
        DateOfBirth = dob;
        Address = address;
    }

    public void AssignParent(Guid parentId)
    {
        ParentId = parentId;
    }

    public void AssignClassroom(Guid classroomId)
    {
        ClassroomId = classroomId;
    }
}
