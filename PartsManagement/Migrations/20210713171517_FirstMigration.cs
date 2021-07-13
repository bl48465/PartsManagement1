using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a90c24c-85ab-4649-9667-af4d47ab8a8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e274982-07ba-4067-9787-4c07466157c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82f0ceba-19c8-4871-83df-40c117e94a64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d6dc590-e6ef-49e1-9a62-3748c0f0f957", "77cf9dd7-6696-4007-bee1-090da92d1c20", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac6cc60a-9f60-4e05-a2bc-716547d4895c", "9a081ce9-fe1b-45ca-bc6f-43956cb67e82", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d2181f6-bb7b-415e-8b41-2e90f0f6b37e", "714b410a-00ee-48e9-9525-0df66b2c7f97", "Puntor", "PUNTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d2181f6-bb7b-415e-8b41-2e90f0f6b37e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6dc590-e6ef-49e1-9a62-3748c0f0f957");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac6cc60a-9f60-4e05-a2bc-716547d4895c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e274982-07ba-4067-9787-4c07466157c6", "5c7246ae-6a17-46c2-8646-0ac105e11d9b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a90c24c-85ab-4649-9667-af4d47ab8a8c", "c8391097-2481-4b19-b521-f07961f0a05a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82f0ceba-19c8-4871-83df-40c117e94a64", "803e145f-8354-472b-bcda-01f8caff004c", "Puntor", "PUNTOR" });
        }
    }
}
