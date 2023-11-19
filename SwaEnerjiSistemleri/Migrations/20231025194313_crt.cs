using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwaEnerjiSistemleri.Migrations
{
    public partial class crt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dagiticilars",
                columns: table => new
                {
                    DagiticiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DagiticiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DagiticiSehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MevcutTrafoSayisi = table.Column<int>(type: "int", nullable: false),
                    ToplamUretilenElektrik = table.Column<int>(type: "int", nullable: false),
                    ToplamTuketilenElektrik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dagiticilars", x => x.DagiticiId);
                });

            migrationBuilder.CreateTable(
                name: "Sehirlers",
                columns: table => new
                {
                    SehirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SehirMerkezi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirlers", x => x.SehirId);
                });

            migrationBuilder.CreateTable(
                name: "Firmalars",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DagiticiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalars", x => x.FirmaId);
                    table.ForeignKey(
                        name: "FK_Firmalars_Dagiticilars_DagiticiId",
                        column: x => x.DagiticiId,
                        principalTable: "Dagiticilars",
                        principalColumn: "DagiticiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tuketicilers",
                columns: table => new
                {
                    TuketiciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SayacNo = table.Column<int>(type: "int", nullable: false),
                    TuketiciAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuketiciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonelikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaturaKesimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuketicilers", x => x.TuketiciId);
                    table.ForeignKey(
                        name: "FK_Tuketicilers_Firmalars_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalars",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tuketicilers_Sehirlers_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirlers",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firmalars_DagiticiId",
                table: "Firmalars",
                column: "DagiticiId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuketicilers_FirmaId",
                table: "Tuketicilers",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuketicilers_SehirId",
                table: "Tuketicilers",
                column: "SehirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tuketicilers");

            migrationBuilder.DropTable(
                name: "Firmalars");

            migrationBuilder.DropTable(
                name: "Sehirlers");

            migrationBuilder.DropTable(
                name: "Dagiticilars");
        }
    }
}
