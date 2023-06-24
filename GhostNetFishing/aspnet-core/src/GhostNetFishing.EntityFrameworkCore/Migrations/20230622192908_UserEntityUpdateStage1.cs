using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostNetFishing.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityUpdateStage1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelefonNumber",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefonNumber",
                table: "AbpUsers");
        }
    }
}
