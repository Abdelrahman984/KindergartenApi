using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandpaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Students_Parent_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClassroom",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClassroom", x => new { x.TeacherId, x.ClassroomId });
                    table.ForeignKey(
                        name: "FK_TeacherClassroom_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherClassroom_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), 20, "KG1" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 25, "KG2" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 30, "KG3" }
                });

            migrationBuilder.InsertData(
                table: "Parent",
                columns: new[] { "Id", "Address", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "١٢٣ شارع الرئيسي، القاهرة، مصر", "أحمد علي", "01012345678" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", "منى حسن", "01098765432" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "٧٨٩ طريق الحديقة، الجيزة، مصر", "حسام يوسف", "0103334444" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "FullName", "IsActive", "PhoneNumber", "Subject" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "فاطمة إبراهيم", true, "0105551234", "رياضيات" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "محمد صلاح", true, "0107779999", "علوم" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "عائشة مصطفى", true, "0102226666", "عربي" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "IsActive", "ParentId", "ParentPhone" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "عمر", "محمد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "سارة", "علي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "٧٨٩ طريق الحديقة، الجيزة، مصر", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "يوسف", "كامل", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "١٢٣ شارع الرئيسي، القاهرة، مصر", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "ملك", "كمال", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "٤٥٦ شارع الحديقة، الإسكندرية، مصر", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "علا", "فوزي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" }
                });

            migrationBuilder.InsertData(
                table: "TeacherClassroom",
                columns: new[] { "ClassroomId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("66666666-6666-6666-6666-666666666666") }
                });

            migrationBuilder.InsertData(
                table: "Attendance",
                columns: new[] { "Id", "Date", "IsPresent", "StudentId" },
                values: new object[,]
                {
                    { new Guid("11111111-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("22222222-bbbb-cccc-dddd-222222222222"), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("33333333-cccc-dddd-eeee-333333333333"), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("44444444-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("44444444-aaaa-bbbb-cccc-222222222222"), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("44444444-aaaa-bbbb-cccc-333333333333"), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("55555555-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("55555555-aaaa-bbbb-cccc-222222222222"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("55555555-aaaa-bbbb-cccc-333333333333"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("66666666-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("66666666-aaaa-bbbb-cccc-222222222222"), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("66666666-aaaa-bbbb-cccc-333333333333"), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("77777777-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("77777777-aaaa-bbbb-cccc-222222222222"), new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("77777777-aaaa-bbbb-cccc-333333333333"), new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("88888888-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("88888888-aaaa-bbbb-cccc-222222222222"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("88888888-aaaa-bbbb-cccc-333333333333"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("99999999-aaaa-bbbb-cccc-111111111111"), new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("99999999-aaaa-bbbb-cccc-222222222222"), new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("99999999-aaaa-bbbb-cccc-333333333333"), new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("aaaa1111-1111-1111-1111-aaaaaaaaaaaa"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa2222-2222-2222-2222-aaaaaaaaaaaa"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa3333-3333-3333-3333-aaaaaaaaaaaa"), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa4444-4444-4444-4444-aaaaaaaaaaaa"), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa5555-5555-5555-5555-aaaaaaaaaaaa"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa6666-6666-6666-6666-aaaaaaaaaaaa"), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa7777-7777-7777-7777-aaaaaaaaaaaa"), new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa8888-8888-8888-8888-aaaaaaaaaaaa"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaa9999-9999-9999-9999-aaaaaaaaaaaa"), new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("aaaaaaaa-1111-1111-1111-aaaaaaaaaaaa"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("bbbb1111-1111-1111-1111-bbbbbbbbbbbb"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb2222-2222-2222-2222-bbbbbbbbbbbb"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb3333-3333-3333-3333-bbbbbbbbbbbb"), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb4444-4444-4444-4444-bbbbbbbbbbbb"), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb5555-5555-5555-5555-bbbbbbbbbbbb"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb6666-6666-6666-6666-bbbbbbbbbbbb"), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb7777-7777-7777-7777-bbbbbbbbbbbb"), new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb8888-8888-8888-8888-bbbbbbbbbbbb"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbb9999-9999-9999-9999-bbbbbbbbbbbb"), new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("bbbbbbbb-2222-2222-2222-bbbbbbbbbbbb"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("cccccccc-3333-3333-3333-cccccccccccc"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("dddddddd-4444-4444-4444-dddddddddddd"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("eeeeeeee-5555-5555-5555-eeeeeeeeeeee"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("ffffffff-6666-6666-6666-ffffffffffff"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassroom_ClassroomId",
                table: "TeacherClassroom",
                column: "ClassroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "TeacherClassroom");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Parent");
        }
    }
}
