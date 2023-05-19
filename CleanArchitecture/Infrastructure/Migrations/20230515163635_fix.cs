using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_MemberDomain_MemberId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "MemberDomain");

            migrationBuilder.DropIndex(
                name: "IX_Projects_MemberId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25aab445-950b-4463-b70b-0a64bea8d834");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4804eac0-fa36-4556-b8ee-2ba18d4063ec");

            migrationBuilder.DropColumn(
                name: "MemberId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MemberDomain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberDomain", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25aab445-950b-4463-b70b-0a64bea8d834", null, "Employee", "EMPLOYEE" },
                    { "4804eac0-fa36-4556-b8ee-2ba18d4063ec", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MemberId",
                table: "Projects",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_MemberDomain_MemberId",
                table: "Projects",
                column: "MemberId",
                principalTable: "MemberDomain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
