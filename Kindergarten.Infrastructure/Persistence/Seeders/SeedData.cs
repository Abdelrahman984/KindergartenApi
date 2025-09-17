using Kindergarten.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence.Seeders;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // 🔹 Parents
        var parent1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var parent2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var parent3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<Parent>().HasData(
            new { Id = parent1Id, FullName = "أحمد علي", PhoneNumber = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة" },
            new { Id = parent2Id, FullName = "منى حسن", PhoneNumber = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية" },
            new { Id = parent3Id, FullName = "حسام يوسف", PhoneNumber = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة" }
        );

        // 🔹 Classrooms (IDs used by Students seeding)
        var class1Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var class2Id = Guid.Parse("88888888-8888-8888-8888-888888888888");
        var class3Id = Guid.Parse("99999999-9999-9999-9999-999999999999");

        modelBuilder.Entity<Classroom>().HasData(
            new { Id = class1Id, Name = "KG1", Capacity = 20 },
            new { Id = class2Id, Name = "KG2", Capacity = 25 },
            new { Id = class3Id, Name = "KG3", Capacity = 30 }
        );

        // 🔹 Students
        var student1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var student2Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var student3Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        var student4Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        var student5Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        var student6Id = Guid.Parse("11111111-aaaa-aaaa-aaaa-111111111111");
        var student7Id = Guid.Parse("22222222-bbbb-bbbb-bbbb-222222222222");
        var student8Id = Guid.Parse("33333333-cccc-cccc-cccc-333333333333");
        var student9Id = Guid.Parse("44444444-dddd-dddd-dddd-444444444444");
        var student10Id = Guid.Parse("55555555-eeee-eeee-eeee-555555555555");
        var student11Id = Guid.Parse("66666666-aaaa-aaaa-aaaa-666666666666");
        var student12Id = Guid.Parse("77777777-bbbb-bbbb-bbbb-777777777777");
        var student13Id = Guid.Parse("88888888-cccc-cccc-cccc-888888888888");
        var student14Id = Guid.Parse("99999999-dddd-dddd-dddd-999999999999");
        var student15Id = Guid.Parse("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa");
        var student16Id = Guid.Parse("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb");
        var student17Id = Guid.Parse("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc");
        var student18Id = Guid.Parse("ddddddd4-cccc-cccc-cccc-dddddddddddd");
        var student19Id = Guid.Parse("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee");
        var student20Id = Guid.Parse("fffffff6-eeee-eeee-eeee-ffffffffffff");

        modelBuilder.Entity<Student>().HasData(
            new { Id = student1Id, FirstName = "عمر", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2019, 5, 12), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student2Id, FirstName = "سارة", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2020, 3, 25), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student3Id, FirstName = "يوسف", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2019, 10, 2), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            new { Id = student4Id, FirstName = "ملك", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2020, 6, 15), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student5Id, FirstName = "علا", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2021, 1, 10), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student6Id, FirstName = "ليلى", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2020, 2, 20), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            new { Id = student7Id, FirstName = "محمود", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2019, 8, 5), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student8Id, FirstName = "نور", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2020, 11, 30), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student9Id, FirstName = "زياد", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2019, 7, 18), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            new { Id = student10Id, FirstName = "جنى", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2020, 4, 22), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student11Id, FirstName = "فارس", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2021, 2, 14), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student12Id, FirstName = "هنا", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2019, 9, 9), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            new { Id = student13Id, FirstName = "سيف", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2020, 5, 17), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student14Id, FirstName = "ريم", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2021, 3, 27), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student15Id, FirstName = "طارق", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2019, 12, 3), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            new { Id = student16Id, FirstName = "سلمى", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2020, 7, 21), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student17Id, FirstName = "ياسمين", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2021, 1, 19), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id },
            new { Id = student18Id, FirstName = "حسن", FatherName = "حسام", GrandpaName = "كامل", DateOfBirth = new DateTime(2020, 2, 28), ParentPhone = "0103334444", Address = "٧٨٩ طريق الحديقة، الجيزة", IsActive = true, ParentId = parent3Id, ClassroomId = class3Id },
            new { Id = student19Id, FirstName = "مريم", FatherName = "أحمد", GrandpaName = "محمد", DateOfBirth = new DateTime(2019, 8, 15), ParentPhone = "01012345678", Address = "١٢٣ شارع الرئيسي، القاهرة", IsActive = true, ParentId = parent1Id, ClassroomId = class1Id },
            new { Id = student20Id, FirstName = "آدم", FatherName = "منى", GrandpaName = "علي", DateOfBirth = new DateTime(2020, 11, 11), ParentPhone = "01098765432", Address = "٤٥٦ شارع الحديقة، الإسكندرية", IsActive = true, ParentId = parent2Id, ClassroomId = class2Id }
        );

        // 🔹 Subjects
        var mathId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000001");
        var scienceId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000002");
        var arabicId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000003");
        var englishId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000004");
        var artId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000005");
        var peId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000006");
        var csId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000007");

        modelBuilder.Entity<Subject>().HasData(
            new { Id = mathId, Name = "رياضيات" },
            new { Id = scienceId, Name = "علوم" },
            new { Id = arabicId, Name = "عربي" },
            new { Id = englishId, Name = "لغة إنجليزية" },
            new { Id = artId, Name = "تربية فنية" },
            new { Id = peId, Name = "تربية رياضية" },
            new { Id = csId, Name = "علوم الحاسوب" }
        );


        // 🔹 Teachers
        var teacher1Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var teacher2Id = Guid.Parse("55555555-5555-5555-5555-555555555555");
        var teacher3Id = Guid.Parse("66666666-6666-6666-6666-666666666666");
        var teacher4Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var teacher5Id = Guid.Parse("88888888-8888-8888-8888-888888888888");
        var teacher6Id = Guid.Parse("99999999-9999-9999-9999-999999999999");
        var teacher7Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var teacher8Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var teacher9Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        var teacher10Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

        modelBuilder.Entity<Teacher>().HasData(
            new { Id = teacher1Id, FullName = "فاطمة إبراهيم", SubjectId = mathId, PhoneNumber = "0105551234", IsActive = true },
            new { Id = teacher2Id, FullName = "أماني صلاح", SubjectId = scienceId, PhoneNumber = "0107779999", IsActive = true },
            new { Id = teacher3Id, FullName = "عائشة مصطفى", SubjectId = arabicId, PhoneNumber = "0102226666", IsActive = true },
            new { Id = teacher4Id, FullName = "أميرة عبد الله", SubjectId = englishId, PhoneNumber = "0108881111", IsActive = true },
            new { Id = teacher5Id, FullName = "هالة محمود", SubjectId = artId, PhoneNumber = "0109992222", IsActive = false },
            new { Id = teacher6Id, FullName = "خديجة حسن", SubjectId = peId, PhoneNumber = "0103335555", IsActive = true },
            new { Id = teacher7Id, FullName = "منى يوسف", SubjectId = csId, PhoneNumber = "0104446666", IsActive = true },
            new { Id = teacher8Id, FullName = "سعاد علي", SubjectId = mathId, PhoneNumber = "0101113333", IsActive = true },
            new { Id = teacher9Id, FullName = "جميلة عبد الرحمن", SubjectId = scienceId, PhoneNumber = "0106668888", IsActive = false },
            new { Id = teacher10Id, FullName = "رنا سمير", SubjectId = arabicId, PhoneNumber = "0100007777", IsActive = true }
        );


        modelBuilder.Entity<TeacherClassroom>().HasData(
            // teacher1 teaches all classrooms
            new { TeacherId = teacher1Id, ClassroomId = class1Id },
            new { TeacherId = teacher1Id, ClassroomId = class2Id },
            new { TeacherId = teacher1Id, ClassroomId = class3Id },

            // teacher2 teaches class1 and class2
            new { TeacherId = teacher2Id, ClassroomId = class1Id },
            new { TeacherId = teacher2Id, ClassroomId = class2Id },

            // teacher3 teaches class2 and class3
            new { TeacherId = teacher3Id, ClassroomId = class2Id },
            new { TeacherId = teacher3Id, ClassroomId = class3Id }
        );

    }
}
