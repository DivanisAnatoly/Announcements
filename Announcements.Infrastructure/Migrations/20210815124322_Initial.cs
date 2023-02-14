using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Announcements.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "UserStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Announcements_AnnouncementStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "AnnouncementStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Announcements_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Announcements_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Announcements_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFiles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementFiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnnouncementFiles_Announcements_AnnouncementID",
                        column: x => x.AnnouncementID,
                        principalTable: "Announcements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    AnnouncementID = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Announcements_AnnouncementID",
                        column: x => x.AnnouncementID,
                        principalTable: "Announcements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Users",
                columns: new[] { "ID", "Email", "Name", "Password", "Phone", "RoleID", "StatusID" },
                values: new object[] { 1, "anatolydivanis@gmail.com", "Petr", "123456", "+79999999999", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementFiles_AnnouncementID",
                table: "AnnouncementFiles",
                column: "AnnouncementID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CategoryID",
                table: "Announcements",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_OwnerID",
                table: "Announcements",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_RegionID",
                table: "Announcements",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_StatusID",
                table: "Announcements",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnnouncementID",
                table: "Comments",
                column: "AnnouncementID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorID",
                table: "Comments",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UserID",
                table: "UserFiles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusID",
                table: "Users",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementFiles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AnnouncementStatuses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
