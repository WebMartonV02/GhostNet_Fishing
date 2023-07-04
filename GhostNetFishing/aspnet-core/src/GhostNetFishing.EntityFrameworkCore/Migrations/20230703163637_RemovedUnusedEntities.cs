using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostNetFishing.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnusedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppGhostNetAndPerson_AbpUsers_UserId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AppGhostNetAndPerson_Persons_PersonId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropIndex(
                name: "IX_AppGhostNetAndPerson_PersonId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropIndex(
                name: "IX_AppGhostNetAndPerson_UserId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "AppGhostNetAndPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "AppGhostNetAndPerson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppGhostNetAndPerson_PersonId",
                table: "AppGhostNetAndPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AppGhostNetAndPerson_UserId",
                table: "AppGhostNetAndPerson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppGhostNetAndPerson_AbpUsers_UserId",
                table: "AppGhostNetAndPerson",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppGhostNetAndPerson_Persons_PersonId",
                table: "AppGhostNetAndPerson",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
