using Microsoft.EntityFrameworkCore.Migrations;

namespace VSApp.Infrastructure.Migrations
{
    public partial class serverModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_Users_CreatedUserId",
                table: "Servers");

            migrationBuilder.DropForeignKey(
                name: "FK_Servers_Users_UpdatedUserId",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Servers_CreatedUserId",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Servers_UpdatedUserId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Servers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Servers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Servers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Servers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servers_CreatedUserId",
                table: "Servers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_UpdatedUserId",
                table: "Servers",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_Users_CreatedUserId",
                table: "Servers",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_Users_UpdatedUserId",
                table: "Servers",
                column: "UpdatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
