using Microsoft.EntityFrameworkCore.Migrations;

namespace VSApp.Infrastructure.Migrations
{
    public partial class migrate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UpdatedUserId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Clients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UpdatedUserId",
                table: "Clients",
                newName: "IX_Clients_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Clients",
                newName: "UpdatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                newName: "IX_Clients_UpdatedUserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedUserId",
                table: "Clients",
                column: "CreatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedUserId",
                table: "Clients",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UpdatedUserId",
                table: "Clients",
                column: "UpdatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
