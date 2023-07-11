using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class jl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "df6f046b-dd88-4c36-932f-1b33b8a0c69f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "26bf717e-9b7f-4918-85fd-03e8034fae08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33f1d472-7c26-4708-ab09-9a37a0f02b1e", "AQAAAAEAACcQAAAAEGItycoCBXJi4Bp5mtchOhxyvSBCqcfdkKsQQ3YlUd6e/CBl3LZowRC/lGvNSaOBvg==", "71fc3062-f795-406c-baba-036ff0c7a2ec" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d832813d-e8e2-496a-b7f4-76ce87513d0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "0d187868-89bb-42a4-8d1a-ab4b80b546f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da53ac7d-28d7-4ecb-a914-0ff143793467", "AQAAAAEAACcQAAAAEAjqfSyFcM4qnxsHhCclurQSBQYpegYuqiBFvd4FrAgbbtWp3bkZx/OjqsF7gD8W4Q==", "d83d9d08-4b09-4642-a55d-4699554f34ad" });
        }
    }
}
