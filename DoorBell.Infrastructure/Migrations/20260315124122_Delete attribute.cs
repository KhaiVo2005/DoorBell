using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoorBell.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Deleteattribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Devices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Devices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
