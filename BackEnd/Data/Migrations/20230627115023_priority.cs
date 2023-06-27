using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class priority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1ace2052-c049-4f24-8c6e-7caf125e13ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "b0c3bca0-5000-400d-b547-d54fd171c0e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f816e6-983b-4fbd-a0a3-2f8e577a7350", "AQAAAAEAACcQAAAAEKLBWdCj5bbBLuGXthqNyzLfuRGZiQS+9g1UfI0ExvLddmBKG+/eyaYnK1YWq9Z8Wg==", "7febdb62-acd8-4607-9457-aac2b7a85fbb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
