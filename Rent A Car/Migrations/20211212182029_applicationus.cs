using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class applicationus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerker");
        }
    }
}
