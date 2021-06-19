using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_PFE.Migrations
{
    public partial class migrationEncadrantEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Encadrant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Encadrant");
        }
    }
}
