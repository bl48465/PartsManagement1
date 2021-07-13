using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class initialSosht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a3dc22-c932-4257-b70d-999d363939dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f691f3e3-b87b-4923-be87-4503d4d8f8d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa8f9d96-d0c6-459e-be11-6c2a8b0ae977");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcb1324e-598e-457c-bcb1-ed515994c63f", "d24ade35-b1a2-47cd-8047-f24d42442386", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6029a3a-c480-4842-9202-92ea262c4475", "7111e6ad-7ec9-431c-aa9e-19c624b8df18", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba4fec8c-1384-4289-9702-8b9853f9a875", "5c4922df-199b-4f3e-8233-0a56c2a8779a", "Puntor", "PUNTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba4fec8c-1384-4289-9702-8b9853f9a875");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcb1324e-598e-457c-bcb1-ed515994c63f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6029a3a-c480-4842-9202-92ea262c4475");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa8f9d96-d0c6-459e-be11-6c2a8b0ae977", "b869f331-dd72-48e1-adfb-0fedd8f560c1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03a3dc22-c932-4257-b70d-999d363939dd", "14fc1472-e02c-4b0c-bf4e-ea2d31c76de3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f691f3e3-b87b-4923-be87-4503d4d8f8d0", "8ee53348-4032-4fa4-9099-d2af6497220d", "Puntor", "PUNTOR" });
        }
    }
}
