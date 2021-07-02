using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturatOUT_Shitjet_ShitjaId",
                table: "FaturatOUT");

            migrationBuilder.DropIndex(
                name: "IX_FaturatOUT_ShitjaId",
                table: "FaturatOUT");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cb8bf8c-3639-4e5c-ae7e-180a5360f33a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c051226-3bbf-4032-8919-24311c87290e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df606594-ecd7-44c3-bf33-edbb8dd5f867");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FaturatOUT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_FaturatOUT_UserId",
                table: "FaturatOUT",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturatOUT_AspNetUsers_UserId",
                table: "FaturatOUT",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturatOUT_AspNetUsers_UserId",
                table: "FaturatOUT");

            migrationBuilder.DropIndex(
                name: "IX_FaturatOUT_UserId",
                table: "FaturatOUT");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FaturatOUT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df606594-ecd7-44c3-bf33-edbb8dd5f867", "15df4e21-c513-4447-9546-78e2889dc38b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cb8bf8c-3639-4e5c-ae7e-180a5360f33a", "e86f2037-9147-4513-a0e4-67b74ea4070e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c051226-3bbf-4032-8919-24311c87290e", "5191156e-7498-423e-9b30-e2980baa1c61", "Puntor", "PUNTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_FaturatOUT_ShitjaId",
                table: "FaturatOUT",
                column: "ShitjaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FaturatOUT_Shitjet_ShitjaId",
                table: "FaturatOUT",
                column: "ShitjaId",
                principalTable: "Shitjet",
                principalColumn: "ShitjaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
