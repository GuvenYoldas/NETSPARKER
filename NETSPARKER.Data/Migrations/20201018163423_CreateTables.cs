using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETSPARKER.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCompany = table.Column<int>(nullable: false),
                    IsActive = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    CreatedDateOffsetUtc = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedIp = table.Column<string>(nullable: true),
                    UpdatedDateOffsetUtc = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedIp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    LastMonitorTime = table.Column<DateTime>(nullable: true),
                    NextMonitorTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCompany = table.Column<int>(nullable: false),
                    IsActive = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    CreatedDateOffsetUtc = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedIp = table.Column<string>(nullable: true),
                    UpdatedDateOffsetUtc = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedIp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SaltString = table.Column<string>(nullable: false),
                    AvatarUrl = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductNotifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCompany = table.Column<int>(nullable: false),
                    IsActive = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    CreatedDateOffsetUtc = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedIp = table.Column<string>(nullable: true),
                    UpdatedDateOffsetUtc = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedIp = table.Column<string>(nullable: true),
                    IDProduct = table.Column<int>(nullable: false),
                    IDNotificationType = table.Column<int>(nullable: false),
                    IDMonitoringInterval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNotifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductNotifications_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotifications_IDProduct",
                table: "ProductNotifications",
                column: "IDProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNotifications");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
