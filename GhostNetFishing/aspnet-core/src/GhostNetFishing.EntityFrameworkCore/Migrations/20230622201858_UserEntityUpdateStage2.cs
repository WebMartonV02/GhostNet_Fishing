using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostNetFishing.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityUpdateStage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonTypeId",
                table: "AbpUsers",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonTypeId",
                table: "AbpUsers");
        }
    }
}
