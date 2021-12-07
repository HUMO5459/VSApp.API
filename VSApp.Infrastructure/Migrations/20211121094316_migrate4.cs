using Microsoft.EntityFrameworkCore.Migrations;

namespace VSApp.Infrastructure.Migrations
{
    public partial class migrate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_Users_CreatedUserId",
                table: "Cameras");

            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_Users_UpdatedUserId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_CreatedUserId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_UpdatedUserId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Cameras");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Cameras",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cameras",
                newName: "UpdatedUserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Cameras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_CreatedUserId",
                table: "Cameras",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_UpdatedUserId",
                table: "Cameras",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_Users_CreatedUserId",
                table: "Cameras",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_Users_UpdatedUserId",
                table: "Cameras",
                column: "UpdatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
