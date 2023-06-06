using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c6709e96-0151-425d-9b68-0e2f0c123688");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "f1cc0a85-094c-4034-a5c8-d394a7e6f977");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9330341e-92d4-4b39-9175-38e53be9d2eb", "AQAAAAEAACcQAAAAEOoZx54/Trj/B6XLemucsxfPYafNr3LKg3iLPgw3bbWADQYL8CpTyhB8jInmnrNBhA==", "80e20fa0-e33c-4bc8-9ea9-8e9b20e1652c" });
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
