using Microsoft.EntityFrameworkCore.Migrations;

namespace SavoirApp.Migrations
{
    public partial class TrecaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika",
                table: "VIPUserOrders");

            migrationBuilder.AddColumn<string>(
                name: "slika",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "slika",
                table: "VIPUserOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
