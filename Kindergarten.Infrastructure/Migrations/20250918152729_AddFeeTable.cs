using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "Amount", "DueDate", "ParentId", "PaymentDate", "Status", "StudentId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), null, "Pending", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), null, "Paid", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), null, "Pending", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), null, "Paid", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), null, "Pending", new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), null, "Paid", new Guid("11111111-aaaa-aaaa-aaaa-111111111111") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), null, "Pending", new Guid("22222222-bbbb-bbbb-bbbb-222222222222") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), null, "Paid", new Guid("33333333-cccc-cccc-cccc-333333333333") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), null, "Pending", new Guid("44444444-dddd-dddd-dddd-444444444444") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), null, "Pending", new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee") }
                });

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "FullName",
                value: "بكري حسن");

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Address", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "١٠١ شارع النيل، القاهرة", "طارق سمير", "0104445555" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "٢٠٢ شارع الحرية، الإسكندرية", "خالد عادل", "0106667777" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "٣٠٣ شارع الجامعة، الجيزة", "عمر ناصر", "0108889999" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "بكري", "ريم", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "يوسف", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "ليلى", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"),
                columns: new[] { "DateOfBirth", "FirstName" },
                values: new object[] { new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "طارق" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"),
                columns: new[] { "Address", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٠١ شارع النيل، القاهرة", new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "طارق", "محمود", "سمير", new Guid("44444444-4444-4444-4444-444444444444"), "0104445555" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"),
                columns: new[] { "Address", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٠١ شارع النيل، القاهرة", new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "طارق", "نور", "سمير", new Guid("44444444-4444-4444-4444-444444444444"), "0104445555" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("77777777-bbbb-bbbb-bbbb-777777777777"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٠١ شارع النيل، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "طارق", "سلمى", "سمير", new Guid("44444444-4444-4444-4444-444444444444"), "0104445555" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("88888888-cccc-cccc-cccc-888888888888"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٢٠٢ شارع الحرية، الإسكندرية", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "خالد", "زياد", "عادل", new Guid("55555555-5555-5555-5555-555555555555"), "0106667777" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("99999999-dddd-dddd-dddd-999999999999"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٢٠٢ شارع الحرية، الإسكندرية", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "خالد", "جنى", "عادل", new Guid("55555555-5555-5555-5555-555555555555"), "0106667777" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"),
                columns: new[] { "Address", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٢٠٢ شارع الحرية، الإسكندرية", new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "خالد", "حسن", "عادل", new Guid("55555555-5555-5555-5555-555555555555"), "0106667777" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٣٠٣ شارع الجامعة، الجيزة", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "عمر", "فارس", "ناصر", new Guid("66666666-6666-6666-6666-666666666666"), "0108889999" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "ملك", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٣٠٣ شارع الجامعة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "عمر", "هناء", "ناصر", new Guid("66666666-6666-6666-6666-666666666666"), "0108889999" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سيف", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٣٠٣ شارع الجامعة، الجيزة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "عمر", "مريم", "ناصر", new Guid("66666666-6666-6666-6666-666666666666"), "0108889999" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "بكري", "سارة", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "بكري", "ياسمين", "حسن", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "FatherName",
                value: "بكري");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"),
                columns: new[] { "Address", "FatherName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٢٠٢ شارع الحرية، الإسكندرية", "خالد", "عادل", new Guid("55555555-5555-5555-5555-555555555555"), "0106667777" });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "Amount", "DueDate", "ParentId", "PaymentDate", "Status", "StudentId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), null, "Paid", new Guid("55555555-eeee-eeee-eeee-555555555555") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), null, "Pending", new Guid("66666666-aaaa-aaaa-aaaa-666666666666") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), null, "Paid", new Guid("77777777-bbbb-bbbb-bbbb-777777777777") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55555555-5555-5555-5555-555555555555"), null, "Pending", new Guid("88888888-cccc-cccc-cccc-888888888888") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55555555-5555-5555-5555-555555555555"), null, "Paid", new Guid("99999999-dddd-dddd-dddd-999999999999") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55555555-5555-5555-5555-555555555555"), null, "Pending", new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("66666666-6666-6666-6666-666666666666"), null, "Paid", new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("66666666-6666-6666-6666-666666666666"), null, "Pending", new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("66666666-6666-6666-6666-666666666666"), null, "Paid", new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), 1500m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55555555-5555-5555-5555-555555555555"), null, "Paid", new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fees_ParentId",
                table: "Fees",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StudentId",
                table: "Fees",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "FullName",
                value: "منى حسن");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "ليلى", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "محمود", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "نور", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"),
                columns: new[] { "DateOfBirth", "FirstName" },
                values: new object[] { new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "زياد" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"),
                columns: new[] { "Address", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "جنى", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"),
                columns: new[] { "Address", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "فارس", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("77777777-bbbb-bbbb-bbbb-777777777777"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "هنا", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("88888888-cccc-cccc-cccc-888888888888"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سيف", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("99999999-dddd-dddd-dddd-999999999999"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "ريم", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"),
                columns: new[] { "Address", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "طارق", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "سلمى", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "سارة", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "منى", "ياسمين", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "يوسف", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٧٨٩ طريق الحديقة، الجيزة", new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسام", "حسن", "كامل", new Guid("33333333-3333-3333-3333-333333333333"), "0103334444" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "ملك", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"),
                columns: new[] { "Address", "ClassroomId", "DateOfBirth", "FatherName", "FirstName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "١٢٣ شارع الرئيسي، القاهرة", new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "مريم", "محمد", new Guid("11111111-1111-1111-1111-111111111111"), "01012345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "FatherName",
                value: "منى");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"),
                columns: new[] { "Address", "FatherName", "GrandpaName", "ParentId", "ParentPhone" },
                values: new object[] { "٤٥٦ شارع الحديقة، الإسكندرية", "منى", "علي", new Guid("22222222-2222-2222-2222-222222222222"), "01098765432" });
        }
    }
}
