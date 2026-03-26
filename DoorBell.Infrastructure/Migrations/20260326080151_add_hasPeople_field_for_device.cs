using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoorBell.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_hasPeople_field_for_device : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPeople",
                table: "Devices",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPeople",
                table: "Devices");
        }
    }
}
