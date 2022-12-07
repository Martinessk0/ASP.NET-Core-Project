using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class shoppingCartChanched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCarts_CartItemId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "CartItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartItemId",
                table: "CartItems",
                newName: "IX_CartItems_OrderId");

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OrderDate",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductBrand",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a04e60-d296-48b0-8a94-f92eed3eac9b", "AQAAAAEAACcQAAAAEDp9+QF4MuggRmq8smtbeWX4Z4rpmUTnIO7Ng4rqqS4r89H1kxdG++cVE5NZcRjuNA==", "1cb2971c-2dbb-4f5d-8f6d-37f294ada9d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a32ba02d-8c58-4a17-8399-08a0f47e78fb", "AQAAAAEAACcQAAAAELXdwjp7zlflg2WInGeXqnDnbcal6wFYKNBnVQI7Z3axTfJp3l4yo6RjJIdZ7MDq9w==", "9c808743-dfa0-40c6-b95f-07c802b5e57a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e52f5265-d9c1-4903-81c6-8fdf545b1557", "AQAAAAEAACcQAAAAEBibzqjVuiQJigNihmCM1pUJXb2AwRfJIxu/H1w82QpXJhbc/aaO+cBMseDgnC6D1w==", "1cfbf056-ebb5-4afc-bf8b-b993d3a0440d" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 12, 29, 403, DateTimeKind.Local).AddTicks(7350), new DateTime(2022, 12, 7, 11, 12, 29, 403, DateTimeKind.Local).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 12, 29, 403, DateTimeKind.Local).AddTicks(7403), new DateTime(2022, 12, 7, 11, 12, 29, 403, DateTimeKind.Local).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 12, 29, 403, DateTimeKind.Local).AddTicks(7408), new DateTime(2022, 12, 7, 11, 12, 29, 403, DateTimeKind.Local).AddTicks(7410) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Orders_OrderId",
                table: "CartItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryAddress_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Orders_OrderId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryAddress_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductBrand",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CartItems",
                newName: "CartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                newName: "IX_CartItems_CartItemId");

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c523617-3af1-48f7-bf90-9c6eef348018", "AQAAAAEAACcQAAAAEN479ZxRT+uvl1NeskcdIweN7oaJ9YGw1N6eQAtO8zdqJxwm3o/vepP091TELEMK2A==", "2974970b-5e0d-4919-8122-e33e6dde9747" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8de561e-2673-4d4e-b199-ae26feba8feb", "AQAAAAEAACcQAAAAEHjCS+VHPeCFN1qeVWxkufguK6CdTfh9SwZ8hPjJnUUgGnnGWt10vzuzBi7a6dCBCg==", "bce530a7-eb30-4640-84c8-af50163d45c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d51cc36-d5fe-4d65-9d7c-9b596b65614d", "AQAAAAEAACcQAAAAEGKSGOn/B7eu1ToxbTEkGVAzKP/N2AFuVnUKSNhk/nHsZ05gz4yYcfx1UGDWOnTk+A==", "51164585-8d54-4e16-b95c-311257842c5b" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 6, 23, 49, 48, 527, DateTimeKind.Local).AddTicks(3256), new DateTime(2022, 12, 6, 23, 49, 48, 527, DateTimeKind.Local).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 6, 23, 49, 48, 527, DateTimeKind.Local).AddTicks(3303), new DateTime(2022, 12, 6, 23, 49, 48, 527, DateTimeKind.Local).AddTicks(3305) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 6, 23, 49, 48, 527, DateTimeKind.Local).AddTicks(3308), new DateTime(2022, 12, 6, 23, 49, 48, 527, DateTimeKind.Local).AddTicks(3310) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCarts_CartItemId",
                table: "CartItems",
                column: "CartItemId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
