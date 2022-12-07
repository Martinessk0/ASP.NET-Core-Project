using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class ProductBrandRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductBrand",
                table: "CartItems");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductBrand",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56c72520-8efb-4271-b289-a30910cd7695", "AQAAAAEAACcQAAAAEJPKrIa6nKnQvuiL6wlrt2typxzgDpm826s9/EBpdPqqr8LhRI/pR3SPpcp9EnofNw==", "301a8088-33d2-4cce-b5bf-5033227344ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "174f28bb-abc0-4ab0-865e-3da7eb464752", "AQAAAAEAACcQAAAAEEqifx/xdj56nwDej2/ZTsPwGwWw7+bHpWLILrSIwF48q+oGJ9iYEZgEOZB7dOxCiQ==", "09e2eec4-91c9-4a85-9cdc-dd3b433147b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71c3785f-4390-4dd8-b542-aeb073d35914", "AQAAAAEAACcQAAAAEC5qVIlB9mhapZ/AaCMTDz8haB61v04zcizuqmNFVYhS5w7bMdkoR5ebM46EW4U/eQ==", "4de79cdb-c6d9-4385-ae5b-26b11179114b" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 20, 59, 841, DateTimeKind.Local).AddTicks(8405), new DateTime(2022, 12, 7, 11, 20, 59, 841, DateTimeKind.Local).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 20, 59, 841, DateTimeKind.Local).AddTicks(8449), new DateTime(2022, 12, 7, 11, 20, 59, 841, DateTimeKind.Local).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 12, 7, 11, 20, 59, 841, DateTimeKind.Local).AddTicks(8454), new DateTime(2022, 12, 7, 11, 20, 59, 841, DateTimeKind.Local).AddTicks(8456) });
        }
    }
}
