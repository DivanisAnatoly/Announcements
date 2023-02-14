using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcements.Infrastructure.Migrations
{
    public partial class RemoveRolesFromDomin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "DomainUsers");

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12558b6d-7104-4f0f-bfb5-cce959239395", "anatolydivanis@gmail.com", "ANATOLYDIVANIS@GMAIL.COM", "AQAAAAEAACcQAAAAEIsgqooxuLm7kpQukaS4engY0joX1JxretIyfHUkiG4KdX7w3XJX4a/pSmIbIj6sGA==", "8bdfd09f-a509-4e21-9fc2-73b2db6a4ed8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "DomainUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1991ff6b-6a2f-46f1-a9ea-c5d53a50c285",
                column: "ConcurrencyStamp",
                value: "d76f81a1-7d6b-44a6-8f6f-7c4a53a96af7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff7db2c9-9505-4c6e-abc3-366ee2bbea18",
                column: "ConcurrencyStamp",
                value: "c2a80826-1773-4a86-80fc-73be8e3c0820");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98b651ae-c9aa-4731-9996-57352d525f7e",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42d7316c-21f7-46cb-97a6-53ea894c2306", null, null, "AQAAAAEAACcQAAAAEIk9PFlejFPWj80B2txQWBdNDeME5E4bKLxsrPGKtgbWydGptqHlGYQDtxPXuV+hGA==", "0b7fc89a-1061-4043-81e3-18c98b5fc5ea" });
        }
    }
}
