using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class UserCategoryOrderStatusSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderStatuses");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06552aa5-bcbe-49ef-ac65-fd84699d0d3e", 0, "Guest Street 3", "48942768-2647-4194-8080-5f1a42f2a011", "guest@gmail.com", false, "Guest", "Guestov", false, null, "guest@gmail.com", "guest", "AQAAAAEAACcQAAAAEPBnc5UbFO7sH05wjnbeenEWqHc2p7APwQ8Wb/cc0a7ktuOkH05sCdthNqqkiWi1MQ==", null, false, "1c3b45a1-c6ae-442f-8abf-f4b2cc7c9973", false, "Guest" },
                    { "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 0, "Admin Street 6", "36710fac-7d8d-4c70-9f9e-0b3c20556dc0", "admin@gmail.com", false, "Admin", "Adminov", false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEMIgGfced5BnZb8WxHA8lAfih4+mbk7EEq/hKp3BKRFQOn4nTThna0KhoANtnZCXAQ==", null, false, "5dff8cba-85b3-4f4a-a932-47f5bf3e61ac", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Burger" },
                    { 2, "Drink" },
                    { 3, "Fries" },
                    { 4, "Salad" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 3, "Completed" },
                    { 4, "Canceled" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
