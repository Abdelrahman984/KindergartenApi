using Kindergarten.Application.DTOs;
using Kindergarten.Domain.Entities;
using Kindergarten.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence;

public static class AttendanceSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // لو فيه بيانات بالفعل مش هنضيف
        if (await context.Attendances.AnyAsync()) return;

        var today = DateTime.UtcNow.Date;
        var students = await context.Students.Include(s => s.Classroom).ToListAsync();
        var random = new Random();

        var attendances = new List<Attendance>();

        foreach (var student in students)
        {
            for (int d = 0; d < 10; d++)
            {
                // حالة حضور عشوائية بين Present, Absent, Late
                var status = (AttendanceStatus)random.Next(1, 4); // 1-3 فقط، Unmarked مش للـ Seeder

                // ملاحظة عشوائية حسب الحالة
                var note = status switch
                {
                    AttendanceStatus.Late => "متأخر عن الوقت المطلوب",
                    AttendanceStatus.Absent => "غائب بدون عذر",
                    AttendanceStatus.Present => "لا توجد ملاحظات",
                    _ => ""
                };

                // وقت الوصول
                var arrivalTime = status switch
                {
                    AttendanceStatus.Late => new TimeSpan(8, 30 + random.Next(0, 60), 0), // متأخر بفارق عشوائي
                    AttendanceStatus.Present => new TimeSpan(8, 0, 0),
                    _ => (TimeSpan?)null
                };

                var date = today.AddDays(-d);

                // إنشاء سجل الحضور
                var attendance = Attendance.Create(student.Id, date, arrivalTime, status, note);

                attendances.Add(attendance);
            }
        }

        await context.Attendances.AddRangeAsync(attendances);
        await context.SaveChangesAsync();
    }

    // Optional: طريقة لتحويل Attendance entity مباشرة لـ DTO باستخدام AutoMapper
    public static List<AttendanceReadDto> MapToDto(IEnumerable<Attendance> attendances)
    {
        return attendances.Select(a => new AttendanceReadDto
        {
            Id = a.Id,
            StudentId = a.StudentId,
            StudentName = a.Student.FullName,
            ClassroomId = a.Student.ClassroomId,
            ClassroomName = a.Student.Classroom?.Name,
            Date = a.Date,
            Status = a.Status,
            Notes = a.Notes,
            ArrivalTime = a.ArrivalTime
        }).ToList();
    }
}
