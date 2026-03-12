using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoorBell.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentDeviceId",
                table: "Devices",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Devices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentDeviceId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");
        }
    }
}
