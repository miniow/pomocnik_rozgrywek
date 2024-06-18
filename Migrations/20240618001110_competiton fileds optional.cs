using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    /// <inheritdoc />
    public partial class competitonfiledsoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Areas_AreaId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentSeasonId",
                table: "Competitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Competitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Areas_AreaId",
                table: "Competitions",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions",
                column: "CurrentSeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Areas_AreaId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentSeasonId",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Areas_AreaId",
                table: "Competitions",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions",
                column: "CurrentSeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
