using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTS.Store.Web.Data.Migrations
{
    public partial class CreateDBB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "Бай");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Иван");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfCard = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopingCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopingCards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopingCards_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuantityInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShopingCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ShopingCards_ShopingCardId",
                        column: x => x.ShopingCardId,
                        principalTable: "ShopingCards",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c11c7aa-d85a-462a-931e-adcc203d21f4", 0, null, "7205025f-2646-40a9-a11a-851ee9ff00c2", "yavorSeller@abv.bg", false, false, null, "YAVORSELLER@ABV.BG", "YAVORSELLER@ABV.BG", "AQAAAAEAACcQAAAAEC/OBYyaBnBNvWziIuKDnE/HhZAB/DOGC6j8ZQmAv/PkcypjMYYIFv/03Gt+M81wPg==", null, false, "1fbae9e0-944e-4e1f-90b7-1301ef60d5e5", false, "yavorSeller@abv.bg" },
                    { "ddcb42c8-a394-45cd-82ae-b1e71d5c693e", 0, null, "df0df705-a18d-49b5-8138-dc455f5efebb", "rosenSeller@abv.bg", false, false, null, "ROSENSELLER@ABV.BG", "ROSENSELLER@ABV.BG", "AQAAAAEAACcQAAAAEBguR4wikd39lPPgjmKzfjEMBl1jbyBM3CQJMip3Uywv/5WY8MSucTgr26LOMag0Rg==", null, false, "540c07e2-8148-46da-a844-45089488663e", false, "rosenSeller@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Food" },
                    { 3, "For home" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("7b427f6a-a62a-44c5-948f-6d78f524cebe"), "0899495555", "3c11c7aa-d85a-462a-931e-adcc203d21f4" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7"), "0897556677", "ddcb42c8-a394-45cd-82ae-b1e71d5c693e" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "IsActive", "Name", "Price", "QuantityInStock", "SellerId", "ShopingCardId" },
                values: new object[] { new Guid("47355a7a-89a1-47b9-b5c5-35329a297a48"), null, 3, "Дивана е дълъг 245 см., лежанката е 175 см.", "https://ivveks.com/wp-content/uploads/2021/09/bri-1-scaled.jpg", true, "Диван", 2000.00m, 1m, new Guid("7b427f6a-a62a-44c5-948f-6d78f524cebe"), null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "IsActive", "Name", "Price", "QuantityInStock", "SellerId", "ShopingCardId" },
                values: new object[] { new Guid("5211c8cd-bc4c-41c6-aa72-bca634315dc9"), null, 2, "Прасето е от породата Landrace и е 150 кг.Цена за килограм е 10 лв..", "https://encrypted-tbn0.gstatic.com/images?//=tbn:ANd9GcTQIRWQanNZMfTV3IsSgZpNuq6VulEr0cP1iQ&usqp=CAU", true, "Прасе", 1500.00m, 5m, new Guid("7b427f6a-a62a-44c5-948f-6d78f524cebe"), null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "IsActive", "Name", "Price", "QuantityInStock", "SellerId", "ShopingCardId" },
                values: new object[] { new Guid("570c58a9-7d93-4b1b-a1e9-a778f94d9d06"), null, 1, "BMW 530d e39, 193к.с Година: 2002 , Цвят:Синя , Екстри:Подгрев на /редните/ седалки , Мултиволан, Темпомат, ", "https://encrypted-tbn0.gstatic.com/images?//=tbn:ANd9GcTqi0u80NkjoORAddgNXSmZM-2qx_vlwnaJbg&usqp=CAU", true, "BMW 530D", 10000.00m, 1m, new Guid("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7"), null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerId",
                table: "Products",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopingCardId",
                table: "Products",
                column: "ShopingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCards_PaymentId",
                table: "ShopingCards",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCards_UserId",
                table: "ShopingCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "ShopingCards");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
