using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class autofoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auto1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "char(7)", maxLength: 7, nullable: true),
                    Voornaam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoFoto1s",
                columns: table => new
                {
                    Bestandsnaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Auto1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoFoto1s", x => x.Bestandsnaam);
                    table.ForeignKey(
                        name: "FK_AutoFoto1s_Auto1s_Auto1",
                        column: x => x.Auto1,
                        principalTable: "Auto1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoFoto1s_Auto1",
                table: "AutoFoto1s",
                column: "Auto1",
                unique: true,
                filter: "[Auto1] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoFoto1s");

            migrationBuilder.DropTable(
                name: "Auto1s");
        }
    }
}
