namespace Kindergarten.Application.DTOs
{
    public class ClassSessionCreateDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ClassroomId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
    }

    public class ClassSessionUpdateDto : ClassSessionCreateDto
    {
        public Guid Id { get; set; }
    }

    public class ClassSessionReadDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string ClassroomName { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
    }

}
