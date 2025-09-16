namespace Kindergarten.Application.DTOs
{
    public class SubjectCreateDto
    {
        public string Name { get; set; }
    }

    public class SubjectUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class SubjectReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
