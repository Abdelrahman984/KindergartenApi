using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BigSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "IsActive", "ParentId", "ParentPhone" },
                values: new object[,]
                {
                    { new Guid("11111111-aaaa-aaaa-aaaa-111111111111"), "٧٨٩ طريق الحديقة، الجيزة، مصر", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "ليلى", "يوسف", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("22222222-bbbb-bbbb-bbbb-222222222222"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "محمود", "سعيد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("33333333-cccc-cccc-cccc-333333333333"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "نور", "حسن", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("44444444-dddd-dddd-dddd-444444444444"), "٧٨٩ طريق الحديقة، الجيزة، مصر", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "زياد", "يوسف", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("55555555-eeee-eeee-eeee-555555555555"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "جنى", "علي", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("66666666-aaaa-aaaa-aaaa-666666666666"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "فارس", "حسن", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("77777777-bbbb-bbbb-bbbb-777777777777"), "٧٨٩ طريق الحديقة، الجيزة، مصر", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "هنا", "كامل", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("88888888-cccc-cccc-cccc-888888888888"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سيف", "محمد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("99999999-dddd-dddd-dddd-999999999999"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "ريم", "علي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"), "٧٨٩ طريق الحديقة، الجيزة، مصر", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "طارق", "كامل", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سلمى", "كمال", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "ياسمين", "فوزي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"), "٧٨٩ طريق الحديقة، الجيزة، مصر", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "حسن", "يوسف", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "مريم", "سعيد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "آدم", "حسن", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" }
                });

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "FullName",
                value: "أماني صلاح");

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "FullName", "IsActive", "PhoneNumber", "Subject" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), "سعيد عبد الله", true, "0108881111", "لغة إنجليزية" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "هالة محمود", true, "0109992222", "تربية فنية" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "خالد حسن", true, "0103335555", "تربية رياضية" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "منى يوسف", true, "0104446666", "علوم الحاسوب" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("77777777-bbbb-bbbb-bbbb-777777777777"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("88888888-cccc-cccc-cccc-888888888888"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("99999999-dddd-dddd-dddd-999999999999"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.UpdateData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "FullName",
                value: "محمد صلاح");
        }
    }
}
