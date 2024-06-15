using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Areas_AreaId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_AreaId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Areas");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ParentAreaId",
                table: "Areas",
                column: "ParentAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Areas_ParentAreaId",
                table: "Areas",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Areas_ParentAreaId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ParentAreaId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AreaId",
                table: "Areas",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Areas_AreaId",
                table: "Areas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}
