using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    /// <inheritdoc />
    public partial class recover3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Competitions_CompetitionId",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CompetitionId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Competitions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "Competitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CompetitionId",
                table: "Competitions",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Competitions_CompetitionId",
                table: "Competitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");
        }
    }
}
