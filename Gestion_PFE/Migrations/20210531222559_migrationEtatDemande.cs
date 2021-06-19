using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class migrationEtatDemande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "etat",
                table: "Demande",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "etat",
                table: "Demande");
        }
    }
}
