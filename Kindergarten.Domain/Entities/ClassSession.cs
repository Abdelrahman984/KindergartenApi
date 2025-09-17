namespace Kindergarten.Domain.Entities
{
    public class ClassSession
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // علاقات
        public Guid ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
