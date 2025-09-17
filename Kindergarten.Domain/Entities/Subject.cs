namespace Kindergarten.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();
    }
}
