using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence.Seeders;

public static class ClassSessionSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.ClassSessions.AnyAsync()) return;

        var today = DateTime.UtcNow.Date;
        var classrooms = await context.Classrooms.ToListAsync();
        var teachers = await context.Teachers.ToListAsync();
        var subjects = await context.Subjects.ToListAsync();

        if (!classrooms.Any() || !teachers.Any() || !subjects.Any()) return;

        var random = new Random();
        var sessions = new List<ClassSession>();

        // الشهر الحالي
        var startOfMonth = new DateTime(today.Year, today.Month, 1);
        var daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

        // أيام الإجازة (جمعة وسبت)
        var holidays = new List<DateTime>();
        for (int day = 0; day < daysInMonth; day++)
        {
            var date = startOfMonth.AddDays(day);
            if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                holidays.Add(date);
            }
        }

        for (int day = 0; day < daysInMonth; day++)
        {
            var date = startOfMonth.AddDays(day);
            if (holidays.Contains(date)) continue;

            foreach (var classroom in classrooms)
            {
                // نبدأ الحصص من 8 صباحًا حتى 2 ظهرًا مثلاً
                int startHour = 8;
                while (startHour < 14) // آخر حصة تنتهي الساعة 15:00
                {
                    var startTime = date.AddHours(startHour);
                    var endTime = startTime.AddHours(1); // حصة ساعة

                    var teacher = teachers[random.Next(teachers.Count)];
                    var subject = subjects[random.Next(subjects.Count)];

                    var session = new ClassSession
                    {
                        Id = Guid.NewGuid(),
                        ClassroomId = classroom.Id,
                        TeacherId = teacher.Id,
                        SubjectId = subject.Id,
                        StartTime = startTime,
                        EndTime = endTime
                    };

                    sessions.Add(session);

                    startHour += 1; // حصة ساعة
                    startHour += 0; // فسحة: ممكن تضيف 0.25 للـ 15 دقيقة إذا حابب
                }
            }
        }

        await context.ClassSessions.AddRangeAsync(sessions);
        await context.SaveChangesAsync();
    }
}
