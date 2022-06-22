using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0eb10186-e6d3-4729-9a4d-2c43e0d0585d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "eb45b340-39a8-4d2c-ab44-d5908c3321f9", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "587bfdc4-937b-4160-a6c4-3eda0140af44", "AQAAAAEAACcQAAAAECt8WRPyC6PtQX/kHDpSwDkRLCdt6yidhT/gpGKsYjcL6kO2i91FLrWIrIYCTYU1pA==", "47f6f295-1f09-4180-a711-8b7e86ec2695" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "53ac3048-3e4e-4a8e-a25a-5d58f9e407fb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a6a5aff-b490-4882-a9f5-1a4f36b7a002", "AQAAAAEAACcQAAAAEJY75Q06TEwbd9p2fVwthpSoSS7xkPVN3jWjQ8IcSPOji+6Jb9+oNi8ewFBksYgJnw==", "8c26236e-1977-4a3c-bcca-fead75296111" });
        }
    }
}
