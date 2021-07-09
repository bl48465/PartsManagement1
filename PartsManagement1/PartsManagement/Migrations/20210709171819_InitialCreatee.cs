using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class InitialCreatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a4d8f40-4100-4702-b159-e3d519f2a2b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f672ad5-1895-41fe-ba42-cd945c68057f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f79efbb1-054c-452f-a561-55ea37f90542");

            migrationBuilder.AddColumn<string>(
                name: "emriKomentuesit",
                table: "Komentet",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d90e8e82-bd63-4cab-8ed6-a26645cb6b80", "18cb3664-6069-485a-9326-2cb7a1ce2dea", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59486023-1937-4c47-acd5-584b496c2c93", "da0caafa-6d8a-4464-a8a6-6d9c1e180680", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24d0dbc7-aee7-4bbd-9d0e-2fd6176fd68d", "206d7b6f-c6a8-4820-b68c-71b1d3e1b5cf", "Puntor", "PUNTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_FaturatOUT_ProduktiId",
                table: "FaturatOUT",
                column: "ProduktiId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturatOUT_Produktet_ProduktiId",
                table: "FaturatOUT",
                column: "ProduktiId",
                principalTable: "Produktet",
                principalColumn: "ProduktiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturatOUT_Produktet_ProduktiId",
                table: "FaturatOUT");

            migrationBuilder.DropIndex(
                name: "IX_FaturatOUT_ProduktiId",
                table: "FaturatOUT");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24d0dbc7-aee7-4bbd-9d0e-2fd6176fd68d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59486023-1937-4c47-acd5-584b496c2c93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90e8e82-bd63-4cab-8ed6-a26645cb6b80");

            migrationBuilder.DropColumn(
                name: "emriKomentuesit",
                table: "Komentet");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f672ad5-1895-41fe-ba42-cd945c68057f", "31b27f05-a90d-4479-a85f-4d5301c1c16a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a4d8f40-4100-4702-b159-e3d519f2a2b4", "b0554823-db30-4e03-ad6a-622adf9b4e49", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f79efbb1-054c-452f-a561-55ea37f90542", "82d39428-3e90-458f-93d1-ef511ea410e1", "Puntor", "PUNTOR" });
        }
    }
}
