using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Announcements.Infrastructure.Migrations
{
    public partial class AddedAnnounFilesStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "AnnouncementFiles");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AnnouncementFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "ID", "CategoryID", "Description", "OwnerID", "Price", "PublishDate", "RegionID", "Status", "Title" },
                values: new object[] { 1, 1, "...", "98b651ae-c9aa-4731-9996-57352d525f7e", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "OOO gasprom" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1991ff6b-6a2f-46f1-a9ea-c5d53a50c285",
                column: "ConcurrencyStamp",
                value: "7fd14eef-98c7-496a-b8b2-af91e3f8a93b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7db2c9-9505-4c6e-abc3-366ee2bbea18",
                column: "ConcurrencyStamp",
                value: "c7c81a8e-172a-4f38-922b-2141e4f6fbe2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98b651ae-c9aa-4731-9996-57352d525f7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76d188f-1ee6-4608-9167-d779dd068ae1", "AQAAAAEAACcQAAAAEELWJpx3UfHd7YNVneTO97dB5qllX1ydPMXNVRDxVn/Y0xGwC5K5Eg+mT22YkosoUA==", "0adeecca-a651-4c63-8769-3b0b7e286e8c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Announcements",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AnnouncementFiles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "AnnouncementFiles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1991ff6b-6a2f-46f1-a9ea-c5d53a50c285",
                column: "ConcurrencyStamp",
                value: "26a3aa19-20f5-4ff6-8430-06124730e538");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7db2c9-9505-4c6e-abc3-366ee2bbea18",
                column: "ConcurrencyStamp",
                value: "097a3d78-310b-4b84-8996-316a9e87456d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98b651ae-c9aa-4731-9996-57352d525f7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "020b9eb6-d474-4cde-b8b3-fbda915b4688", "AQAAAAEAACcQAAAAEHrTz0rCKA+zalRWJFcdf9YGn25RWiJs0s3JoivEVy2WeepAvsH+WHifKb89tiPn+g==", "2c4622c5-b254-4907-978e-4ae336d22d60" });
        }
    }
}
