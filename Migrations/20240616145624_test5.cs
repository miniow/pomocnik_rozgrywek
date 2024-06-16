using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    /// <inheritdoc />
    public partial class test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Areas_ParentAreaId",
                table: "Areas");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Areas_ParentAreaId",
                table: "Areas",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Areas_ParentAreaId",
                table: "Areas");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Areas_ParentAreaId",
                table: "Areas",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
