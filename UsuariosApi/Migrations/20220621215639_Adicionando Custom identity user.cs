using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class AdicionandoCustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "fc383b20-0aa0-474a-a270-2e78c0f62750");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "7de88014-ed75-4bc1-8558-cef3fd5a01a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d544b677-583c-46f6-b8d6-90be11b0b0fa", "AQAAAAEAACcQAAAAEAZYOrT8l23O/ag3XYyMqcJDdRr3CKnIFecEPHW7Dw1l1Ae8N6swrBWKuaG+jHUFRA==", "6f98a123-09d0-49fb-ad26-65b9de39a2cb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "eb45b340-39a8-4d2c-ab44-d5908c3321f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0eb10186-e6d3-4729-9a4d-2c43e0d0585d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "587bfdc4-937b-4160-a6c4-3eda0140af44", "AQAAAAEAACcQAAAAECt8WRPyC6PtQX/kHDpSwDkRLCdt6yidhT/gpGKsYjcL6kO2i91FLrWIrIYCTYU1pA==", "47f6f295-1f09-4180-a711-8b7e86ec2695" });
        }
    }
}
