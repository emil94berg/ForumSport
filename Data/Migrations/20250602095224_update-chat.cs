using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSport.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatechat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Chats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "Chats");
        }
    }
}
