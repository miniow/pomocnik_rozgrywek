using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    /// <inheritdoc />
    public partial class areas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Season_SeasonId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_CompetitionId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Teams_WinnerId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Tournaments_CompetitionId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Season_CurrentSeasonId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.RenameTable(
                name: "Tournaments",
                newName: "Competitions");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_TeamId",
                table: "Competitions",
                newName: "IX_Competitions_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_CurrentSeasonId",
                table: "Competitions",
                newName: "IX_Competitions_CurrentSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Season_WinnerId",
                table: "Seasons",
                newName: "IX_Seasons_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Season_CompetitionId",
                table: "Seasons",
                newName: "IX_Seasons_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions",
                column: "CurrentSeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Teams_TeamId",
                table: "Competitions",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitions_CompetitionId",
                table: "Matches",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Competitions_CompetitionId",
                table: "Seasons",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Teams_WinnerId",
                table: "Seasons",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Teams_TeamId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Competitions_CompetitionId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Competitions_CompetitionId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Teams_WinnerId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.RenameTable(
                name: "Competitions",
                newName: "Tournaments");

            migrationBuilder.RenameIndex(
                name: "IX_Seasons_WinnerId",
                table: "Season",
                newName: "IX_Season_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Seasons_CompetitionId",
                table: "Season",
                newName: "IX_Season_CompetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_TeamId",
                table: "Tournaments",
                newName: "IX_Tournaments_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_CurrentSeasonId",
                table: "Tournaments",
                newName: "IX_Tournaments_CurrentSeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Season_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_CompetitionId",
                table: "Matches",
                column: "CompetitionId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Teams_WinnerId",
                table: "Season",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Tournaments_CompetitionId",
                table: "Season",
                column: "CompetitionId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Season_CurrentSeasonId",
                table: "Tournaments",
                column: "CurrentSeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
