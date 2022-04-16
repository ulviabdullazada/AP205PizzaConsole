using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaMizza.Migrations
{
    public partial class CreatedPizzaSizePricesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaSizePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaSizePrices_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaSizePrices_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSizePrices_PizzaId",
                table: "PizzaSizePrices",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSizePrices_SizeId",
                table: "PizzaSizePrices",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaSizePrices");
        }
    }
}
