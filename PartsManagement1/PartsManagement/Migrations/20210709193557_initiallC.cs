using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class initiallC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Kerkesat",
                columns: table => new
                {
                    KekresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriMbiemri = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Marka = table.Column<string>(nullable: true),
                    Modeli = table.Column<string>(nullable: true),
                    Mbishkrimi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kerkesat", x => x.KekresaID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6c06de7-4a5d-4c4e-aefb-fd349d953805", "a6b9ba22-e67c-433c-8bd8-48a7b15ea5e2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9674503-38c4-45eb-bbc7-9edd59bea5d0", "cfc35c97-70eb-46cf-9476-edf43d58af07", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67ac1bbf-cd0e-4cdf-8185-06a1e7b88f59", "a6ae0729-6974-45fe-b3ff-c615d219d269", "Puntor", "PUNTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kerkesat");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67ac1bbf-cd0e-4cdf-8185-06a1e7b88f59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6c06de7-4a5d-4c4e-aefb-fd349d953805");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9674503-38c4-45eb-bbc7-9edd59bea5d0");

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
        }
    }
}
