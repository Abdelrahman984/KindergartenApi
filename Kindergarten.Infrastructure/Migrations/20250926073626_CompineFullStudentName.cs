using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompineFullStudentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GrandpaName",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GrandpaName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "بكري", "ريم", "علي" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "حسام", "يوسف", "كامل" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "حسام", "ليلى", "كامل" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "حسام", "طارق", "كامل" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "طارق", "محمود", "سمير" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "طارق", "نور", "سمير" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("77777777-bbbb-bbbb-bbbb-777777777777"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "طارق", "سلمى", "سمير" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("88888888-cccc-cccc-cccc-888888888888"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "خالد", "زياد", "عادل" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("99999999-dddd-dddd-dddd-999999999999"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "خالد", "جنى", "عادل" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "خالد", "حسن", "عادل" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "أحمد", "عمر", "محمد" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "عمر", "فارس", "ناصر" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "أحمد", "ملك", "محمد" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "عمر", "هناء", "ناصر" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "أحمد", "سيف", "محمد" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "عمر", "مريم", "ناصر" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "بكري", "سارة", "علي" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "بكري", "ياسمين", "حسن" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "بكري", "علا", "علي" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"),
                columns: new[] { "FatherName", "FirstName", "GrandpaName" },
                values: new object[] { "خالد", "آدم", "عادل" });
        }
    }
}
