using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    public partial class vrijdag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Gebruikers_BegeleidId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Onderhouds_OnderhoudId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Onderhouds_OnderhoudId1",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveringen_DateTimeBereik_TijdId",
                table: "Reserveringen");

            migrationBuilder.DropTable(
                name: "DateTimeBereik");

            migrationBuilder.DropTable(
                name: "MedewerkerMedewerker");

            migrationBuilder.DropIndex(
                name: "IX_Reserveringen_TijdId",
                table: "Reserveringen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onderhouds",
                table: "Onderhouds");

            migrationBuilder.RenameTable(
                name: "Onderhouds",
                newName: "Onderhoud");

            migrationBuilder.RenameColumn(
                name: "TijdId",
                table: "Reserveringen",
                newName: "Tijd_Id");

            migrationBuilder.RenameColumn(
                name: "BegeleidId",
                table: "Gebruikers",
                newName: "BegeleiderId");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruikers_BegeleidId",
                table: "Gebruikers",
                newName: "IX_Gebruikers_BegeleiderId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tijd_Begin",
                table: "Reserveringen",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tijd_Eind",
                table: "Reserveringen",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onderhoud",
                table: "Onderhoud",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Gebruikers_BegeleiderId",
                table: "Gebruikers",
                column: "BegeleiderId",
                principalTable: "Gebruikers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Onderhoud_OnderhoudId",
                table: "Gebruikers",
                column: "OnderhoudId",
                principalTable: "Onderhoud",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Onderhoud_OnderhoudId1",
                table: "Gebruikers",
                column: "OnderhoudId1",
                principalTable: "Onderhoud",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Gebruikers_BegeleiderId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Onderhoud_OnderhoudId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Onderhoud_OnderhoudId1",
                table: "Gebruikers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Onderhoud",
                table: "Onderhoud");

            migrationBuilder.DropColumn(
                name: "Tijd_Begin",
                table: "Reserveringen");

            migrationBuilder.DropColumn(
                name: "Tijd_Eind",
                table: "Reserveringen");

            migrationBuilder.RenameTable(
                name: "Onderhoud",
                newName: "Onderhouds");

            migrationBuilder.RenameColumn(
                name: "Tijd_Id",
                table: "Reserveringen",
                newName: "TijdId");

            migrationBuilder.RenameColumn(
                name: "BegeleiderId",
                table: "Gebruikers",
                newName: "BegeleidId");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruikers_BegeleiderId",
                table: "Gebruikers",
                newName: "IX_Gebruikers_BegeleidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Onderhouds",
                table: "Onderhouds",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_TijdId",
                table: "Reserveringen",
                column: "TijdId");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerMedewerker_DoetId",
                table: "MedewerkerMedewerker",
                column: "DoetId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveringen_DateTimeBereik_TijdId",
                table: "Reserveringen",
                column: "TijdId",
                principalTable: "DateTimeBereik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
