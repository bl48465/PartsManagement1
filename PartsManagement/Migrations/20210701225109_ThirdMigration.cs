using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturatOUT_Produktet_ProduktiId",
                table: "FaturatOUT");

            migrationBuilder.DropForeignKey(
                name: "FK_Shitjet_FaturatOUT_FaturaId",
                table: "Shitjet");

            migrationBuilder.DropIndex(
                name: "IX_Shitjet_FaturaId",
                table: "Shitjet");

            migrationBuilder.DropIndex(
                name: "IX_FaturatOUT_ProduktiId",
                table: "FaturatOUT");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8335fd9e-2627-43f9-bfd0-243d08a6ed27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce299fbb-8760-4e78-9c80-957772cbe144");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cedb76e2-b1bb-40fe-b452-3c6919dabc5a");

            migrationBuilder.AddColumn<int>(
                name: "ShitjaId",
                table: "FaturatOUT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82e2ec6f-7beb-42de-91d9-3d996f84c938", "00f5aa54-4fbf-4572-a567-2740e785c518", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39d9e739-050c-489a-b3b2-e32f020d9a27", "b0be86cf-4267-4150-b039-13f6a10e6dbe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61f1d0e7-ee9e-45d6-85ca-b7ca442ff3f2", "1214c191-7dc7-4025-9555-ea4c3ca2c354", "Puntor", "PUNTOR" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "39d9e739-050c-489a-b3b2-e32f020d9a27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61f1d0e7-ee9e-45d6-85ca-b7ca442ff3f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82e2ec6f-7beb-42de-91d9-3d996f84c938");

            migrationBuilder.DropColumn(
                name: "ShitjaId",
                table: "FaturatOUT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8335fd9e-2627-43f9-bfd0-243d08a6ed27", "55eb1d23-f171-488e-96bc-88821e301020", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cedb76e2-b1bb-40fe-b452-3c6919dabc5a", "882262c7-1927-46be-a224-8d27cfbcca3d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce299fbb-8760-4e78-9c80-957772cbe144", "5711c11f-2d1e-47a4-bef1-87d1997e5d6c", "Puntor", "PUNTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Shitjet_FaturaId",
                table: "Shitjet",
                column: "FaturaId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Shitjet_FaturatOUT_FaturaId",
                table: "Shitjet",
                column: "FaturaId",
                principalTable: "FaturatOUT",
                principalColumn: "FaturaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
