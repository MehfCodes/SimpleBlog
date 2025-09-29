using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBlog.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorNameFromPostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
