using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaProjekt.Migrations
{
    public partial class CreateMealsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<int>(type: "int", nullable: true),
                    DoughThickness = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    MealId = table.Column<long>(type: "bigint", nullable: false),
                    ToppingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => new { x.MealId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "MealId", "BasePrice", "Category", "Discriminator", "DoughThickness", "ImageUrl", "Name", "Size" },
                values: new object[,]
                {
                    { 1L, 20.00m, 3, "Pizza", 0, null, "Margherita", 1 },
                    { 2L, 23.00m, 3, "Pizza", 0, null, "Capricciosa", 1 },
                    { 3L, 23.00m, 3, "Pizza", 0, null, "Japanelo", 1 },
                    { 4L, 24.00m, 3, "Pizza", 0, null, "Hawaii", 1 }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "BasePrice", "Name" },
                values: new object[,]
                {
                    { 1L, 2.00m, "Mozzarella" },
                    { 2L, 2.00m, "Ham" },
                    { 3L, 2.00m, "Japanelo" },
                    { 4L, 2.00m, "Pepperoni" },
                    { 5L, 2.00m, "Pineapple" }
                });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "MealId", "ToppingId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 2L, 2L },
                    { 3L, 1L },
                    { 3L, 4L },
                    { 3L, 5L },
                    { 4L, 1L },
                    { 4L, 3L },
                    { 4L, 5L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
