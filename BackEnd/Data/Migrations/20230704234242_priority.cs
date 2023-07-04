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
                value: "43ff1642-98c4-4473-bf14-5b4b44da3029");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "0942a236-d9aa-42ac-9668-c5dd1973eebf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc66fa2-1aac-424e-883e-3e18e7f9530f", "AQAAAAEAACcQAAAAEOmE+2gudTsd0u5VuHheT5Pullam2Ercai1r68ytvYK1wMTcBT0T5F0/dZNdJlcV3g==", "13cacf91-5d8b-4c4a-9cd8-4a486fa9d684" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f8c04445-696a-42c1-afa7-98b12c3031c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "9e4ddfc2-1892-4ff4-acf7-3042141c8902");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ac8b402-c2a9-4c42-a7cf-c71f516406e2", "AQAAAAEAACcQAAAAEHbQf772JzOVYTJ/sMywMh4XcJ1eqxcFKGK22ISBs+5aFT/KGP1dOYzlY9cEIb/+Bw==", "68b3d427-0280-4bf9-960c-1f4117080d7f" });
        }
    }
}
