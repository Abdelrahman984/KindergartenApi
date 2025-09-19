using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FeesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Status",
                value: "Overdue");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Status",
                value: "Overdue");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Status",
                value: "Overdue");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "Status",
                value: "Overdue");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "Status",
                value: "Overdue");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "Status",
                value: "Overdue");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "PaymentDate",
                value: new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "PaymentDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "PaymentDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Status",
                value: "Paid");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "PaymentDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "PaymentDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "Status",
                value: "Paid");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "PaymentDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "PaymentDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "Status",
                value: "Paid");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "PaymentDate",
                value: null);
        }
    }
}
