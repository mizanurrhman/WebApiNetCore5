using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiNetCore5.Migrations
{
    public partial class addDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86eda0b-61ea-46b7-9338-d66956bcb523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8a66276-c677-4a63-beeb-d691347bacca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "072ae74d-33a4-4717-b06d-f3dbaac21da9", "d212a917-ea65-4b18-9d18-49f44d20e3e2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58d8cce3-53dc-41d6-a8fa-a60560070d2c", "2cd737b6-30cf-4707-88a0-3a76a4d39989", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "072ae74d-33a4-4717-b06d-f3dbaac21da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58d8cce3-53dc-41d6-a8fa-a60560070d2c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c86eda0b-61ea-46b7-9338-d66956bcb523", "9dc48a8a-352c-4f06-9481-49bbd08afb13", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8a66276-c677-4a63-beeb-d691347bacca", "d5e33ed9-cc21-49c3-93c6-3184d39633df", "Administrator", "ADMINISTRATOR" });
        }
    }
}
