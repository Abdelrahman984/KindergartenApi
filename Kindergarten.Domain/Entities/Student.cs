namespace Kindergarten.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; } = null!;
    public string FatherName { get; private set; } = null!;
    public string GrandpaName { get; private set; } = null!;
    public string FullName => $"{FirstName} {FatherName} {GrandpaName}";
    public DateTime DateOfBirth { get; private set; }
    public string ParentPhone { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    // Relationships
    public Guid? ParentId { get; private set; }
    public Parent? Parent { get; private set; }
    public Guid? ClassroomId { get; private set; }
    public Classroom? Classroom { get; private set; }

    // ctor for ORM
    protected Student() { }

    public Student(string firstName, string fatherName, string grandpaName, DateTime dob, string parentPhone, string address)
    {
        FirstName = firstName;
        FatherName = fatherName;
        GrandpaName = grandpaName;
        DateOfBirth = dob;
        ParentPhone = parentPhone;
        Address = address;
    }
    // For seeding only
    public Student(Guid id, string firstName, string fatherName, string grandpaName, DateTime dob, string parentPhone, string address)
    {
        Id = id;
        FirstName = firstName;
        FatherName = fatherName;
        GrandpaName = grandpaName;
        DateOfBirth = dob;
        ParentPhone = parentPhone;
        Address = address;
    }


    public void Deactivate() => IsActive = false;
    public void UpdateInfo(string firstName, string fatherName, string grandpaName, DateTime dob, string parentPhone, string address)
    {
        FirstName = firstName;
        FatherName = fatherName;
        GrandpaName = grandpaName;
        DateOfBirth = dob;
        ParentPhone = parentPhone;
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
