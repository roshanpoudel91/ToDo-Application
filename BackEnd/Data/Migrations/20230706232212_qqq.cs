using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class qqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0290f926-4ff2-4f35-b4f0-166fb0d17fca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "26ee39f1-8454-402f-815a-b13eb697b511");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adefedc9-909e-459f-9266-121374b79258", "AQAAAAEAACcQAAAAEJiOIUv3gTm2T4vmMvDNzvifVh1D4oID0sZYcJaDj0hJUTiWaMTH6fpDZl4xnvr9UA==", "5dd8c132-c976-4010-8bcd-d27c81e14d86" });
        }
    }
}
