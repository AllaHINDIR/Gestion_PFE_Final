using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class migrationEncadarntID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projet_Encadrant_EncadrantID",
                table: "Projet");

            migrationBuilder.AlterColumn<int>(
                name: "EncadrantID",
                table: "Projet",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projet_Encadrant_EncadrantID",
                table: "Projet",
                column: "EncadrantID",
                principalTable: "Encadrant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projet_Encadrant_EncadrantID",
                table: "Projet");

            migrationBuilder.AlterColumn<int>(
                name: "EncadrantID",
                table: "Projet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Projet_Encadrant_EncadrantID",
                table: "Projet",
                column: "EncadrantID",
                principalTable: "Encadrant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
