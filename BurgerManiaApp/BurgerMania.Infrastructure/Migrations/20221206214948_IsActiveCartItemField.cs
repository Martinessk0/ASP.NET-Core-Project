using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class IsActiveCartItemField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312fd6b1-a08a-402e-a8ba-2f7bd25b9a8b", "AQAAAAEAACcQAAAAECj5x5HPUwdbkeOCmD7BZ//smJ0fbfMZSTw4WF80+6KztBjgoyrkoFOpiczDCzC9rQ==", "03aa015c-1afc-41cf-a566-f1e97bfa083e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca324cfd-013f-4419-b128-5c154040845a", "AQAAAAEAACcQAAAAECjCdG2+OkkW+uKSWuynGgIN96cFbcAQe3JgSWVXBxo8tVgG7bzI3UIRnVtGpQOgDg==", "378b7a9d-0391-4f45-9eac-3cca0200fced" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c688cd44-2834-4759-b17b-b52111464745", "AQAAAAEAACcQAAAAEBXfj5MNvUro64zVdE2r7Ofj4qaZWVaJqUFb5D4Iz05wVWjk+sYPPdvA6ZB7SeSGpg==", "cbfd5508-28b0-4ac0-87d6-961ae14ddce1" });

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
        }
    }
}
