using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcements.Infrastructure.Migrations
{
    public partial class AddedFileStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "UserFiles");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserFiles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "UserFiles",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
