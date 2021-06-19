using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encadrant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encadrant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameProjet = table.Column<string>(nullable: true),
                    theme = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    EncadrantID = table.Column<int>(nullable: true),
                    EtudiantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projet_Encadrant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Encadrant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projet_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projet_EncadrantID",
                table: "Projet",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_EtudiantID",
                table: "Projet",
                column: "EtudiantID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "Encadrant");

            migrationBuilder.DropTable(
                name: "Etudiant");
        }
    }
}
