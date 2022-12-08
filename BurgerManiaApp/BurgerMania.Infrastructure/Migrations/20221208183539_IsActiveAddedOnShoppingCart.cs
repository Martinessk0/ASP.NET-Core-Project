using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class IsActiveAddedOnShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc259eb5-de03-4f89-b1cd-8e959d3b715a", "AQAAAAEAACcQAAAAECbSN0L652D05UHczM+bS3jlIKrCvJE0ZFhA2TZg0hrKoEMqe/9t8l0NRhpuN+DASQ==", "ad0422ff-33c8-4b4a-88c7-43d86794e23b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "294c5634-f401-4705-bf0d-acd79f0f32ed", "AQAAAAEAACcQAAAAEHU1NAstdtoB+Zmyn7V76S6aGwBY9ZtrReaI6HOdtOjtxyXGV2eQm4hURawkcmaAKw==", "3b55a8e7-8d32-414a-8beb-dfd9aff812bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f07464ea-aef6-4e75-be54-053721f4e4a5", "AQAAAAEAACcQAAAAEAoDmlgZXY/kNgW5vlR8YimnRfeLHDMnKSg/KhBx6bRcbZbvkNyCufOBUkcn9b7BiQ==", "45966acd-048a-4585-9f4f-24dbb23253b3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 8, 20, 35, 39, 38, DateTimeKind.Local).AddTicks(209), new DateTime(2022, 12, 8, 20, 35, 39, 38, DateTimeKind.Local).AddTicks(246) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 8, 20, 35, 39, 38, DateTimeKind.Local).AddTicks(256), new DateTime(2022, 12, 8, 20, 35, 39, 38, DateTimeKind.Local).AddTicks(257) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 8, 20, 35, 39, 38, DateTimeKind.Local).AddTicks(260), new DateTime(2022, 12, 8, 20, 35, 39, 38, DateTimeKind.Local).AddTicks(262) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ec2b39e-4a46-4a09-913a-140faefaaa5f", "AQAAAAEAACcQAAAAEBhXn2aqCOM1cs17P9cUALk7s7AGKhx7T/JSb+JNqrOMchQ9viPJqaAwOhaiWkmq+g==", "9f31ba86-74c3-4579-8dac-f075f1085bad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58dee496-beee-4cab-b228-93df2988c3d8", "AQAAAAEAACcQAAAAEIMYuh6ObWQ92nsOBBhENVsc1NV2hYHeYJAF9Ixku1dhYT218PI9ADR5E1UCTQwr0A==", "0f40e620-2e13-4705-a384-5ca73efae228" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26de151e-74c3-43ed-9628-a7587363faef", "AQAAAAEAACcQAAAAEEEafEPCnRL4SN3KLnqkXGzh0nFkVnHpidBxVmY8neuTR3+ZL/nN9TE86D2s0mz7qw==", "f0a016cc-2df1-4995-9f74-200efdd218de" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 54, 36, 743, DateTimeKind.Local).AddTicks(5002), new DateTime(2022, 12, 7, 11, 54, 36, 743, DateTimeKind.Local).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 54, 36, 743, DateTimeKind.Local).AddTicks(5047), new DateTime(2022, 12, 7, 11, 54, 36, 743, DateTimeKind.Local).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 54, 36, 743, DateTimeKind.Local).AddTicks(5054), new DateTime(2022, 12, 7, 11, 54, 36, 743, DateTimeKind.Local).AddTicks(5056) });
        }
    }
}
