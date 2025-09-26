using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnIgnoreFullNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"),
                column: "FullName",
                value: "ريم بكري علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"),
                column: "FullName",
                value: "يوسف حسام كامل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"),
                column: "FullName",
                value: "ليلى حسام كامل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"),
                column: "FullName",
                value: "طارق حسام كامل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"),
                column: "FullName",
                value: "محمود طارق سمير");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"),
                column: "FullName",
                value: "نور طارق سمير");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("77777777-bbbb-bbbb-bbbb-777777777777"),
                column: "FullName",
                value: "سلمى طارق سمير");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("88888888-cccc-cccc-cccc-888888888888"),
                column: "FullName",
                value: "زياد خالد عادل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("99999999-dddd-dddd-dddd-999999999999"),
                column: "FullName",
                value: "جنى خالد عادل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaa1-eeee-eeee-eeee-aaaaaaaaaaaa"),
                column: "FullName",
                value: "حسن خالد عادل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "FullName",
                value: "عمر أحمد محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                column: "FullName",
                value: "فارس عمر ناصر");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "FullName",
                value: "ملك أحمد محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"),
                column: "FullName",
                value: "هناء عمر ناصر");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "FullName",
                value: "سيف أحمد محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"),
                column: "FullName",
                value: "مريم عمر ناصر");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "FullName",
                value: "سارة بكري علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"),
                column: "FullName",
                value: "ياسمين بكري حسن");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "FullName",
                value: "علا بكري علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"),
                column: "FullName",
                value: "آدم خالد عادل");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Students");
        }
    }
}
