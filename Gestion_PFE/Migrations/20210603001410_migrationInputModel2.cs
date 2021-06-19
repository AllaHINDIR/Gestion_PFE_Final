using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class migrationInputModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Etudiant",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Etudiant",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Etudiant");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Etudiant");
        }
    }
}
