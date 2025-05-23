using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSport.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedboolreported : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reported",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reported",
                table: "Posts");
        }
    }
}
