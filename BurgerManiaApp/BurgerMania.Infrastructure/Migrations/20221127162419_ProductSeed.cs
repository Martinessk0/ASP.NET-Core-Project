using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerManiaApp.Infractructure.Migrations
{
    public partial class ProductSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcc4a3e7-1814-4528-b58f-545d7da42c3f", "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEEytNs6p8B8vPaGuhYinqAD/hQVjY/qiVkq1daol0dfYtsRrNnYxrzPTQgFsr0KgEQ==", "ac93785f-0c10-4b6e-90d5-247832427abf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ace8aa4a-dcb0-427f-b6c1-b63282a53658", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEMGSDSxKARfEFtCWXugIsoWRlrbPrVFjZD4Fxl5Dm7JtSg0WDPIlaJ/z5J+AgsMpjg==", "e78cdafe-e721-4bd1-8808-9dace38eab11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48942768-2647-4194-8080-5f1a42f2a011", "guest@gmail.com", "guest", "AQAAAAEAACcQAAAAEPBnc5UbFO7sH05wjnbeenEWqHc2p7APwQ8Wb/cc0a7ktuOkH05sCdthNqqkiWi1MQ==", "1c3b45a1-c6ae-442f-8abf-f4b2cc7c9973" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36710fac-7d8d-4c70-9f9e-0b3c20556dc0", "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEMIgGfced5BnZb8WxHA8lAfih4+mbk7EEq/hKp3BKRFQOn4nTThna0KhoANtnZCXAQ==", "5dff8cba-85b3-4f4a-a932-47f5bf3e61ac" });
        }
    }
}
