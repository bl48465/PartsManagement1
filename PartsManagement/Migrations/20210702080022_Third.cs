using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64260b39-67f3-4f1c-a0ae-54cbe014d840");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf1e1f55-4f95-41d5-a7ed-ed6134390907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd31816a-dce6-48d6-b4a6-28b766876606");

            migrationBuilder.DropColumn(
                name: "ShitjaId",
                table: "FaturatOUT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b39c3ac5-a875-4b00-a713-2f1866c98789", "a97ede1b-eee1-4754-a5ce-1fb616d5d4d8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7199846-474c-4409-8cdc-84ff75f1fbf6", "02681209-49f7-4e74-be68-57305a022f39", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efcaa32d-09e7-4f1b-bebb-51648724249a", "33d94854-f08b-46ea-8981-f725c5f79851", "Puntor", "PUNTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b39c3ac5-a875-4b00-a713-2f1866c98789");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7199846-474c-4409-8cdc-84ff75f1fbf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efcaa32d-09e7-4f1b-bebb-51648724249a");

            migrationBuilder.AddColumn<int>(
                name: "ShitjaId",
                table: "FaturatOUT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd31816a-dce6-48d6-b4a6-28b766876606", "48ab7587-b471-44af-8fb6-a191e248cb11", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf1e1f55-4f95-41d5-a7ed-ed6134390907", "a6f1a3d6-3d57-4065-8d44-7e372db301d8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64260b39-67f3-4f1c-a0ae-54cbe014d840", "094aaa5d-5f4b-4ebd-bd27-5eb07f2ef950", "Puntor", "PUNTOR" });
        }
    }
}
