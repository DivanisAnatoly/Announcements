using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcements.Infrastructure.Migrations
{
    public partial class Added_Enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementID",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AnnouncementStatuses_StatusID",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Users_UserID",
                table: "UserFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStatuses_StatusID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AnnouncementStatuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_StatusID",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Name", "Password", "Phone", "Role", "Status" },
                values: new object[] { 2, "petrov@gmail.com", "Petr Petrov", "password", "+79780452647", 0, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Name", "Password", "Phone", "Role", "Status" },
                values: new object[] { 3, "ivanov@gmail.com", "Ivan Ivanov", "password", "+79780947386", 0, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementID",
                table: "AnnouncementFiles",
                column: "AnnouncementID",
                principalTable: "Announcements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Users_UserID",
                table: "UserFiles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementID",
                table: "AnnouncementFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Users_UserID",
                table: "UserFiles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Announcements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnnouncementStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "User" });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Normal" });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Deleted" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "RoleID", "StatusID" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusID",
                table: "Users",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_StatusID",
                table: "Announcements",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementFiles_Announcements_AnnouncementID",
                table: "AnnouncementFiles",
                column: "AnnouncementID",
                principalTable: "Announcements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AnnouncementStatuses_StatusID",
                table: "Announcements",
                column: "StatusID",
                principalTable: "AnnouncementStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Users_UserID",
                table: "UserFiles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStatuses_StatusID",
                table: "Users",
                column: "StatusID",
                principalTable: "UserStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
