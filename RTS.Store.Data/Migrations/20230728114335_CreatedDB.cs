using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTS.Store.Web.Data.Migrations
{
    public partial class CreatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCards_AspNetUsers_UserId1",
                table: "ShopingCards");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCards_UserId1",
                table: "ShopingCards");

            migrationBuilder.DropIndex(
                name: "IX_Products_BuyerId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShopingCards");

            migrationBuilder.DropColumn(
                name: "BuyerId1",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShopingCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd4378e-9261-4ee1-959a-b817735a7cbf", "AQAAAAEAACcQAAAAEJa82KpzJAZiOtMC5GXw5IlyaZzEwwTDS/XxaO8CHylXBQ7ust63ZtO2x/DTkS1BUA==", "be8332a4-ec41-4eeb-afd1-d39df55ca05b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c70c8a8b-1ad2-43fa-852a-e9b58a96a7ff", "AQAAAAEAACcQAAAAEPQ+lAD/+bTbJF6G4vBlcaio6w8a92wBOGFj6VYU5hn8xkXLBqGdYevkppjrohsZhA==", "68ca469a-73a8-4858-852d-3f61123dea65" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCards_UserId",
                table: "ShopingCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerId",
                table: "Products",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCards_AspNetUsers_UserId",
                table: "ShopingCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCards_AspNetUsers_UserId",
                table: "ShopingCards");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCards_UserId",
                table: "ShopingCards");

            migrationBuilder.DropIndex(
                name: "IX_Products_BuyerId",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ShopingCards",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ShopingCards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerId1",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5573b98b-c813-4733-a142-cf87d21d548e", "AQAAAAEAACcQAAAAEDgu+oJyQGXTMdk4UNg1inY3xjP6i4P+DvFRosdvNt29X2pWH6W9ob29B7cHEt+vIQ==", "e5b8eceb-1755-4f18-90a9-3508b89eb872" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "708a4d61-8eba-480f-9bf1-65b8f68725a4", "AQAAAAEAACcQAAAAECrB9Lia85CkpqNLJ99+LouIhTkQFkraxD4Dmq6UQF6iFrSGqrMqUVa+Wp/zZCpwfw==", "1c2d85ba-2003-47ad-98cd-3e11fa8e8411" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCards_UserId1",
                table: "ShopingCards",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerId1",
                table: "Products",
                column: "BuyerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId1",
                table: "Products",
                column: "BuyerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCards_AspNetUsers_UserId1",
                table: "ShopingCards",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
