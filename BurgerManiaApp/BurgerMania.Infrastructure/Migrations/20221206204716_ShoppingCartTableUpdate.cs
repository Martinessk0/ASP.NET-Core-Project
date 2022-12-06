using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class ShoppingCartTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_CartItems_CartItemId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_CartItemId",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312fd6b1-a08a-402e-a8ba-2f7bd25b9a8b", "AQAAAAEAACcQAAAAECj5x5HPUwdbkeOCmD7BZ//smJ0fbfMZSTw4WF80+6KztBjgoyrkoFOpiczDCzC9rQ==", "03aa015c-1afc-41cf-a566-f1e97bfa083e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c688cd44-2834-4759-b17b-b52111464745", "AQAAAAEAACcQAAAAEBXfj5MNvUro64zVdE2r7Ofj4qaZWVaJqUFb5D4Iz05wVWjk+sYPPdvA6ZB7SeSGpg==", "cbfd5508-28b0-4ac0-87d6-961ae14ddce1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f9bf120c-fafd-48d1-a4c6-330f99ad8a67", 0, "DELIVERER Street 5", "ca324cfd-013f-4419-b128-5c154040845a", "deliverer@gmail.com", false, "Deliverer", "Delivrov", false, null, "DELIVERER@GMAIL.COM", "DELIVERER", "AQAAAAEAACcQAAAAECjCdG2+OkkW+uKSWuynGgIN96cFbcAQe3JgSWVXBxo8tVgG7bzI3UIRnVtGpQOgDg==", null, false, "378b7a9d-0391-4f45-9eac-3cca0200fced", false, "Deliverer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 6, 22, 47, 16, 11, DateTimeKind.Local).AddTicks(3822), new DateTime(2022, 12, 6, 22, 47, 16, 11, DateTimeKind.Local).AddTicks(3967) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 6, 22, 47, 16, 11, DateTimeKind.Local).AddTicks(3992), new DateTime(2022, 12, 6, 22, 47, 16, 11, DateTimeKind.Local).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 6, 22, 47, 16, 11, DateTimeKind.Local).AddTicks(4005), new DateTime(2022, 12, 6, 22, 47, 16, 11, DateTimeKind.Local).AddTicks(4007) });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartItemId",
                table: "CartItems",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCarts_CartItemId",
                table: "CartItems",
                column: "CartItemId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCarts_CartItemId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CartItemId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ca15590-5b36-448a-98f9-8a51044e765a", "AQAAAAEAACcQAAAAEPHm4XmCBqKuKgM0dugRcsLnYhA+W9okk/ugeDxscXrR3J0MWCaGM1iIpRPaj/dJ7g==", "3773421b-851f-4c4c-b575-c5d41b3cd823" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "488b2aef-2fb7-4c8a-b491-da0e8135761c", "AQAAAAEAACcQAAAAEON9G1UeovKa05OIQA9Ot7xOfduqhAY9f7sW3axYI856gV62lWTFSs0WleqFE/Vs0Q==", "ae558cea-14d6-44d0-a2bf-2b6acadb30ba" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 11, 30, 22, 50, 47, 16, DateTimeKind.Local).AddTicks(8751), new DateTime(2022, 11, 30, 22, 50, 47, 16, DateTimeKind.Local).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 11, 30, 22, 50, 47, 16, DateTimeKind.Local).AddTicks(8800), new DateTime(2022, 11, 30, 22, 50, 47, 16, DateTimeKind.Local).AddTicks(8802) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 11, 30, 22, 50, 47, 16, DateTimeKind.Local).AddTicks(8805), new DateTime(2022, 11, 30, 22, 50, 47, 16, DateTimeKind.Local).AddTicks(8807) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CartItemId",
                table: "ShoppingCarts",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_CartItems_CartItemId",
                table: "ShoppingCarts",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
