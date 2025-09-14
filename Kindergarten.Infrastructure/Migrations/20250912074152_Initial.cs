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
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
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
                    table.PrimaryKey("PK_Teachers", x => x.Id);
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
                        name: "FK_Students_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Students_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClassrooms",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClassrooms", x => new { x.TeacherId, x.ClassroomId });
                    table.ForeignKey(
                        name: "FK_TeacherClassrooms_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherClassrooms_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), 20, "KG1" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 25, "KG2" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 30, "KG3" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Address", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "١٢٣ شارع الرئيسي، القاهرة", "أحمد علي", "01012345678" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "٤٥٦ شارع الحديقة، الإسكندرية", "منى حسن", "01098765432" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "٧٨٩ طريق الحديقة، الجيزة", "حسام يوسف", "0103334444" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FullName", "IsActive", "PhoneNumber", "Subject" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "فاطمة إبراهيم", true, "0105551234", "رياضيات" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "أماني صلاح", true, "0107779999", "علوم" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "عائشة مصطفى", true, "0102226666", "عربي" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "سعيد عبد الله", true, "0108881111", "لغة إنجليزية" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "هالة محمود", true, "0109992222", "تربية فنية" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "خالد حسن", true, "0103335555", "تربية رياضية" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "منى يوسف", true, "0104446666", "علوم الحاسوب" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "IsActive", "ParentId", "ParentPhone" },
                values: new object[,]
                {
                    { new Guid("11111111-aaaa-aaaa-aaaa-111111111111"), "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "ليلى", "يوسف", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("22222222-bbbb-bbbb-bbbb-222222222222"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "محمود", "سعيد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("33333333-cccc-cccc-cccc-333333333333"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "نور", "حسن", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("44444444-dddd-dddd-dddd-444444444444"), "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "زياد", "يوسف", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("55555555-eeee-eeee-eeee-555555555555"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "جنى", "علي", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("66666666-aaaa-aaaa-aaaa-666666666666"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "فارس", "حسن", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("77777777-bbbb-bbbb-bbbb-777777777777"), "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "هنا", "كامل", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("88888888-cccc-cccc-cccc-888888888888"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سيف", "محمد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("99999999-dddd-dddd-dddd-999999999999"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "ريم", "علي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"), "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "طارق", "كامل", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "عمر", "محمد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سلمى", "كمال", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "سارة", "علي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "ياسمين", "فوزي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "يوسف", "كامل", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"), "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "حسن", "يوسف", true, new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "ملك", "كمال", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"), "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "مريم", "سعيد", true, new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "علا", "فوزي", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" },
                    { new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"), "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "آدم", "حسن", true, new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" }
                });

            migrationBuilder.InsertData(
                table: "TeacherClassrooms",
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

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
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
                name: "IX_TeacherClassrooms_ClassroomId",
                table: "TeacherClassrooms",
                column: "ClassroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "TeacherClassrooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
