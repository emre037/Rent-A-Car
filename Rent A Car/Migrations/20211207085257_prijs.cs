using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class prijs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Airco",
                table: "VoertuigRegistratie",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dagprijs",
                table: "VoertuigRegistratie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dagprijs",
                table: "VoertuigRegistratie");

            migrationBuilder.AlterColumn<string>(
                name: "Airco",
                table: "VoertuigRegistratie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
