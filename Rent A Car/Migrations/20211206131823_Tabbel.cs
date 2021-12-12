using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class Tabbel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beheerder",
                columns: table => new
                {
                    BeheerderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoonNummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beheerder", x => x.BeheerderId);
                });

            migrationBuilder.CreateTable(
                name: "Klant",
                columns: table => new
                {
                    KlantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leeftijd = table.Column<int>(type: "int", nullable: false),
                    TelefoonNummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klant", x => x.KlantId);
                });

            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    MedewerkerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoonNummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.MedewerkerId);
                });

            migrationBuilder.CreateTable(
                name: "VoertuigRegistratie",
                columns: table => new
                {
                    VoertuigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedewerkerId = table.Column<int>(type: "int", nullable: false),
                    Merk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kenteken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schakelaar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brandstof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AantalZitPlaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Airco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AantalDeur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoertuigRegistratie", x => x.VoertuigId);
                });

            migrationBuilder.CreateTable(
                name: "VoertuigReservatie",
                columns: table => new
                {
                    VoertuigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(type: "int", nullable: false),
                    AutoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoertuigReservatie", x => x.VoertuigId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beheerder");

            migrationBuilder.DropTable(
                name: "Klant");

            migrationBuilder.DropTable(
                name: "Medewerker");

            migrationBuilder.DropTable(
                name: "VoertuigRegistratie");

            migrationBuilder.DropTable(
                name: "VoertuigReservatie");
        }
    }
}
