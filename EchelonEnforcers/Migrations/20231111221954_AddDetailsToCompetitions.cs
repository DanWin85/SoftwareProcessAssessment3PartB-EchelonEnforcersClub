using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EchelonEnforcers.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailsToCompetitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Competitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Competitions");
        }
    }
}
