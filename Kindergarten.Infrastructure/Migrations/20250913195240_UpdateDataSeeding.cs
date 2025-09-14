using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"),
                column: "GrandpaName",
                value: "كامل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"),
                column: "GrandpaName",
                value: "محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"),
                column: "GrandpaName",
                value: "علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"),
                column: "GrandpaName",
                value: "كامل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"),
                column: "GrandpaName",
                value: "محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"),
                column: "GrandpaName",
                value: "علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                column: "GrandpaName",
                value: "محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"),
                column: "GrandpaName",
                value: "علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"),
                column: "GrandpaName",
                value: "كامل");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "GrandpaName",
                value: "محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"),
                column: "GrandpaName",
                value: "محمد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "GrandpaName",
                value: "علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"),
                column: "GrandpaName",
                value: "علي");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "IsActive",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-aaaa-aaaa-111111111111"),
                column: "GrandpaName",
                value: "يوسف");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("22222222-bbbb-bbbb-bbbb-222222222222"),
                column: "GrandpaName",
                value: "سعيد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("33333333-cccc-cccc-cccc-333333333333"),
                column: "GrandpaName",
                value: "حسن");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("44444444-dddd-dddd-dddd-444444444444"),
                column: "GrandpaName",
                value: "يوسف");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("55555555-eeee-eeee-eeee-555555555555"),
                column: "GrandpaName",
                value: "علي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("66666666-aaaa-aaaa-aaaa-666666666666"),
                column: "GrandpaName",
                value: "حسن");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbb2-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                column: "GrandpaName",
                value: "كمال");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ccccccc3-bbbb-bbbb-bbbb-cccccccccccc"),
                column: "GrandpaName",
                value: "فوزي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ddddddd4-cccc-cccc-cccc-dddddddddddd"),
                column: "GrandpaName",
                value: "يوسف");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "GrandpaName",
                value: "كمال");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeee5-dddd-dddd-dddd-eeeeeeeeeeee"),
                column: "GrandpaName",
                value: "سعيد");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "GrandpaName",
                value: "فوزي");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("fffffff6-eeee-eeee-eeee-ffffffffffff"),
                column: "GrandpaName",
                value: "حسن");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "IsActive",
                value: true);
        }
    }
}
