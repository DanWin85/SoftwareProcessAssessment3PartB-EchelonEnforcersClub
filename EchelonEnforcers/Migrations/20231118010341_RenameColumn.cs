using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EchelonEnforcers.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Competitions",
                newName: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Competitions",
                newName: "Date");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Competitions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
