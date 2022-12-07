using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class DeliveryAdressTableWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryAddress_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryAddress",
                table: "DeliveryAddress");

            migrationBuilder.RenameTable(
                name: "DeliveryAddress",
                newName: "DeliveryAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryAddresses",
                table: "DeliveryAddresses",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryAddresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryAddresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryAddresses",
                table: "DeliveryAddresses");

            migrationBuilder.RenameTable(
                name: "DeliveryAddresses",
                newName: "DeliveryAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryAddress",
                table: "DeliveryAddress",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryAddress_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "DeliveryAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
