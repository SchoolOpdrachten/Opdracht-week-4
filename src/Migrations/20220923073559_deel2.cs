using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    public partial class deel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BegeleidId",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Gebruikers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EersteBezoek",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GeboorteDatum",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeeftFavorieteAttractieId",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnderhoudId",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnderhoudId1",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateTimeBereik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Eind = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTimeBereik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerMedewerker",
                columns: table => new
                {
                    CoordinaatId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerMedewerker", x => new { x.CoordinaatId, x.DoetId });
                    table.ForeignKey(
                        name: "FK_MedewerkerMedewerker_Gebruikers_CoordinaatId",
                        column: x => x.CoordinaatId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerMedewerker_Gebruikers_DoetId",
                        column: x => x.DoetId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Onderhouds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Probleem = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhouds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TijdId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false),
                    GastId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Attracties_AttractieId",
                        column: x => x.AttractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserveringen_DateTimeBereik_TijdId",
                        column: x => x.TijdId,
                        principalTable: "DateTimeBereik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gebruikers_GastId",
                        column: x => x.GastId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_BegeleidId",
                table: "Gebruikers",
                column: "BegeleidId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_HeeftFavorieteAttractieId",
                table: "Gebruikers",
                column: "HeeftFavorieteAttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_OnderhoudId",
                table: "Gebruikers",
                column: "OnderhoudId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_OnderhoudId1",
                table: "Gebruikers",
                column: "OnderhoudId1");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerMedewerker_DoetId",
                table: "MedewerkerMedewerker",
                column: "DoetId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_AttractieId",
                table: "Reserveringen",
                column: "AttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_GastId",
                table: "Reserveringen",
                column: "GastId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_TijdId",
                table: "Reserveringen",
                column: "TijdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Attracties_HeeftFavorieteAttractieId",
                table: "Gebruikers",
                column: "HeeftFavorieteAttractieId",
                principalTable: "Attracties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Gebruikers_BegeleidId",
                table: "Gebruikers",
                column: "BegeleidId",
                principalTable: "Gebruikers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Onderhouds_OnderhoudId",
                table: "Gebruikers",
                column: "OnderhoudId",
                principalTable: "Onderhouds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Onderhouds_OnderhoudId1",
                table: "Gebruikers",
                column: "OnderhoudId1",
                principalTable: "Onderhouds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Attracties_HeeftFavorieteAttractieId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Gebruikers_BegeleidId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Onderhouds_OnderhoudId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Onderhouds_OnderhoudId1",
                table: "Gebruikers");

            migrationBuilder.DropTable(
                name: "MedewerkerMedewerker");

            migrationBuilder.DropTable(
                name: "Onderhouds");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "DateTimeBereik");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_BegeleidId",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_HeeftFavorieteAttractieId",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_OnderhoudId",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_OnderhoudId1",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "BegeleidId",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "EersteBezoek",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "GeboorteDatum",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "HeeftFavorieteAttractieId",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "OnderhoudId",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "OnderhoudId1",
                table: "Gebruikers");
        }
    }
}
