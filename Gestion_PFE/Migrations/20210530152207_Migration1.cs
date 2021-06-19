using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demande",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncadrantID = table.Column<int>(nullable: true),
                    EtudiantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demande", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Demande_Encadrant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Encadrant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Demande_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demande_EncadrantID",
                table: "Demande",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Demande_EtudiantId",
                table: "Demande",
                column: "EtudiantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demande");
        }
    }
}
