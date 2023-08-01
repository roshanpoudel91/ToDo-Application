using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class tdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTodo",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ed205d13-89aa-4a82-8161-ca0a6078a03e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "471c7ef2-c361-42a8-add1-d141061de394");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daa54e97-7f6d-4264-93d6-caa36395522e", "AQAAAAEAACcQAAAAEKbuh7eSrT/N4qSReLNscO5uccDlF/RRV5QZMEL99n4RJhYzHSgDK7WXuoyl08Zu8w==", "9880e79b-41cf-4b02-b781-46258de51980" });
        }
    }
}
