using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class addedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTodo",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5e2dc141-5527-4aab-9116-7d6f572bc776");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "f630a2f2-b5f4-471a-9ca8-1fc19df73766");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2f76262-2025-4585-a1ea-fb4d6d59f7d6", "AQAAAAEAACcQAAAAECDurPtzige9rE7uhH2miBIZNl0X1pZXnrs4KrGfsJQ8NrGrOzyQQ3J6LMbLNBGdXw==", "53a4a5ac-c3df-44a1-ad74-5a3e7b116d99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ToDo");

            migrationBuilder.AddColumn<bool>(
                name: "IsTodo",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b4bf11da-18af-4d6c-a893-ea163bdf3e24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "d3d2a11f-b23a-4ba3-97dd-97dc2babd878");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86b2c97f-817a-4827-bb86-8bbca2fb5ae6", "AQAAAAEAACcQAAAAEJn0GDgHmJ0ExkESPoNNUua99L5Fy1JmPY+B2UxGzcCu2MUWm8qA06kRl/fT83wIoQ==", "38ab4b58-8a84-40a9-82a5-13d50c22c186" });
        }
    }
}
