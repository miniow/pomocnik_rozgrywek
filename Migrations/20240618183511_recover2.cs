using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    /// <inheritdoc />
    public partial class recover2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Teams_TeamId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Teams_TeamId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Competitions_CompetitionId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Teams_WinnerId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_CompetitionId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_WinnerId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Competitions",
                newName: "CompetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_TeamId",
                table: "Competitions",
                newName: "IX_Competitions_CompetitionId");

            migrationBuilder.CreateTable(
                name: "CompetitionTeam",
                columns: table => new
                {
                    RunningCompetitionsId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTeam", x => new { x.RunningCompetitionsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Competitions_RunningCompetitionsId",
                        column: x => x.RunningCompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_TeamsId",
                table: "CompetitionTeam",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Competitions_CompetitionId",
                table: "Competitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Teams_TeamId",
                table: "Person",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Competitions_CompetitionId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Teams_TeamId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "CompetitionTeam");

            migrationBuilder.RenameColumn(
                name: "CompetitionId",
                table: "Competitions",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_CompetitionId",
                table: "Competitions",
                newName: "IX_Competitions_TeamId");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_CompetitionId",
                table: "Seasons",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_WinnerId",
                table: "Seasons",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Teams_TeamId",
                table: "Competitions",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Teams_TeamId",
                table: "Person",
                column: "TeamId",
                principalTable: "Teams",
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
                principalColumn: "Id");
        }
    }
}
