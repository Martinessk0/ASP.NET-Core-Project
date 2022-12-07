using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class DbRelSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "CartItems",
                newName: "ImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4ebbd62-075e-49ee-b5ed-5e994bf74811", "AQAAAAEAACcQAAAAEMi9QOuON92T0v+TTi6alYFrf3dfVBIWk3EoUT5FBazn8otymRlc8OGLARlM7DbWwQ==", "fe401208-91b9-43a2-97c3-71680c3b04a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a60e8130-453b-40d1-92a5-2e5fbf5cbf38", "AQAAAAEAACcQAAAAELgESIY+2RyxST8R4b+Y5/DmawiP1ePV+hTcOJogjGGJxD5g3io7lZHEbi/siWdYLQ==", "1aa7e2db-f1b1-4034-b469-c4b7a355b49e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afbedd99-529c-4f7f-95ee-ef516521c3fc", "AQAAAAEAACcQAAAAEKTa77Fs6XQq3UYQFpnz5jMCguNmwTkus9xhDHvO3uhgXc/zlWrISuWHkAXDcZ7xVg==", "a3962bad-191d-4f40-87a4-f811896b90b9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 18, 20, 421, DateTimeKind.Local).AddTicks(6477), new DateTime(2022, 12, 7, 11, 18, 20, 421, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 18, 20, 421, DateTimeKind.Local).AddTicks(6529), new DateTime(2022, 12, 7, 11, 18, 20, 421, DateTimeKind.Local).AddTicks(6531) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 18, 20, 421, DateTimeKind.Local).AddTicks(6534), new DateTime(2022, 12, 7, 11, 18, 20, 421, DateTimeKind.Local).AddTicks(6536) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_BuyerId",
                table: "ShoppingCarts",
                column: "BuyerId");

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
                name: "FK_CartItems_ShoppingCarts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_BuyerId",
                table: "ShoppingCarts",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCarts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_BuyerId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_BuyerId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "CartItems",
                newName: "PictureUrl");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_ShoppingCartId");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
