using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class priority1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1ace2052-c049-4f24-8c6e-7caf125e13ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65764886-4f92-4c2d-b426-a0fe8b26e855",
                column: "ConcurrencyStamp",
                value: "b0c3bca0-5000-400d-b547-d54fd171c0e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f816e6-983b-4fbd-a0a3-2f8e577a7350", "AQAAAAEAACcQAAAAEKLBWdCj5bbBLuGXthqNyzLfuRGZiQS+9g1UfI0ExvLddmBKG+/eyaYnK1YWq9Z8Wg==", "7febdb62-acd8-4607-9457-aac2b7a85fbb" });
        }
    }
}
