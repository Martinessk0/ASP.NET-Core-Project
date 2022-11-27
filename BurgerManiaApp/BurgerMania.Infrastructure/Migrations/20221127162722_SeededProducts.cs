using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class SeededProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82bdd7a0-c83e-4de0-82a4-cdf714975e0b", "AQAAAAEAACcQAAAAEA6jyBR4IdsON32ujHIR09jyJIur2i0k40r5sdBoT8sCTbwY2hsebpTy34J4/zFv2Q==", "086c115d-b24f-44a1-9b37-d25d43f92ada" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1724f7ed-8bd8-4908-a8e0-7c240b65cc97", "AQAAAAEAACcQAAAAEMz49qo/AsQ5iNdbIYnd9j5E3wSAO2WqzPKmFwQNzAdR/8UI5lm/1R/Z9+guqpeVSw==", "c715d2b9-fc62-41a2-9cfa-ce762e92d2e6" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "ModifiedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 27, 18, 27, 22, 184, DateTimeKind.Local).AddTicks(99), "Spicy Burger", "https://wickedkitchen.com/wp-content/uploads/2022/05/Wicked-jalapeno-burger.jpeg", true, new DateTime(2022, 11, 27, 18, 27, 22, 184, DateTimeKind.Local).AddTicks(135), "Spicy Burger", 7m },
                    { 2, 2, new DateTime(2022, 11, 27, 18, 27, 22, 184, DateTimeKind.Local).AddTicks(144), "Coca-Cola", "https://cdncloudcart.com/16372/products/images/68308/coca-cola-bezalkoholna-napitka-ken-250-ml-image_629659e5b307d_1920x1920.jpeg?1654020601", true, new DateTime(2022, 11, 27, 18, 27, 22, 184, DateTimeKind.Local).AddTicks(145), "Coca-Cola", 1m },
                    { 3, 4, new DateTime(2022, 11, 27, 18, 27, 22, 184, DateTimeKind.Local).AddTicks(150), "Salad with Iceberg lettuce", "https://eatsomethingvegan.com/wp-content/uploads/2021/11/Iceberg-Lettuce-Salad-5-681x1024.jpg", true, new DateTime(2022, 11, 27, 18, 27, 22, 184, DateTimeKind.Local).AddTicks(151), "Salad with Iceberg lettuce", 7m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcc4a3e7-1814-4528-b58f-545d7da42c3f", "AQAAAAEAACcQAAAAEEytNs6p8B8vPaGuhYinqAD/hQVjY/qiVkq1daol0dfYtsRrNnYxrzPTQgFsr0KgEQ==", "ac93785f-0c10-4b6e-90d5-247832427abf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ace8aa4a-dcb0-427f-b6c1-b63282a53658", "AQAAAAEAACcQAAAAEMGSDSxKARfEFtCWXugIsoWRlrbPrVFjZD4Fxl5Dm7JtSg0WDPIlaJ/z5J+AgsMpjg==", "e78cdafe-e721-4bd1-8808-9dace38eab11" });
        }
    }
}
