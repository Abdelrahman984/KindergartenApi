using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // 🔹 Parents
        var parent1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var parent2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var parent3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<Parent>().HasData(
            new { Id = parent1Id, FullName = "أحمد علي", PhoneNumber = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة، مصر" },
            new { Id = parent2Id, FullName = "منى حسن", PhoneNumber = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية، مصر" },
            new { Id = parent3Id, FullName = "حسام يوسف", PhoneNumber = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة، مصر" }
        );

        // 🔹 Classrooms (IDs used by Students seeding)
        var class1Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var class2Id = Guid.Parse("88888888-8888-8888-8888-888888888888");
        var class3Id = Guid.Parse("99999999-9999-9999-9999-999999999999");

        // 🔹 Students
        var student1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var student2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var student3Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        var student4Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        var student5Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

        modelBuilder.Entity<Student>().HasData(
            new { Id = student1Id, FirstName = "عمر", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2019, 5, 12), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة، مصر", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student2Id, FirstName = "سارة", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2020, 3, 25), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية، مصر", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student3Id, FirstName = "يوسف", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2019, 10, 2), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة، مصر", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            // Extra students to ensure: multiple children per parent, multiple students per teacher/classroom
            new { Id = student4Id, FirstName = "ملك", FatherName = "أحمد", GrandpaName = "كمال", DateOfBirth = new DateTime(2020, 6, 15), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة، مصر", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student5Id, FirstName = "علا", FatherName = "منى", GrandpaName = "فوزي", DateOfBirth = new DateTime(2021, 1, 10), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية، مصر", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id }
        );

        // 🔹 Teachers
        var teacher1Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var teacher2Id = Guid.Parse("55555555-5555-5555-5555-555555555555");
        var teacher3Id = Guid.Parse("66666666-6666-6666-6666-666666666666");

        modelBuilder.Entity<Teacher>().HasData(
            new { Id = teacher1Id, FullName = "فاطمة إبراهيم", Subject = "رياضيات", PhoneNumber = "0105551234", IsActive = true },
            new { Id = teacher2Id, FullName = "محمد صلاح", Subject = "علوم", PhoneNumber = "0107779999", IsActive = true },
            new { Id = teacher3Id, FullName = "عائشة مصطفى", Subject = "عربي", PhoneNumber = "0102226666", IsActive = true }
        );

        modelBuilder.Entity<Classroom>().HasData(
            new { Id = class1Id, Name = "KG1", Capacity = 20, TeacherId = teacher1Id },
            new { Id = class2Id, Name = "KG2", Capacity = 25, TeacherId = teacher2Id },
            new { Id = class3Id, Name = "KG3", Capacity = 30, TeacherId = teacher3Id }
        );

        // 🔹 Attendance (multi-day for testing)
        var att1Id = Guid.Parse("aaaaaaaa-1111-1111-1111-aaaaaaaaaaaa");
        var att2Id = Guid.Parse("bbbbbbbb-2222-2222-2222-bbbbbbbbbbbb");
        var att3Id = Guid.Parse("cccccccc-3333-3333-3333-cccccccccccc");
        var att4Id = Guid.Parse("dddddddd-4444-4444-4444-dddddddddddd");
        var att5Id = Guid.Parse("eeeeeeee-5555-5555-5555-eeeeeeeeeeee");
        var att6Id = Guid.Parse("ffffffff-6666-6666-6666-ffffffffffff");
        var att7Id = Guid.Parse("11111111-aaaa-bbbb-cccc-111111111111");
        var att8Id = Guid.Parse("22222222-bbbb-cccc-dddd-222222222222");
        var att9Id = Guid.Parse("33333333-cccc-dddd-eeee-333333333333");

        modelBuilder.Entity<Attendance>().HasData(
            // 2024-09-01
            new { Id = att1Id, StudentId = student1Id, Date = new DateTime(2024, 9, 1), IsPresent = true },
            new { Id = att2Id, StudentId = student2Id, Date = new DateTime(2024, 9, 1), IsPresent = false },
            new { Id = att3Id, StudentId = student3Id, Date = new DateTime(2024, 9, 1), IsPresent = true },
            new { Id = Guid.Parse("aaaa1111-1111-1111-1111-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 1), IsPresent = true },
            new { Id = Guid.Parse("bbbb1111-1111-1111-1111-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 1), IsPresent = true },
            // 2024-09-02
            new { Id = att4Id, StudentId = student1Id, Date = new DateTime(2024, 9, 2), IsPresent = false },
            new { Id = att5Id, StudentId = student2Id, Date = new DateTime(2024, 9, 2), IsPresent = true },
            new { Id = att6Id, StudentId = student3Id, Date = new DateTime(2024, 9, 2), IsPresent = true },
            new { Id = Guid.Parse("aaaa2222-2222-2222-2222-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 2), IsPresent = false },
            new { Id = Guid.Parse("bbbb2222-2222-2222-2222-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 2), IsPresent = true },
            // 2024-09-03
            new { Id = att7Id, StudentId = student1Id, Date = new DateTime(2024, 9, 3), IsPresent = true },
            new { Id = att8Id, StudentId = student2Id, Date = new DateTime(2024, 9, 3), IsPresent = true },
            new { Id = att9Id, StudentId = student3Id, Date = new DateTime(2024, 9, 3), IsPresent = false },
            new { Id = Guid.Parse("aaaa3333-3333-3333-3333-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 3), IsPresent = true },
            new { Id = Guid.Parse("bbbb3333-3333-3333-3333-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 3), IsPresent = false },
            // 2024-09-04
            new { Id = Guid.Parse("44444444-aaaa-bbbb-cccc-111111111111"), StudentId = student1Id, Date = new DateTime(2024, 9, 4), IsPresent = true },
            new { Id = Guid.Parse("44444444-aaaa-bbbb-cccc-222222222222"), StudentId = student2Id, Date = new DateTime(2024, 9, 4), IsPresent = false },
            new { Id = Guid.Parse("44444444-aaaa-bbbb-cccc-333333333333"), StudentId = student3Id, Date = new DateTime(2024, 9, 4), IsPresent = true },
            new { Id = Guid.Parse("aaaa4444-4444-4444-4444-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 4), IsPresent = false },
            new { Id = Guid.Parse("bbbb4444-4444-4444-4444-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 4), IsPresent = true },
            // 2024-09-05
            new { Id = Guid.Parse("55555555-aaaa-bbbb-cccc-111111111111"), StudentId = student1Id, Date = new DateTime(2024, 9, 5), IsPresent = false },
            new { Id = Guid.Parse("55555555-aaaa-bbbb-cccc-222222222222"), StudentId = student2Id, Date = new DateTime(2024, 9, 5), IsPresent = false },
            new { Id = Guid.Parse("55555555-aaaa-bbbb-cccc-333333333333"), StudentId = student3Id, Date = new DateTime(2024, 9, 5), IsPresent = true },
            new { Id = Guid.Parse("aaaa5555-5555-5555-5555-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 5), IsPresent = true },
            new { Id = Guid.Parse("bbbb5555-5555-5555-5555-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 5), IsPresent = false },
            // 2024-09-06
            new { Id = Guid.Parse("66666666-aaaa-bbbb-cccc-111111111111"), StudentId = student1Id, Date = new DateTime(2024, 9, 6), IsPresent = true },
            new { Id = Guid.Parse("66666666-aaaa-bbbb-cccc-222222222222"), StudentId = student2Id, Date = new DateTime(2024, 9, 6), IsPresent = true },
            new { Id = Guid.Parse("66666666-aaaa-bbbb-cccc-333333333333"), StudentId = student3Id, Date = new DateTime(2024, 9, 6), IsPresent = true },
            new { Id = Guid.Parse("aaaa6666-6666-6666-6666-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 6), IsPresent = true },
            new { Id = Guid.Parse("bbbb6666-6666-6666-6666-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 6), IsPresent = true },
            // 2024-09-09 (skip weekend to test gaps)
            new { Id = Guid.Parse("77777777-aaaa-bbbb-cccc-111111111111"), StudentId = student1Id, Date = new DateTime(2024, 9, 9), IsPresent = true },
            new { Id = Guid.Parse("77777777-aaaa-bbbb-cccc-222222222222"), StudentId = student2Id, Date = new DateTime(2024, 9, 9), IsPresent = false },
            new { Id = Guid.Parse("77777777-aaaa-bbbb-cccc-333333333333"), StudentId = student3Id, Date = new DateTime(2024, 9, 9), IsPresent = false },
            new { Id = Guid.Parse("aaaa7777-7777-7777-7777-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 9), IsPresent = true },
            new { Id = Guid.Parse("bbbb7777-7777-7777-7777-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 9), IsPresent = false },
            // 2024-09-10
            new { Id = Guid.Parse("88888888-aaaa-bbbb-cccc-111111111111"), StudentId = student1Id, Date = new DateTime(2024, 9, 10), IsPresent = false },
            new { Id = Guid.Parse("88888888-aaaa-bbbb-cccc-222222222222"), StudentId = student2Id, Date = new DateTime(2024, 9, 10), IsPresent = true },
            new { Id = Guid.Parse("88888888-aaaa-bbbb-cccc-333333333333"), StudentId = student3Id, Date = new DateTime(2024, 9, 10), IsPresent = true },
            new { Id = Guid.Parse("aaaa8888-8888-8888-8888-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 10), IsPresent = true },
            new { Id = Guid.Parse("bbbb8888-8888-8888-8888-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 10), IsPresent = true },
            // 2024-09-11
            new { Id = Guid.Parse("99999999-aaaa-bbbb-cccc-111111111111"), StudentId = student1Id, Date = new DateTime(2024, 9, 11), IsPresent = true },
            new { Id = Guid.Parse("99999999-aaaa-bbbb-cccc-222222222222"), StudentId = student2Id, Date = new DateTime(2024, 9, 11), IsPresent = true },
            new { Id = Guid.Parse("99999999-aaaa-bbbb-cccc-333333333333"), StudentId = student3Id, Date = new DateTime(2024, 9, 11), IsPresent = false },
            new { Id = Guid.Parse("aaaa9999-9999-9999-9999-aaaaaaaaaaaa"), StudentId = student4Id, Date = new DateTime(2024, 9, 11), IsPresent = false },
            new { Id = Guid.Parse("bbbb9999-9999-9999-9999-bbbbbbbbbbbb"), StudentId = student5Id, Date = new DateTime(2024, 9, 11), IsPresent = true }
        );
    }
}
