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
                value: "27a267fb-d225-4123-b1b6-2e5d53b3dcf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "4a45a61c-1494-4ca9-a825-5c65b416fd4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcdd9c8d-49f6-49cc-848e-e47061985654", "AQAAAAEAACcQAAAAEGEvsXInJ5wHlwoWqG71N5qeWgi3VnMrhct+uXPeNq6BLr3Cv6qRdQQ5B62rKfwC9A==", "21941112-0c93-4d17-98ad-facd7bce4d29" });
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
