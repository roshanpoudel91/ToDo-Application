using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ade90f34-7431-4f97-a74e-63044296fba0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "a2a4af9f-6520-4b44-9eeb-d9c085559f8f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81f4e538-ea98-43e5-9862-b3f6f39ef6b8", "AQAAAAEAACcQAAAAEL+lP99vYVmvDp7yEG0vzNXY9xeYPKK6Ur7ftZ7aNg/9nBXH7DOtUwT6+0LAFB9UFA==", "48812d23-4ad4-492c-acbe-2676a8b80245" });
        }
    }
}
