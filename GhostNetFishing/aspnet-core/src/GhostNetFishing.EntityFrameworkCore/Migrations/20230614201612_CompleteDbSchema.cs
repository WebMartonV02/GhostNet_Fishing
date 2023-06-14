using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostNetFishing.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppGhostNetStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGhostNetStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPersonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPersonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppGhostNet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Standort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhostNetStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGhostNet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGhostNet_AppGhostNetStatus_GhostNetStatusId",
                        column: x => x.GhostNetStatusId,
                        principalTable: "AppGhostNetStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPerson_AppPersonType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "AppPersonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppGhostNetAndPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhostNetId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGhostNetAndPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGhostNetAndPerson_AppGhostNet_GhostNetId",
                        column: x => x.GhostNetId,
                        principalTable: "AppGhostNet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppGhostNetAndPerson_AppPerson_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AppPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppGhostNet_GhostNetStatusId",
                table: "AppGhostNet",
                column: "GhostNetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppGhostNetAndPerson_GhostNetId",
                table: "AppGhostNetAndPerson",
                column: "GhostNetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppGhostNetAndPerson_PersonId",
                table: "AppGhostNetAndPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPerson_PersonTypeId",
                table: "AppPerson",
                column: "PersonTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppGhostNetAndPerson");

            migrationBuilder.DropTable(
                name: "AppGhostNet");

            migrationBuilder.DropTable(
                name: "AppPerson");

            migrationBuilder.DropTable(
                name: "AppGhostNetStatus");

            migrationBuilder.DropTable(
                name: "AppPersonType");
        }
    }
}
