using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class migrationAnnotation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demande_Encadrant_EncadrantID",
                table: "Demande");

            migrationBuilder.AlterColumn<int>(
                name: "EncadrantID",
                table: "Demande",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Demande_Encadrant_EncadrantID",
                table: "Demande",
                column: "EncadrantID",
                principalTable: "Encadrant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demande_Encadrant_EncadrantID",
                table: "Demande");

            migrationBuilder.AlterColumn<int>(
                name: "EncadrantID",
                table: "Demande",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Demande_Encadrant_EncadrantID",
                table: "Demande",
                column: "EncadrantID",
                principalTable: "Encadrant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
