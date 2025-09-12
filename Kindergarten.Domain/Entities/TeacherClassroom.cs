namespace Kindergarten.Domain.Entities;

public class TeacherClassroom
{
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public Guid ClassroomId { get; set; }
    public Classroom Classroom { get; set; } = null!;

    // Adding a constructor to fix the CS1729 error
    public TeacherClassroom(Guid teacherId, Guid classroomId)
    {
        TeacherId = teacherId;
        ClassroomId = classroomId;
    }
}