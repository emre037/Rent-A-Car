using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class Dagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beheerder");

            migrationBuilder.DropTable(
                name: "Klant");

            migrationBuilder.DropTable(
                name: "Medewerker");

            migrationBuilder.DropColumn(
                name: "EindDatum",
                table: "VoertuigRegistratie");

            migrationBuilder.AddColumn<int>(
                name: "AantalDagen",
                table: "VoertuigRegistratie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "VoertuigRegistratie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoertuigRegistratie_ApplicationUserId",
                table: "VoertuigRegistratie",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoertuigRegistratie_AspNetUsers_ApplicationUserId",
                table: "VoertuigRegistratie",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoertuigRegistratie_AspNetUsers_ApplicationUserId",
                table: "VoertuigRegistratie");

            migrationBuilder.DropIndex(
                name: "IX_VoertuigRegistratie_ApplicationUserId",
                table: "VoertuigRegistratie");

            migrationBuilder.DropColumn(
                name: "AantalDagen",
                table: "VoertuigRegistratie");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "VoertuigRegistratie");

            migrationBuilder.AddColumn<DateTime>(
                name: "EindDatum",
                table: "VoertuigRegistratie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Beheerder",
                columns: table => new
                {
                    BeheerderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoonNummer = table.Column<int>(type: "int", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leeftijd = table.Column<int>(type: "int", nullable: false),
                    TelefoonNummer = table.Column<int>(type: "int", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoonNummer = table.Column<int>(type: "int", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.MedewerkerId);
                });
        }
    }
}
