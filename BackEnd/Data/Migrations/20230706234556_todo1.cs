using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class todo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c3886771-1d37-4564-af87-34ca15e502be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "fb20fef0-d2b5-4970-813a-bf0ec1ed10c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "134a9b7f-a94d-4a97-ba40-5d664f9db39d", "AQAAAAEAACcQAAAAEH9Zv1cPPFEhZUDDw+D7r2Gs4+WFCkZp0rPPYBv1O9ZUlKwcNn5kg9kHGjBdQnKI6A==", "dcc7efcf-a20c-4358-8171-a27251867b64" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "824d52bd-5fe0-4f8a-8ad6-a13ed24ca42a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "b526cd28-6d35-4ea2-84bf-dbf40613f278");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a42de5d-6f1d-483e-8f62-decfba952f04", "AQAAAAEAACcQAAAAEH5O3BEuPiojQ8/mUC2m0jAm7RnI3FXJwVHkmdaMKpiVQflNj4DLYw36uyRf/9B/2Q==", "0227a747-947d-49c5-924a-e4e81170dfe7" });
        }
    }
}
