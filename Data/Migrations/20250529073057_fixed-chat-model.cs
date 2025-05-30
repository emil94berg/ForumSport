using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSport.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedchatmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ToUserId",
                table: "Chats",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_ToUserId",
                table: "Chats",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_ToUserId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ToUserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Chats");
        }
    }
}
