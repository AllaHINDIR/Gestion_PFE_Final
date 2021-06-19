using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class migrationOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Demande_EtudiantID",
                table: "Demande");

            migrationBuilder.CreateIndex(
                name: "IX_Demande_EtudiantID",
                table: "Demande",
                column: "EtudiantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Demande_EtudiantID",
                table: "Demande");

            migrationBuilder.CreateIndex(
                name: "IX_Demande_EtudiantID",
                table: "Demande",
                column: "EtudiantID",
                unique: true);
        }
    }
}
