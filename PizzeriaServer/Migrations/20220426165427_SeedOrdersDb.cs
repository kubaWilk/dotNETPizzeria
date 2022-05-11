using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaServer.Migrations
{
    public partial class SeedOrdersDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "UserNotes" },
                values: new object[] { 1L, null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "UserNotes" },
                values: new object[] { 2L, null });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "OrderLineId", "OrderId", "PizzaId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 2L },
                    { 3L, 1L, 3L },
                    { 4L, 2L, 4L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "OrderLineId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "OrderLineId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "OrderLineId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "OrderLineId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2L);
        }
    }
}
