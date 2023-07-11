using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class iiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "711926d6-1122-4950-a756-e51662443c7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "ea829989-fab0-46d9-ae19-3d068c2b9b94");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbca2c1f-98bb-4013-93e7-9bd6438050c0", "AQAAAAEAACcQAAAAEKehvzLSyH9H2XHwJFTTJGd3/oBHt9z1Kw45/KKb4JM3rV2tzieDnt0hScIS/0hq+w==", "68ee41b5-468a-418a-a5b3-5aba38b3626a" });
        }
    }
}
