using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class ein : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "VoertuigReservatie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoertuigReservatie_ApplicationUserId",
                table: "VoertuigReservatie",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoertuigReservatie_AspNetUsers_ApplicationUserId",
                table: "VoertuigReservatie",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoertuigReservatie_AspNetUsers_ApplicationUserId",
                table: "VoertuigReservatie");

            migrationBuilder.DropIndex(
                name: "IX_VoertuigReservatie_ApplicationUserId",
                table: "VoertuigReservatie");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "VoertuigReservatie");
        }
    }
}
