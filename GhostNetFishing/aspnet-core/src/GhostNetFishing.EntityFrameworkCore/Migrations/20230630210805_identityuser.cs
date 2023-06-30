using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostNetFishing.Migrations
{
    /// <inheritdoc />
    public partial class identityuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppGhostNetAndPerson_AppPerson_PersonId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPerson_AppPersonType_PersonTypeId",
                table: "AppPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPersonType",
                table: "AppPersonType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPerson",
                table: "AppPerson");

            migrationBuilder.RenameTable(
                name: "AppPersonType",
                newName: "PersonTypes");

            migrationBuilder.RenameTable(
                name: "AppPerson",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_AppPerson_PersonTypeId",
                table: "Persons",
                newName: "IX_Persons_PersonTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "AppGhostNetAndPerson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppGhostNetAndPerson",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonTypes",
                table: "PersonTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppGhostNetAndPerson_UserId",
                table: "AppGhostNetAndPerson",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppGhostNetAndPerson_AbpUsers_UserId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AppGhostNetAndPerson_Persons_PersonId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_AppGhostNetAndPerson_UserId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonTypes",
                table: "PersonTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppGhostNetAndPerson");

            migrationBuilder.RenameTable(
                name: "PersonTypes",
                newName: "AppPersonType");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "AppPerson");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PersonTypeId",
                table: "AppPerson",
                newName: "IX_AppPerson_PersonTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "AppGhostNetAndPerson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPersonType",
                table: "AppPersonType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPerson",
                table: "AppPerson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppGhostNetAndPerson_AppPerson_PersonId",
                table: "AppGhostNetAndPerson",
                column: "PersonId",
                principalTable: "AppPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPerson_AppPersonType_PersonTypeId",
                table: "AppPerson",
                column: "PersonTypeId",
                principalTable: "AppPersonType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
