﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbacProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class addpath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Planets");
        }
    }
}
