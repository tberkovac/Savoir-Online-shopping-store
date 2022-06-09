using Microsoft.EntityFrameworkCore.Migrations;

namespace SavoirApp.Migrations
{
    public partial class CetvrtaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredUserOrders");

            migrationBuilder.DropTable(
                name: "VIPUserOrders");

            migrationBuilder.AddColumn<string>(
                name: "IDUser",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IDUser",
                table: "Orders",
                column: "IDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IDUser",
                table: "Orders",
                column: "IDUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IDUser",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IDUser",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "RegisteredUserOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDOrder = table.Column<int>(type: "int", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUserOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegisteredUserOrders_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredUserOrders_Orders_IDOrder",
                        column: x => x.IDOrder,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VIPUserOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDOrder = table.Column<int>(type: "int", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPUserOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VIPUserOrders_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VIPUserOrders_Orders_IDOrder",
                        column: x => x.IDOrder,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUserOrders_IDOrder",
                table: "RegisteredUserOrders",
                column: "IDOrder");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUserOrders_IDUser",
                table: "RegisteredUserOrders",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_VIPUserOrders_IDOrder",
                table: "VIPUserOrders",
                column: "IDOrder");

            migrationBuilder.CreateIndex(
                name: "IX_VIPUserOrders_IDUser",
                table: "VIPUserOrders",
                column: "IDUser");
        }
    }
}
