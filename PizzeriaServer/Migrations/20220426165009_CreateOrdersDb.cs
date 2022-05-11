using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaServer.Migrations
{
    public partial class CreateOrdersDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PizzaOrderLineId",
                table: "Toppings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    IsDone = table.Column<ulong>(type: "bit(1)", nullable: false, defaultValue: 0ul),
                    UserNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    PizzaId = table.Column<long>(type: "bigint", nullable: false),
                    CrustId = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    SizeId = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineId);
                    table.ForeignKey(
                        name: "FK_OrderLines_Meals_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_PizzaCrust_CrustId",
                        column: x => x.CrustId,
                        principalTable: "PizzaCrust",
                        principalColumn: "CrustId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_PizzaSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "PizzaSize",
                        principalColumn: "PizzaSizeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaOrderLineId",
                table: "Toppings",
                column: "PizzaOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_CrustId",
                table: "OrderLines",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PizzaId",
                table: "OrderLines",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_SizeId",
                table: "OrderLines",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_OrderLines_PizzaOrderLineId",
                table: "Toppings",
                column: "PizzaOrderLineId",
                principalTable: "OrderLines",
                principalColumn: "OrderLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_OrderLines_PizzaOrderLineId",
                table: "Toppings");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_PizzaOrderLineId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "PizzaOrderLineId",
                table: "Toppings");
        }
    }
}
