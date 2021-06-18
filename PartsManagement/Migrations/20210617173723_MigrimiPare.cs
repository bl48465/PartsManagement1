using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsManagement.Migrations
{
    public partial class MigrimiPare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaturaDalese",
                columns: table => new
                {
                    FaturaDaleseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaDalese", x => x.FaturaDaleseID);
                });

            migrationBuilder.CreateTable(
                name: "FaturaHyrese",
                columns: table => new
                {
                    FaturaHyreseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriFatures = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaHyrese", x => x.FaturaHyreseID);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    MarkaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriMarkes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.MarkaID);
                });

            migrationBuilder.CreateTable(
                name: "Shteti",
                columns: table => new
                {
                    ShtetiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriShtetit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shteti", x => x.ShtetiID);
                });

            migrationBuilder.CreateTable(
                name: "Furnitoret",
                columns: table => new
                {
                    FurnitoriID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriFurnitorit = table.Column<string>(nullable: true),
                    FaturimiFaturaHyreseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitoret", x => x.FurnitoriID);
                    table.ForeignKey(
                        name: "FK_Furnitoret_FaturaHyrese_FaturimiFaturaHyreseID",
                        column: x => x.FaturimiFaturaHyreseID,
                        principalTable: "FaturaHyrese",
                        principalColumn: "FaturaHyreseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modeli",
                columns: table => new
                {
                    ModeliID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriModelit = table.Column<string>(nullable: true),
                    MarkaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeli", x => x.ModeliID);
                    table.ForeignKey(
                        name: "FK_Modeli_Marka_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Marka",
                        principalColumn: "MarkaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendbanimi",
                columns: table => new
                {
                    VendbanimiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriQytetit = table.Column<string>(nullable: true),
                    ShtetiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendbanimi", x => x.VendbanimiID);
                    table.ForeignKey(
                        name: "FK_Vendbanimi_Shteti_ShtetiID",
                        column: x => x.ShtetiID,
                        principalTable: "Shteti",
                        principalColumn: "ShtetiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: false),
                    Mbiemri = table.Column<string>(nullable: false),
                    Kompania = table.Column<string>(nullable: false),
                    VendbanimiID = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Users_Vendbanimi_VendbanimiID",
                        column: x => x.VendbanimiID,
                        principalTable: "Vendbanimi",
                        principalColumn: "VendbanimiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komentet",
                columns: table => new
                {
                    KomentiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulli = table.Column<string>(nullable: true),
                    Mesazhi = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Porosite",
                columns: table => new
                {
                    PorosiaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: false),
                    Sasia = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sektoret",
                columns: table => new
                {
                    SektoriID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sektoret", x => x.SektoriID);
                    table.ForeignKey(
                        name: "FK_Sektoret_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shitjet",
                columns: table => new
                {
                    ShitjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komenti = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    FaturaDaleseID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shitjet", x => x.ShitjaID);
                    table.ForeignKey(
                        name: "FK_Shitjet_FaturaDalese_FaturaDaleseID",
                        column: x => x.FaturaDaleseID,
                        principalTable: "FaturaDalese",
                        principalColumn: "FaturaDaleseID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "DetajetDalese",
                columns: table => new
                {
                    DetajetDaleseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sasia = table.Column<int>(nullable: false),
                    Cmimi = table.Column<double>(nullable: false),
                    FaturaDaleseID = table.Column<int>(nullable: false),
                    ProduktiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetajetDalese", x => x.DetajetDaleseID);
                    table.ForeignKey(
                        name: "FK_DetajetDalese_FaturaDalese_FaturaDaleseID",
                        column: x => x.FaturaDaleseID,
                        principalTable: "FaturaDalese",
                        principalColumn: "FaturaDaleseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetajetDalese_Produktet_ProduktiID",
                        column: x => x.ProduktiID,
                        principalTable: "Produktet",
                        principalColumn: "ProduktiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetajetHyrese",
                columns: table => new
                {
                    DetajetHyreseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sasia = table.Column<int>(nullable: false),
                    Cmimi = table.Column<double>(nullable: false),
                    FaturaHyreseID = table.Column<int>(nullable: false),
                    ProduktiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetajetHyrese", x => x.DetajetHyreseID);
                    table.ForeignKey(
                        name: "FK_DetajetHyrese_FaturaHyrese_FaturaHyreseID",
                        column: x => x.FaturaHyreseID,
                        principalTable: "FaturaHyrese",
                        principalColumn: "FaturaHyreseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetajetHyrese_Produktet_ProduktiID",
                        column: x => x.ProduktiID,
                        principalTable: "Produktet",
                        principalColumn: "ProduktiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerkatesiaProduktit",
                columns: table => new
                {
                    produktiID = table.Column<int>(nullable: false),
                    modeliID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerkatesiaProduktit", x => new { x.modeliID, x.produktiID });
                    table.ForeignKey(
                        name: "FK_PerkatesiaProduktit_Modeli_modeliID",
                        column: x => x.modeliID,
                        principalTable: "Modeli",
                        principalColumn: "ModeliID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerkatesiaProduktit_Produktet_produktiID",
                        column: x => x.produktiID,
                        principalTable: "Produktet",
                        principalColumn: "ProduktiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shteti",
                columns: new[] { "ShtetiID", "EmriShtetit" },
                values: new object[] { 1, "Kosovë" });

            migrationBuilder.InsertData(
                table: "Shteti",
                columns: new[] { "ShtetiID", "EmriShtetit" },
                values: new object[] { 2, "Shqipëri" });

            migrationBuilder.InsertData(
                table: "Shteti",
                columns: new[] { "ShtetiID", "EmriShtetit" },
                values: new object[] { 3, "Maqedoni" });

            migrationBuilder.InsertData(
                table: "Vendbanimi",
                columns: new[] { "VendbanimiID", "EmriQytetit", "ShtetiID" },
                values: new object[,]
                {
                    { 1, "Artanë", 1 },
                    { 36, "Durrës", 2 },
                    { 37, "Elbasan", 2 },
                    { 38, "Fier", 2 },
                    { 39, "Gramsh", 2 },
                    { 40, "Gjirokastër", 2 },
                    { 41, "Has", 2 },
                    { 42, "Kavajë", 2 },
                    { 43, "Kolonjë", 2 },
                    { 44, "Korcë", 2 },
                    { 45, "Krujë", 2 },
                    { 46, "Kucovë", 2 },
                    { 47, "Kukës", 2 },
                    { 48, "Kurbin", 2 },
                    { 49, "Lezhë", 2 },
                    { 50, "Librazhd", 2 },
                    { 51, "Lushnjë", 2 },
                    { 52, "Malësi e madhe", 2 },
                    { 53, "Mallakastër", 2 },
                    { 54, "Mat", 2 },
                    { 55, "Mirditë", 2 },
                    { 56, "Peqin", 2 },
                    { 57, "Përmet", 2 },
                    { 58, "Pogradec", 2 },
                    { 59, "Pukë", 2 },
                    { 60, "Sarandë", 2 },
                    { 61, "Skrapar", 2 },
                    { 62, "Shkodër", 2 },
                    { 63, "Tepelenë", 2 },
                    { 64, "Tiranë", 2 },
                    { 35, "Dibër", 2 },
                    { 34, "Devoll", 2 },
                    { 33, "Delvinë", 2 },
                    { 32, "Bulqizë", 2 },
                    { 2, "Besianë", 1 },
                    { 3, "Burim", 1 },
                    { 4, "Dardanë", 1 },
                    { 5, "Decan", 1 },
                    { 6, "Dragash", 1 },
                    { 7, "Drenas", 1 },
                    { 8, "Ferizaj", 1 },
                    { 9, "Fushë Kosovë", 1 },
                    { 10, "Gjakovë", 1 },
                    { 11, "Gjilan", 1 },
                    { 12, "Kastriot", 1 },
                    { 13, "Kaqanik", 1 },
                    { 14, "Klinë", 1 },
                    { 15, "Leposaviq", 1 },
                    { 65, "Tropojë", 2 },
                    { 16, "Lipjan", 1 },
                    { 18, "Mitrovicë", 1 },
                    { 19, "Pejë", 1 },
                    { 20, "Prishtinë", 1 },
                    { 21, "Prizren", 1 },
                    { 22, "Rahovec", 1 },
                    { 23, "Skënderaj", 1 },
                    { 24, "Shtërpcë", 1 },
                    { 25, "Shtime", 1 },
                    { 26, "Therandë", 1 },
                    { 27, "Viti", 1 },
                    { 28, "Vushtrri", 1 },
                    { 29, "Zubin Potok", 1 },
                    { 30, "Zveqan", 1 },
                    { 31, "Berat", 2 },
                    { 17, "Malishevë", 1 },
                    { 66, "Vlorë", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetajetDalese_FaturaDaleseID",
                table: "DetajetDalese",
                column: "FaturaDaleseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetajetDalese_ProduktiID",
                table: "DetajetDalese",
                column: "ProduktiID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetajetHyrese_FaturaHyreseID",
                table: "DetajetHyrese",
                column: "FaturaHyreseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetajetHyrese_ProduktiID",
                table: "DetajetHyrese",
                column: "ProduktiID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furnitoret_FaturimiFaturaHyreseID",
                table: "Furnitoret",
                column: "FaturimiFaturaHyreseID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentet_UserID",
                table: "Komentet",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Modeli_MarkaID",
                table: "Modeli",
                column: "MarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_PerkatesiaProduktit_produktiID",
                table: "PerkatesiaProduktit",
                column: "produktiID");

            migrationBuilder.CreateIndex(
                name: "IX_Porosite_UserID",
                table: "Porosite",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Produktet_SektoriID",
                table: "Produktet",
                column: "SektoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Sektoret_UserID",
                table: "Sektoret",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Shitjet_FaturaDaleseID",
                table: "Shitjet",
                column: "FaturaDaleseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shitjet_UserID",
                table: "Shitjet",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VendbanimiID",
                table: "Users",
                column: "VendbanimiID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendbanimi_ShtetiID",
                table: "Vendbanimi",
                column: "ShtetiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetajetDalese");

            migrationBuilder.DropTable(
                name: "DetajetHyrese");

            migrationBuilder.DropTable(
                name: "Furnitoret");

            migrationBuilder.DropTable(
                name: "Komentet");

            migrationBuilder.DropTable(
                name: "PerkatesiaProduktit");

            migrationBuilder.DropTable(
                name: "Porosite");

            migrationBuilder.DropTable(
                name: "Shitjet");

            migrationBuilder.DropTable(
                name: "FaturaHyrese");

            migrationBuilder.DropTable(
                name: "Modeli");

            migrationBuilder.DropTable(
                name: "Produktet");

            migrationBuilder.DropTable(
                name: "FaturaDalese");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "Sektoret");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendbanimi");

            migrationBuilder.DropTable(
                name: "Shteti");
        }
    }
}
