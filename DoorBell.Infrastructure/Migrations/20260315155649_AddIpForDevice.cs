using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoorBell.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIpForDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "Devices",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "Devices");
        }
    }
}
