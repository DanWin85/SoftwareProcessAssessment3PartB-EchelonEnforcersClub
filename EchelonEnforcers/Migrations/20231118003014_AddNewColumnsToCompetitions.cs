using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EchelonEnforcers.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnsToCompetitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Competitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Competitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Competitions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Competitions");
        }
    }
}
