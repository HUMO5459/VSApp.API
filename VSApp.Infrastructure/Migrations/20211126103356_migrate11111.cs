using Microsoft.EntityFrameworkCore.Migrations;

namespace VSApp.Infrastructure.Migrations
{
    public partial class migrate11111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MCP_Password",
                table: "Servers",
                newName: "ServerPassword");

            migrationBuilder.RenameColumn(
                name: "MCP_Login",
                table: "Servers",
                newName: "ServerLogin");

            migrationBuilder.RenameColumn(
                name: "MCP_IP",
                table: "Servers",
                newName: "ServerPort");

            migrationBuilder.RenameColumn(
                name: "Cam_Port",
                table: "Cameras",
                newName: "CamPort");

            migrationBuilder.RenameColumn(
                name: "Cam_Password",
                table: "Cameras",
                newName: "CamPassword");

            migrationBuilder.RenameColumn(
                name: "Cam_Login",
                table: "Cameras",
                newName: "CamLogin");

            migrationBuilder.RenameColumn(
                name: "Cam_IP",
                table: "Cameras",
                newName: "CamIP");

            migrationBuilder.AddColumn<int>(
                name: "ServerIP",
                table: "Servers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerIP",
                table: "Servers");

            migrationBuilder.RenameColumn(
                name: "ServerPort",
                table: "Servers",
                newName: "MCP_IP");

            migrationBuilder.RenameColumn(
                name: "ServerPassword",
                table: "Servers",
                newName: "MCP_Password");

            migrationBuilder.RenameColumn(
                name: "ServerLogin",
                table: "Servers",
                newName: "MCP_Login");

            migrationBuilder.RenameColumn(
                name: "CamPort",
                table: "Cameras",
                newName: "Cam_Port");

            migrationBuilder.RenameColumn(
                name: "CamPassword",
                table: "Cameras",
                newName: "Cam_Password");

            migrationBuilder.RenameColumn(
                name: "CamLogin",
                table: "Cameras",
                newName: "Cam_Login");

            migrationBuilder.RenameColumn(
                name: "CamIP",
                table: "Cameras",
                newName: "Cam_IP");
        }
    }
}
