using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class dqas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "AutoFoto1s");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "AutoFoto1s",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AutoFoto1s");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "AutoFoto1s",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
