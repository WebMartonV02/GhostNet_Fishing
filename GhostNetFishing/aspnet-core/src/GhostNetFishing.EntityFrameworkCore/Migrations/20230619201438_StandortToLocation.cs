using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostNetFishing.Migrations
{
    /// <inheritdoc />
    public partial class StandortToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Standort",
                table: "AppGhostNet",
                newName: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "AppGhostNet",
                newName: "Standort");
        }
    }
}
