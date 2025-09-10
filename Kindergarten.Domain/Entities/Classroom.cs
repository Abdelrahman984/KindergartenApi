namespace Kindergarten.Domain.Entities;

public class Classroom
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = null!;
    public int Capacity { get; private set; }

    // Relationships
    public Guid? TeacherId { get; private set; }
    public Teacher? Teacher { get; private set; }
    public ICollection<Student> Students { get; private set; } = new List<Student>();

    private Classroom() { }

    public Classroom(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }

    public void AssignTeacher(Guid teacherId) => TeacherId = teacherId;
    public void UpdateCapacity(int newCapacity) => Capacity = newCapacity;
}
