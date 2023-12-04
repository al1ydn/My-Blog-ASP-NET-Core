using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class add_relation_appuser_message2_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserReceiverId",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserSenderId",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_AppUserReceiverId",
                table: "Message2s",
                column: "AppUserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_AppUserSenderId",
                table: "Message2s",
                column: "AppUserSenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserReceiverId",
                table: "Message2s",
                column: "AppUserReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserSenderId",
                table: "Message2s",
                column: "AppUserSenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserReceiverId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserSenderId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_AppUserReceiverId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_AppUserSenderId",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "AppUserReceiverId",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "AppUserSenderId",
                table: "Message2s");
        }
    }
}
