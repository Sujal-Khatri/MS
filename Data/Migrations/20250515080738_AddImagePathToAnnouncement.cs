using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalSolutions.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Announcements",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Announcements");
        }
    }
}
