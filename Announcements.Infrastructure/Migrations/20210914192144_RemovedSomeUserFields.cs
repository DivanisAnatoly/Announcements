using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcements.Infrastructure.Migrations
{
    public partial class RemovedSomeUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DomainUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DomainUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "DomainUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "DomainUsers");

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

            migrationBuilder.InsertData(
                table: "DomainUsers",
                columns: new[] { "ID", "Status" },
                values: new object[] { "98b651ae-c9aa-4731-9996-57352d525f7e", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DomainUsers",
                keyColumn: "ID",
                keyValue: "98b651ae-c9aa-4731-9996-57352d525f7e");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DomainUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DomainUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "DomainUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "DomainUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1991ff6b-6a2f-46f1-a9ea-c5d53a50c285",
                column: "ConcurrencyStamp",
                value: "4774dc89-0829-464e-9bc2-4e0da96b7aca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7db2c9-9505-4c6e-abc3-366ee2bbea18",
                column: "ConcurrencyStamp",
                value: "da148343-27f0-4468-961b-8e3d43ef0f9a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98b651ae-c9aa-4731-9996-57352d525f7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12558b6d-7104-4f0f-bfb5-cce959239395", "AQAAAAEAACcQAAAAEIsgqooxuLm7kpQukaS4engY0joX1JxretIyfHUkiG4KdX7w3XJX4a/pSmIbIj6sGA==", "8bdfd09f-a509-4e21-9fc2-73b2db6a4ed8" });
        }
    }
}
