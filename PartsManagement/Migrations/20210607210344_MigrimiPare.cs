using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class MigrimiPare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: false),
                    Mbiemri = table.Column<string>(nullable: false),
                    Kompania = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Roli = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Komentet",
                columns: table => new
                {
                    KomentiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulli = table.Column<string>(nullable: true),
                    Mesazhi = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentet", x => x.KomentiID);
                    table.ForeignKey(
                        name: "FK_Komentet_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porosite",
                columns: table => new
                {
                    PorosiaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: false),
                    Sasia = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porosite", x => x.PorosiaID);
                    table.ForeignKey(
                        name: "FK_Porosite_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sektoret",
                columns: table => new
                {
                    SektoriID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sektoret", x => x.SektoriID);
                    table.ForeignKey(
                        name: "FK_Sektoret_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shitjet",
                columns: table => new
                {
                    ShitjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Qmimi = table.Column<double>(nullable: false),
                    Sasia = table.Column<int>(nullable: false),
                    OEnumber = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shitjet", x => x.ShitjaID);
                    table.ForeignKey(
                        name: "FK_Shitjet_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produktet",
                columns: table => new
                {
                    ProduktiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: true),
                    Qmimi = table.Column<double>(nullable: false),
                    Sasia = table.Column<int>(nullable: false),
                    OEnumber = table.Column<string>(nullable: true),
                    SektoriID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produktet", x => x.ProduktiID);
                    table.ForeignKey(
                        name: "FK_Produktet_Sektoret_SektoriID",
                        column: x => x.SektoriID,
                        principalTable: "Sektoret",
                        principalColumn: "SektoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentet_UserID",
                table: "Komentet",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Porosite_UserID",
                table: "Porosite",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Produktet_SektoriID",
                table: "Produktet",
                column: "SektoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Sektoret_UserId",
                table: "Sektoret",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shitjet_UserID",
                table: "Shitjet",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentet");

            migrationBuilder.DropTable(
                name: "Porosite");

            migrationBuilder.DropTable(
                name: "Produktet");

            migrationBuilder.DropTable(
                name: "Shitjet");

            migrationBuilder.DropTable(
                name: "Sektoret");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
