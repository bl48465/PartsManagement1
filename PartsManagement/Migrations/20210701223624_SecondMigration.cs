using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shitjet_FaturatOUT_FaturaOUTId",
                table: "Shitjet");

            migrationBuilder.DropIndex(
                name: "IX_Shitjet_FaturaOUTId",
                table: "Shitjet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06af1abb-55fb-4dcf-b255-3e0bd97313bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bcd7be0-317b-4c77-9273-6d811f472c41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9c335ff-edeb-4615-bcc9-d63331d53611");

            migrationBuilder.DropColumn(
                name: "FaturaOUTId",
                table: "Shitjet");

            migrationBuilder.AddColumn<int>(
                name: "FaturaId",
                table: "Shitjet",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Shitjet_FaturatOUT_FaturaId",
                table: "Shitjet",
                column: "FaturaId",
                principalTable: "FaturatOUT",
                principalColumn: "FaturaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shitjet_FaturatOUT_FaturaId",
                table: "Shitjet");

            migrationBuilder.DropIndex(
                name: "IX_Shitjet_FaturaId",
                table: "Shitjet");

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

            migrationBuilder.DropColumn(
                name: "FaturaId",
                table: "Shitjet");

            migrationBuilder.AddColumn<int>(
                name: "FaturaOUTId",
                table: "Shitjet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6bcd7be0-317b-4c77-9273-6d811f472c41", "ef74d01a-e7d1-4ca2-9670-85d9b30e24a0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06af1abb-55fb-4dcf-b255-3e0bd97313bf", "b75e1951-cb7d-4c14-9342-5f2050fdbd0f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9c335ff-edeb-4615-bcc9-d63331d53611", "6889a567-e3a9-4939-b817-1a5eb2d4f29a", "Puntor", "PUNTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Shitjet_FaturaOUTId",
                table: "Shitjet",
                column: "FaturaOUTId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shitjet_FaturatOUT_FaturaOUTId",
                table: "Shitjet",
                column: "FaturaOUTId",
                principalTable: "FaturatOUT",
                principalColumn: "FaturaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
