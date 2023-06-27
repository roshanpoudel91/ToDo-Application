using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3019623d-ffc6-4414-8e6d-800b25964161");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "c6cc5834-e3a8-4b23-bb9b-d2fb2baff46a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "439201eb-12ce-4614-92f6-15865a75c6a6", "AQAAAAEAACcQAAAAEGfZKVOrrZObAylXz2x4frx4t/cVtHUj5NKAdf3JWG/K1nqv2s9bc4dEE99kxrgEIg==", "3dc30ec0-c3c0-48a3-a8a8-45a42cd33869" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8ce6780e-e569-4950-8303-2fb04a3f8c02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "68ded4f4-d367-41f4-9b53-9f2270c9422c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "536144f7-9a49-4246-a6dd-b883ac0f4119", "AQAAAAEAACcQAAAAENlWwoasgYVNpyKkSxtCxcvWgDGxtLSYiet8RZ2tYchhg+TWcAT51fKa6KD3CID39g==", "c5a44f74-2728-4032-8dc7-53461d7b7704" });
        }
    }
}
