using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncresdeTeachersNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FullName", "IsActive", "PhoneNumber", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "سعاد علي", true, "0101113333", new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000001") },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "جميلة عبد الرحمن", false, "0106668888", new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000002") },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "رنا سمير", true, "0100007777", new Guid("aaaaaaaa-bbbb-cccc-dddd-000000000003") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));
        }
    }
}
