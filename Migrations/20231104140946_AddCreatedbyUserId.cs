using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdresserAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedbyUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Hairdressers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<ulong>(
                name: "IsCompleted",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Hairdressers");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Booking");
        }
    }
}
