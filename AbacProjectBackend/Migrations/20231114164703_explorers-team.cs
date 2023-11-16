using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbacProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class explorersteam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Explorers_CaptainId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_CaptainId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "CaptainId",
                table: "Planets");

            migrationBuilder.CreateTable(
                name: "PlanetExplorers",
                columns: table => new
                {
                    PlanetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExplorerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetExplorers", x => new { x.PlanetId, x.ExplorerId });
                    table.ForeignKey(
                        name: "FK_PlanetExplorers_Explorers_ExplorerId",
                        column: x => x.ExplorerId,
                        principalTable: "Explorers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanetExplorers_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanetExplorers_ExplorerId",
                table: "PlanetExplorers",
                column: "ExplorerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanetExplorers");

            migrationBuilder.AddColumn<Guid>(
                name: "CaptainId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planets_CaptainId",
                table: "Planets",
                column: "CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Explorers_CaptainId",
                table: "Planets",
                column: "CaptainId",
                principalTable: "Explorers",
                principalColumn: "Id");
        }
    }
}
