using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbacProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class reverttoinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Explorers_Planets_PlanetId",
                table: "Explorers");

            migrationBuilder.DropIndex(
                name: "IX_Explorers_PlanetId",
                table: "Explorers");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Explorers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanetId",
                table: "Explorers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Explorers_PlanetId",
                table: "Explorers",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Explorers_Planets_PlanetId",
                table: "Explorers",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }
    }
}
