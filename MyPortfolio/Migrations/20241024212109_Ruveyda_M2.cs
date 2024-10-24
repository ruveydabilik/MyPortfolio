using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class Ruveyda_M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Portfolios",
                newName: "SecondImageSource");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectLink",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectTitle",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ProjectLink",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ProjectTitle",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "SecondImageSource",
                table: "Portfolios",
                newName: "ImageUrl");
        }
    }
}
