using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTS.Store.Web.Data.Migrations
{
    public partial class AddPOtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShopingCards_ShopingCardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopingCardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "ShopingCards");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShopingCards");

            migrationBuilder.DropColumn(
                name: "ShopingCardId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopingCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ShopingCards_ShopingCardId",
                        column: x => x.ShopingCardId,
                        principalTable: "ShopingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55dcdaaa-3c86-4651-94ca-c14e2feba023", "AQAAAAEAACcQAAAAEIhqwMn92m6lpmGV2S6DPb5YAqx3JnSncFuJVeGTn7E6BtUB8jArissAmTLIIhdL3Q==", "13843f39-67a2-451f-868e-d83c911067a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7205df59-2fc7-4f85-98b3-0df56e213bb2", "AQAAAAEAACcQAAAAEPQLf1lR/4odvbZm1Q4Z8/VZv4rjCsy9HvRlcX3rdaG7glxaYa2bPbL4g4n8gO/70Q==", "8925c8b8-2d38-4c3f-b7c4-4a2f5f716047" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopingCardId",
                table: "Orders",
                column: "ShopingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "ShopingCards",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ShopingCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShopingCardId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aca1be1-5bfa-4aa5-9d3c-8ba279f55a57", "AQAAAAEAACcQAAAAEAFLjiQh1tck6+SU+mTcjZbL4CLNKDiN5m0Vu5xstZrNA1SvUbq/Ks9ObpLs7Qw0Cg==", "35f3952c-44a7-4930-8fbf-502f0a7361e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77b4e520-1b22-40fc-82a1-3ce28b7f4395", "AQAAAAEAACcQAAAAEO9JjpWqGvy1WheTLUaenE560sx4yw+by6u7+1SCm1FaL4bC+GvUakf+bsa/n2XEdg==", "706b91ff-605f-45aa-b23d-eedc7922e099" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopingCardId",
                table: "Products",
                column: "ShopingCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShopingCards_ShopingCardId",
                table: "Products",
                column: "ShopingCardId",
                principalTable: "ShopingCards",
                principalColumn: "Id");
        }
    }
}
