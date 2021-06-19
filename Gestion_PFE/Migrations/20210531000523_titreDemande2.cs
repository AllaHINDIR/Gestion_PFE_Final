using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class titreDemande2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demande_Etudiant_EtudiantId",
                table: "Demande");

            migrationBuilder.RenameColumn(
                name: "EtudiantId",
                table: "Demande",
                newName: "EtudiantID");

            migrationBuilder.RenameIndex(
                name: "IX_Demande_EtudiantId",
                table: "Demande",
                newName: "IX_Demande_EtudiantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Demande_Etudiant_EtudiantID",
                table: "Demande",
                column: "EtudiantID",
                principalTable: "Etudiant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demande_Etudiant_EtudiantID",
                table: "Demande");

            migrationBuilder.RenameColumn(
                name: "EtudiantID",
                table: "Demande",
                newName: "EtudiantId");

            migrationBuilder.RenameIndex(
                name: "IX_Demande_EtudiantID",
                table: "Demande",
                newName: "IX_Demande_EtudiantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demande_Etudiant_EtudiantId",
                table: "Demande",
                column: "EtudiantId",
                principalTable: "Etudiant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
