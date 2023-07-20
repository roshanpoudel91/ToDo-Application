using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class somethingNew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "669ee2ac-23d9-4f46-8480-9aa624ab663d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "3202d5a7-6b49-4d21-bd66-89bcc0f5a487");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49ed1b40-65ea-4f2a-9d22-9f5fd47224f2", "AQAAAAEAACcQAAAAEKMW/ScS53z0qiTKkjDfZD5T4l3wIlyYLymAzTIjnfevlxAr67LkVuwu2G8KAh0Wpg==", "b9878c5b-1aba-4c5d-ad1b-cc26871a808a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "70dd577e-e197-4434-b8ae-e227d380f85a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "7e6f691e-75a2-4052-bd48-d132381a6d20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56088d5a-6cde-4b62-8421-ae12f1b6e4da", "AQAAAAEAACcQAAAAEFddMZ8MBSe7ZEN85b9zx0beHqhcSZvhC0oHL/X/m4xtpElx7NVO7UmzWVwEqROU+A==", "289957dc-06cd-463e-902f-5668287c9bbf" });
        }
    }
}
