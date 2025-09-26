namespace Kindergarten.Application.DTOs
{
    public class ReportsOverviewDto
    {
        public StudentStatsDto StudentStats { get; set; } = new();
        public TeacherStatsDto TeacherStats { get; set; } = new();
        public ClassroomReportDto ClassroomStats { get; set; } = new();

    }
}
