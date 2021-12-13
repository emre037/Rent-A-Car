using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car.Migrations
{
    public partial class overzicht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RegisterViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterViewModel_ApplicationUserId",
                table: "RegisterViewModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterViewModel_AspNetUsers_ApplicationUserId",
                table: "RegisterViewModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterViewModel_AspNetUsers_ApplicationUserId",
                table: "RegisterViewModel");

            migrationBuilder.DropIndex(
                name: "IX_RegisterViewModel_ApplicationUserId",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RegisterViewModel");
        }
    }
}
