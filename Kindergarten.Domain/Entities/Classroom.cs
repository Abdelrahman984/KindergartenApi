namespace Kindergarten.Domain.Entities;

public class Classroom
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = null!;
    public int Capacity { get; private set; }

    // Relationships
    public ICollection<TeacherClassroom> TeacherClassrooms { get; private set; } = new List<TeacherClassroom>();
    public ICollection<Student> Students { get; private set; } = new List<Student>();
    public ICollection<ClassSession> ClassSessions { get; private set; } = new List<ClassSession>();

    private Classroom() { }

    public Classroom(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }

    public void AssignTeacher(Guid teacherId)
    {
        if (!TeacherClassrooms.Any(tc => tc.TeacherId == teacherId))
        {
            TeacherClassrooms.Add(new TeacherClassroom(teacherId, Id));
        }
    }

    public void UpdateCapacity(int newCapacity) => Capacity = newCapacity;
}
