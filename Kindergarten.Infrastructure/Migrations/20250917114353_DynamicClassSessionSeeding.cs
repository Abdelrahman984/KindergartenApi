using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DynamicClassSessionSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("1111aaaa-bbbb-cccc-dddd-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("2222bbbb-cccc-dddd-eeee-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("3333cccc-dddd-eeee-ffff-111111111111"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-2222-3333-4444-555555555555"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-3333-4444-5555-666666666666"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("cccc3333-4444-5555-6666-777777777777"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("dddd4444-5555-6666-7777-888888888888"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("eeee5555-6666-7777-8888-999999999999"));

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: new Guid("ffff6666-7777-8888-9999-aaaaaaaaaaaa"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassSessions",
                columns: new[] { "Id", "ClassroomId", "EndTime", "StartTime", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("1111aaaa-bbbb-cccc-dddd-eeeeeeeeeeee"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 9, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000007"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("2222bbbb-cccc-dddd-eeee-ffffffffffff"), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 9, 19, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 9, 15, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000001"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("3333cccc-dddd-eeee-ffff-111111111111"), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 9, 19, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 19, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000002"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("aaaa1111-2222-3333-4444-555555555555"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 9, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000001"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("bbbb2222-3333-4444-5555-666666666666"), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 9, 17, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 9, 15, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000002"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("cccc3333-4444-5555-6666-777777777777"), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 9, 17, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000003"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("dddd4444-5555-6666-7777-888888888888"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 9, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000004"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("eeee5555-6666-7777-8888-999999999999"), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 9, 18, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 9, 15, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000005"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("ffff6666-7777-8888-9999-aaaaaaaaaaaa"), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 9, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000006"), new Guid("99999999-9999-9999-9999-999999999999") }
                });
        }
    }
}
