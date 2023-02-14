using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Announcements.Infrastructure.Migrations
{
    public partial class AddedCommentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name", "ParentCategoryID" },
                values: new object[] { 1, "resorses", null });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Moscow" });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "ID", "CategoryID", "Description", "OwnerID", "Price", "PublishDate", "RegionID", "Status", "Title" },
                values: new object[] { 1, 1, "...", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "OOO gasprom" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Announcements",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comments");
        }
    }
}
