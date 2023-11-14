using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbacProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class explorer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Explorers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explorers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CaptainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_Explorers_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Explorers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_CaptainId",
                table: "Planets",
                column: "CaptainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Explorers");
        }
    }
}
