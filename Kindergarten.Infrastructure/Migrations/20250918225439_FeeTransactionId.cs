using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kindergarten.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FeeTransactionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "TransactionId",
                value: "1DONE1");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "TransactionId",
                value: "2DONE2");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "TransactionId",
                value: "3DONE3");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "TransactionId",
                value: "4DONE4");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                column: "TransactionId",
                value: "5DONE5");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                column: "TransactionId",
                value: "6DONE6");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                column: "TransactionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                column: "TransactionId",
                value: "7DONE7");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Fees");
        }
    }
}
