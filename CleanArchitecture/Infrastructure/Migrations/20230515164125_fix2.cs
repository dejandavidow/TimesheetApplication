using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24839aac-8e36-427e-ba88-44fb53f074a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ae8f5b-9682-4ec5-b26d-34ba12bd12ab");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dd821ab-2a35-4feb-8f1c-7494bcf334cb", null, "Administrator", "ADMINISTRATOR" },
                    { "78ca5a36-f489-4eea-8296-4786b8b7402d", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MemberId1",
                table: "Projects",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_MemberId1",
                table: "Projects",
                column: "MemberId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_MemberId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_MemberId1",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dd821ab-2a35-4feb-8f1c-7494bcf334cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78ca5a36-f489-4eea-8296-4786b8b7402d");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24839aac-8e36-427e-ba88-44fb53f074a9", null, "Administrator", "ADMINISTRATOR" },
                    { "b3ae8f5b-9682-4ec5-b26d-34ba12bd12ab", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
