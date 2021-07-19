using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiNetCore5.Migrations
{
    public partial class addedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c86eda0b-61ea-46b7-9338-d66956bcb523", "9dc48a8a-352c-4f06-9481-49bbd08afb13", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8a66276-c677-4a63-beeb-d691347bacca", "d5e33ed9-cc21-49c3-93c6-3184d39633df", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86eda0b-61ea-46b7-9338-d66956bcb523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8a66276-c677-4a63-beeb-d691347bacca");
        }
    }
}
