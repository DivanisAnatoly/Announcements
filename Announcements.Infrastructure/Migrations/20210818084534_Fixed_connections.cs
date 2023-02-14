using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcements.Infrastructure.Migrations
{
    public partial class Fixed_connections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Deleted" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Anatoly Divanis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Petr");
        }
    }
}
