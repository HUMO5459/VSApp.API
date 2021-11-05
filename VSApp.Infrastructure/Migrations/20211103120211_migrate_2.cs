using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VSApp.Infrastructure.Migrations
{
    public partial class migrate_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevicesIPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MCP_IP = table.Column<int>(type: "integer", nullable: false),
                    MCP_Login = table.Column<string>(type: "text", nullable: true),
                    MCP_Password = table.Column<string>(type: "text", nullable: true),
                    Cam_IP = table.Column<int>(type: "integer", nullable: false),
                    Cam_Login = table.Column<int>(type: "integer", nullable: false),
                    Cam_Password = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesIPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicesIPs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevicesIPs_UserId",
                table: "DevicesIPs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicesIPs");
        }
    }
}
